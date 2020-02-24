using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine
{
    class RoundEngine: TurnEngine
    {

        /// <summary>
        /// Clear the List between Rounds
        /// </summary>
        /// <returns></returns>
        private bool ClearLists()
        {
            ItemPool.Clear();
            MonsterList.Clear();
            return true;
        }
    }
}
