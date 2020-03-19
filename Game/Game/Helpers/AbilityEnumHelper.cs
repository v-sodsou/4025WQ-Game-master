using System;
using System.Collections.Generic;
using Game.Models;
using System.Linq;

namespace Game.Helpers
{
    /// <summary>
    /// Helper for the Ability Enum Class
    /// </summary>
    public static class AbilityEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for Ability
        /// Removes the Abilitys that are not changable by Items such as Unknown, MaxHealth
        /// </summary>
        public static List<string> GetFullList
        {
            get
            {
                var myList = Enum.GetNames(typeof(AbilityEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for Fighter
        /// </summary>
        public static List<string> GetListFighter
        {
            get
            {
                List<string> AbilityList = new List<string>{
                AbilityEnum.Nimble.ToString(),
                AbilityEnum.Toughness.ToString(),
                AbilityEnum.Focus.ToString()
                };

                AbilityList.AddRange(GetListOthers);
                return AbilityList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for Cleric
        /// </summary>
        public static List<string> GetListCleric
        {
            get
            {

                List<string> AbilityList = new List<string>{
                AbilityEnum.Quick.ToString(),
                AbilityEnum.Barrier.ToString(),
                AbilityEnum.Curse.ToString(),
                AbilityEnum.Heal.ToString()
                };

                AbilityList.AddRange(GetListOthers);
                return AbilityList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum of not Cleric or Fighter
        /// </summary>
        public static List<string> GetListOthers
        {
            get
            {

                List<string> AbilityList = new List<string>{
                AbilityEnum.Bandage.ToString(),
                };

                return AbilityList;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AbilityEnum ConvertStringToEnum(string value)
        {
            return (AbilityEnum)Enum.Parse(typeof(AbilityEnum), value);
        }
    }
}