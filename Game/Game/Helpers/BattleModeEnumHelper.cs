using System;
using System.Collections.Generic;
using Game.Models;
using System.Linq;

namespace Game.Helpers
{
    /// <summary>
    /// Helper for the BattleMode Enum Class
    /// </summary>
    public static class BattleModeEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for BattleMode
        /// Removes the BattleModes that are not changable by Items such as Unknown, MaxHealth
        /// </summary>
        public static List<string> GetListAll
        {
            get
            {
                var myList = Enum.GetNames(typeof(BattleModeEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of Full strings of the enum for BattleMode
        /// Removes the BattleModes that are not changable by Items such as Unknown, MaxHealth
        /// </summary>
        public static List<string> GetListMessageAll
        {
            get
            {
                var list = new List<string>();

                foreach (var item in Enum.GetValues(typeof(BattleModeEnum)))
                {
                    list.Add(((BattleModeEnum)item).ToMessage());
                }
                return list;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static BattleModeEnum ConvertStringToEnum(string value)
        {
            return (BattleModeEnum)Enum.Parse(typeof(BattleModeEnum), value);
        }

        /// <summary>
        /// Given the Full String for an enum, return its value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static BattleModeEnum ConvertMessageStringToEnum(string value)
        {
            foreach (BattleModeEnum item in Enum.GetValues(typeof(BattleModeEnum)))
            {
                if (item.ToMessage().Equals(value))
                {
                    return item;
                }
            }
            return BattleModeEnum.Unknown;
        }
    }
}