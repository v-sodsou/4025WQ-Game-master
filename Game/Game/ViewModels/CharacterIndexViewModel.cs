﻿using Game.Models;
using Game.Services;
using Game.Views;
using Game.Views.Characters;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Game.ViewModels
{
    public class CharacterIndexViewModel : BaseViewModel<Character>
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
            MessagingCenter.Subscribe<CharacterCreatePage, Character>(this, "Create", async (obj, data) =>
            {
                await CreateAsync(data as Character);
            });

            // Register the Delete Message
            MessagingCenter.Subscribe<CharacterDeletePage, Character>(this, "Delete", async (obj, data) =>
            {
                await DeleteAsync(data as Character);
            });

            #endregion Messages
        }

        public override List<Character> GetDefaultData()
        {
            return DefaultData.LoadData(new Character());
        }

        #endregion Constructor
    }


}