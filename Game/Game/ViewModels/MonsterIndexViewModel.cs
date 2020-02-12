using Game.Models;
using Game.Services;
using Game.Views;
using Game.Views.Characters;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Game.ViewModels
{
    public class MonsterIndexViewModel : BaseViewModel<Monster>
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
            MessagingCenter.Subscribe<MonsterCreatePage, Monster>(this, "Create", async (obj, data) =>
            {
                await CreateAsync(data as Monster);
            });


        }

        #endregion Constructor

        public override List<Monster> GetDefaultData()
        {
            return DefaultData.LoadData(new Monster());
        }
    }


}