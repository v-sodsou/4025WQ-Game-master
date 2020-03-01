using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Helpers
{
    public static class RandomPlayerHelper
    {
        /// <summary>
        /// Get Health
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static int GetHealth(int level)
        {
            // Roll the Dice and reset the Health
            return DiceHelper.RollDice(level, 10);
        }

        
        /// <summary>
        /// Get A Random Difficulty
        /// </summary>
        /// <returns></returns>
        public static DifficultyEnum GetMonsterDifficultyValue()
        {
            var DifficultyList = DifficultyEnumHelper.GetListMonster;

            var RandomDifficulty = DifficultyList.ElementAt(DiceHelper.RollDice(1, DifficultyList.Count()) - 1);

            var result = DifficultyEnumHelper.ConvertStringToEnum(RandomDifficulty);

            return result;
        }

        /// <summary>
        /// Get Random Image
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterImage()
        {

            List<String> FirstNameList = new List<String> { "DarthVader.png", "palpatine.png", "darthmaul.png", "count_dooku.png", "Asajjventress.png", "kyloren.png" };

            var result = FirstNameList.ElementAt(DiceHelper.RollDice(1, FirstNameList.Count()) - 1);

            return result;
        }

      

        /// <summary>
        /// Get Name
        /// 
        /// Return a Random Name
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterName()
        {

            List<String> FirstNameList = new List<String> { "Darth Vader", "Palpatine", "Darth Maul", "Count Dooku", "Asajj Ventress", "Kylo Ren"};

            var result = FirstNameList.ElementAt(DiceHelper.RollDice(1, FirstNameList.Count()) - 1);

            return result;
        }

        /// <summary>
        /// Get Description
        /// 
        /// Return a random description
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterDescription()
        {
            List<String> StringList = new List<String> { "A Sith Lord", "Dark architect of the Galactic Empire", "A dangerous combatant", "Possesses a brilliance and charisma", "Slave, Nightsister, Jedi apprentice", "The leader of the mysterious Knights of Ren" };

            var result = StringList.ElementAt(DiceHelper.RollDice(1, StringList.Count()) - 1);

            return result;
        }

        
        

        /// <summary>
        /// Get Random Ability Number
        /// </summary>
        /// <returns></returns>
        public static int GetAbilityValue()
        {
            // 0 to 9, not 1-10
            return DiceHelper.RollDice(1, 10) - 1;
        }

        /// <summary>
        /// Get a Random Level
        /// </summary>
        /// <returns></returns>
        public static int GetLevel()
        {
            // 1-20
            return DiceHelper.RollDice(1, 20);
        }

        /// <summary>
        /// Get a Random Item for the Location
        /// 
        /// Return the String for the ID
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static string GetItem(ItemLocationEnum location)
        {
            var ItemList = ItemIndexViewModel.Instance.GetLocationItems(location);

            // Add Noe to the list
            ItemList.Add(new ItemModel { Id = null, Name = "None" });

            var result = ItemList.ElementAt(DiceHelper.RollDice(1, ItemList.Count()) - 1).Id;
            return result;
        }

    }
}