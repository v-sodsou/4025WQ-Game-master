using Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine
{
    /// <summary>
    /// BattleEngine class
    /// </summary>
    public class BattleEngine : RoundEngine
    {

        // Track if the Battle is Running or Not
        public bool BattleRunning = false;

        /// <summary>
        /// Add the charcter to the character list
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool PopulateCharacterList(CharacterModel data)
        {

            // Hackathon Hack #30: Who will volunteer to be first?
            // The first character in the list gets their base Attack, Speed and Defense
            // values doubled.
            if (CharacterList.Count == 0)
            {
                data.Attack *= 2;
                data.Defense *= 2;
                data.Speed *= 2;

            }
            CharacterList.Add(new PlayerInfoModel(data));

            return true;
        }

        /// <summary>
        /// Start the Battle
        /// </summary>
        /// <param name="isAutoBattle"></param>
        /// <returns></returns>
        public bool StartBattle(bool isAutoBattle)
        {
            // Reset the Score so it is fresh
            BattleScore = new ScoreModel
            {
                AutoBattle = isAutoBattle
            };

            BattleRunning = true;

            NewRound();

            return true;
        }


        /// <summary>
        /// End the Battle
        /// </summary>
        /// <returns></returns>
        public bool EndBattle()
        {
            BattleRunning = false;

            return true;
        }

    }
}
