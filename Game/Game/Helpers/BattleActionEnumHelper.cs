using System;
using System.Collections.Generic;
using Game.Models;
using System.Linq;

namespace Game.Helpers
{
    /// <summary>
    /// Helper for the BattleAction Enum Class
    /// </summary>
    public static class BattleActionEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for BattleAction
        /// Removes the BattleActions that are not changable by Items such as Unknown, MaxHealth
        /// </summary>
        public static List<string> GetListAll
        {
            get
            {
                var myList = Enum.GetNames(typeof(BattleActionEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static BattleActionEnum ConvertStringToEnum(string value)
        {
            return (BattleActionEnum)Enum.Parse(typeof(BattleActionEnum), value);
        }
    }
}
