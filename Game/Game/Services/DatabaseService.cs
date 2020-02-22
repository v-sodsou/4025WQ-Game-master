﻿using SQLite;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Game.Models;
using System.Collections.Generic;

namespace Game.Services
{
    /// <summary>
    /// Database Services
    /// Will write to the local data store
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DatabaseService<T> : IDataStore<T> where T : new()
    {
        // Create only a single instance of the class because all the data records are in memory
        private static volatile DatabaseService<T> instance;
        private static readonly object syncRoot = new Object();

        // Singleton pattern
        public static DatabaseService<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DatabaseService<T>();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Set the class to load on demand
        /// Saves app boot time
        /// </summary>
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return GetDataConnection();
        });

        /// <summary>
        /// Get Data Connection Method
        /// </summary>
        /// <returns></returns>
        public static SQLiteAsyncConnection GetDataConnection()
        {
            if (TestMode)
            {
                return new SQLiteAsyncConnection(":memory:", Constants.Flags);
            }

            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        // Check if in test mode
        public static bool TestMode = false;
        public int ForceExceptionOnNumber = -1;

        // Lazy connection
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        // Track if initialized
        static bool initialized = false;

        // Semaphore to track transactions
        private readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(initialCount: 1);

        /// <summary>
        /// Constructor
        /// All the database to start up
        /// </summary>
        public DatabaseService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        /// <summary>
        /// Create the Table if it does not exist
        /// </summary>
        /// <returns></returns>
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                initialized = true;
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(T).Name))
                {
                    return; 
                }

                await Database.CreateTablesAsync(CreateFlags.None, typeof(T));
            }
        }

        /// <summary>
        /// Wipe Data List
        /// Drop the tables and create new ones
        /// </summary>
        public async Task<bool> WipeDataListAsync()
        {
            try
            {
                await Database.DropTableAsync<T>().ConfigureAwait(false);
                await Database.CreateTablesAsync(CreateFlags.None, typeof(T));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error WipeData" + e.Message);
            }

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Create a new record for the data passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(T data)
        {
            var result = await Database.InsertAsync(data);
            return (result == 1);
        }

        /// <summary>
        /// Return the record for the ID passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> ReadAsync(string id)
        {
            T data;

            try
            {
                data = await Database.Table<T>().Where((T arg) => ((BaseModel<T>)(object)arg).Id.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception) {
                data = default(T);
            }

            return data;
        }

        /// <summary>
        /// Update the record passed in if it exists
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(T data)
        {
            var myRead = await ReadAsync(((BaseModel<T>)(object)data).Id);
            if (myRead == null)
            {
                return false;
            }

            var result = await Database.UpdateAsync(data);

            return (result == 1);
        }

        /// <summary>
        /// Delete the record of the ID passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(string id)
        {
            var data = await ReadAsync(id);
            if (data == null)
            {
                return false;
            }

            var result = await Database.DeleteAsync(data);

            return (result == 1);
        }

        /// <summary>
        /// Return all records in the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> IndexAsync()
        {
            return await Database.Table<T>().ToListAsync();
        }
    }
}