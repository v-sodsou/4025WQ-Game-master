using Game.Models;
using Game.Services;
using Game.Views;
using Game.Views.Characters;
using Game.Views.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Game.ViewModels
{
    public class MonsterIndexViewModel : BaseViewModel<MonsterModel>
    {
        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile MonsterIndexViewModel instance;
        private static readonly object syncRoot = new Object();

        public static MonsterIndexViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MonsterIndexViewModel();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton


        #region Constructor

        /// <summary>
        /// Constructor
        /// 
        /// The constructor subscribes message listeners for crudi operations
        /// </summary>
        public MonsterIndexViewModel()
        {
            Title = "Monsters";

            // Register the Create Message
            MessagingCenter.Subscribe<MonsterCreatePage, MonsterModel>(this, "Create", async (obj, data) =>
            {
                await CreateAsync(data as MonsterModel);
            });

            // Register the Delete Message
            MessagingCenter.Subscribe<MonsterDeletePage, MonsterModel>(this, "Delete", async (obj, data) =>
            {
                await DeleteAsync(data as MonsterModel);
            });


        }

        #endregion Constructor

        #region DataOperations_CRUDi

        public MonsterModel CheckIfItemExists(MonsterModel data)
        {
            // This will walk the items and find if there is one that is the same.
            // If so, it returns the item...

            var myList = Dataset.Where(a =>
                                        a.Name == data.Name)
                                        .FirstOrDefault();

            if (myList == null)
            {
                // it's not a match, return false;
                return null;
            }

            return myList;
        }

        /// <summary>
        /// Load the Default Data
        /// </summary>
        /// <returns></returns>
        public override List<MonsterModel> GetDefaultData()
        {
            return DefaultData.LoadData(new MonsterModel());
        }


        #region SortDataSet
        public override List<MonsterModel> SortDataset(List<MonsterModel> dataset)
        {
            return dataset
                    .OrderBy(a => a.Name)
                    .ThenBy(a => a.Description)
                    .ToList();
        }

        #endregion SortDataSet
    }


}