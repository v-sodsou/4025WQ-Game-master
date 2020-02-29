using Game.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Game.ViewModels
{
    class BattleEngineViewModel
    {
        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile BattleEngineViewModel instance;
        private static readonly object syncRoot = new Object();

        //Creates BattleEngineViewModel instance if none otherwise returns existing instance
        public static BattleEngineViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new BattleEngineViewModel();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        /// <summary>
        /// The Battle Engine
        /// </summary>
        public Engine.BattleEngine Engine = new Engine.BattleEngine();

        // Hold the Proposed List of Characters for the Battle to Use
        public ObservableCollection<CharacterModel> PartyCharacterList { get; set; } = new ObservableCollection<CharacterModel>();

        // Hold the View Model to the CharacterIndexViewModel
        public CharacterIndexViewModel DatabaseCharacterViewModel = CharacterIndexViewModel.Instance;

        // Have the Database Character List point to the Character View Model List
        public ObservableCollection<CharacterModel> DatabaseCharacterList { get; set; } = CharacterIndexViewModel.Instance.Dataset;
    }
}
