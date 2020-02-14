using Game.Models;
using Game.Services;
using Game.Views;
using Game.Views.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Game.ViewModels
{
    public class CharacterIndexViewModel : BaseViewModel<CharacterModel>
    {
        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile CharacterIndexViewModel instance;
        private static readonly object syncRoot = new Object();

        public static CharacterIndexViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new CharacterIndexViewModel();
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
        public CharacterIndexViewModel()
        {
            Title = "Characters";

            #region Messages

            // Register the Create Message
            MessagingCenter.Subscribe<CharacterCreatePage, CharacterModel>(this, "Create", async (obj, data) =>
            {
                await CreateAsync(data as CharacterModel);
            });

            // Register the Delete Message
            MessagingCenter.Subscribe<CharacterDeletePage, CharacterModel>(this, "Delete", async (obj, data) =>
            {
                await DeleteAsync(data as CharacterModel);
            });

            #endregion Messages
        }
        #endregion Constructor

        /// <summary>
        /// Returns the item passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public CharacterModel CheckIfItemExists(CharacterModel data)
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
        public override List<CharacterModel> GetDefaultData()
        {
            return DefaultData.LoadData(new CharacterModel());
        }

        #region SortDataSet

        /// <summary>
        /// The Sort Order for the Character Model
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public override List<CharacterModel> SortDataset(List<CharacterModel> dataset)
        {
            return dataset
                    .OrderBy(a => a.Name)
                    .ThenBy(a => a.Description)
                    .ToList();
        }

        #endregion SortDataSet
    }


}