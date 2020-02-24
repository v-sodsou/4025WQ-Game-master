using Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine
{
    class BattleEngine: RoundEngine
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
            CharacterList.Add(new PlayerInfoModel(data));

            return true;
        }
    }
}
