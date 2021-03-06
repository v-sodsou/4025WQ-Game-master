﻿using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static string GetMonsterImage(string name)
        {

            string image = string.Empty;
            switch (name)
            {
                case "Darth Vader":
                    image = "DarthVader.png";
                    break;
                case "Palpatine":
                    image = "palpatine.png";
                    break;
                case "Darth Maul":
                    image = "darthmaul.png";
                    break;
                case "Count Dooku":
                    image = "count_dooku.png";
                    break;
                case "Asajj Ventress":
                    image = "Asajjventress.png";
                    break;
                case "Kylo Ren":
                    image = "kyloren.png";
                    break;
                default:
                    image = "grievous.png";
                    break;
            }

            return image;
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
        public static string GetMonsterDescription(string name)
        {
            string description = string.Empty;
            switch (name)
            {
                case "Darth Vader":
                    description = "A Sith Lord";
                    break;
                case "Palpatine":
                    description = "Dark architect of the Galactic Empire";
                    break;
                case "Darth Maul":
                    description = "A dangerous combatant";
                    break;
                case "Count Dooku":
                    description = "Possesses a brilliance and charisma";
                    break;
                case "Asajj Ventress":
                    description = "Slave, Nightsister, Jedi apprentice";
                    break;
                case "Kylo Ren":
                    description = "The leader of the mysterious Knights of Ren";
                    break;
                default:
                    description = "Dangerous Sith Lord";
                    break;
            }
            
            return description;
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

        /// <summary>
        /// Create Random Character for the battle
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static MonsterModel GetRandomMonster(int MaxLevel, bool Items = false)
        {
            // If there are no Monsters in the system, return a default one
            if (MonsterIndexViewModel.Instance.Dataset.Count == 0)
            {
                return new MonsterModel();
            }

            // Randomize Name
            string name = GetMonsterName();
            string description = GetMonsterDescription(name);
            string image = GetMonsterImage(name);

            var rnd = DiceHelper.RollDice(1, MonsterIndexViewModel.Instance.Dataset.Count);

            var result = new MonsterModel(MonsterIndexViewModel.Instance.Dataset.ElementAt(rnd - 1))
            {
                Level = DiceHelper.RollDice(1, MaxLevel),

                Name = name,
                Description = description,
                ImageURI = image,

                // Randomize the Attributes
                Attack = GetAbilityValue(),
                Speed = GetAbilityValue(),
                Defense = GetAbilityValue(),
                Difficulty = GetMonsterDifficultyValue()
            };

            // Adjust values based on Difficulty
            result.Attack = result.Difficulty.ToModifier(result.Attack);
            result.Defense = result.Difficulty.ToModifier(result.Defense);
            result.Speed = result.Difficulty.ToModifier(result.Speed);
            result.Level = result.Difficulty.ToModifier(result.Level);

            // Get the new Max Health
            result.MaxHealth = DiceHelper.RollDice(result.Level, 10);

            // Adjust the health, If the new Max Health is above the rule for the level, use the original
            var MaxHealthAdjusted = result.Difficulty.ToModifier(result.MaxHealth);
            if (MaxHealthAdjusted < result.Level * 10)
            {
                result.MaxHealth = MaxHealthAdjusted;
            }

            // Level up to the new level
            result.LevelUpToValue(result.Level);

            // Set ExperienceRemaining so Monsters can both use this method
            result.ExperienceRemaining = LevelTableHelper.Instance.LevelDetailsList[result.Level + 1].Experience;

            // Enter Battle at full health
            result.CurrentHealth = result.MaxHealth;

            // Monsters can have weapons too....
            if (Items)
            {
                result.Head = GetItem(ItemLocationEnum.Head);
                result.Necklass = GetItem(ItemLocationEnum.Necklass);
                result.PrimaryHand = GetItem(ItemLocationEnum.PrimaryHand);
                result.OffHand = GetItem(ItemLocationEnum.OffHand);
                result.RightFinger = GetItem(ItemLocationEnum.Finger);
                result.LeftFinger = GetItem(ItemLocationEnum.Finger);
                result.Feet = GetItem(ItemLocationEnum.Feet);
            }

            return result;
        }

        /// <summary>
        /// Get Character Random Image
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterImage()
        {
            List<String> FirstNameList = new List<String> { "yoda.png", "chewy_solo.png", "pilot.png", "r2d2.png", "luke.png", "obiwan.png", "rey.png" };

            var result = FirstNameList.ElementAt(DiceHelper.RollDice(1, FirstNameList.Count()) - 1);

            return result;
        }

        /// <summary>
        /// Get Name
        /// 
        /// Return a Random Name
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterName()
        {

            List<String> FirstNameList = new List<String> { "Yoda", "Chewy", "Hans Solo", "Rebel Pilot", "R2D2", "Luke Skywalker", "Obiwan", "Rey" };

            var result = FirstNameList.ElementAt(DiceHelper.RollDice(1, FirstNameList.Count()) - 1);

            return result;
        }

        /// <summary>
        /// Get Description
        /// 
        /// Return a random description
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterDescription()
        {
            List<String> StringList = new List<String> { "the terrible", "the awesome", "the lost", "the old", "the younger", "the quiet", "the loud", "the helpless", "the happy", "the sleepy", "the angry", "the clever" };

            var result = StringList.ElementAt(DiceHelper.RollDice(1, StringList.Count()) - 1);

            return result;
        }

        /// <summary>
        /// Create Random Character for the battle
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static CharacterModel GetRandomCharacter(int MaxLevel)
        {
            // If there are no characters in the system, return a default one
            if (CharacterIndexViewModel.Instance.Dataset.Count == 0)
            {
                return new CharacterModel();
            }

            var rnd = DiceHelper.RollDice(1, CharacterIndexViewModel.Instance.Dataset.Count);

            var result = new CharacterModel(CharacterIndexViewModel.Instance.Dataset.ElementAt(rnd - 1))
            {
                Level = DiceHelper.RollDice(1, MaxLevel),

                // Randomize Name
                Name = GetCharacterName(),
                Description = GetCharacterDescription(),

                // Randomize the Attributes
                Attack = GetAbilityValue(),
                Speed = GetAbilityValue(),
                Defense = GetAbilityValue(),

                // Randomize an Item for Location
                Head = GetItem(ItemLocationEnum.Head),
                Necklass = GetItem(ItemLocationEnum.Necklass),
                PrimaryHand = GetItem(ItemLocationEnum.PrimaryHand),
                OffHand = GetItem(ItemLocationEnum.OffHand),
                RightFinger = GetItem(ItemLocationEnum.Finger),
                LeftFinger = GetItem(ItemLocationEnum.Finger),
                Feet = GetItem(ItemLocationEnum.Feet),

                ImageURI = GetCharacterImage()
            };

            result.MaxHealth = DiceHelper.RollDice(MaxLevel, 10);

            // Level up to the new level
            result.LevelUpToValue(result.Level);

            // Enter Battle at full health
            result.CurrentHealth = result.MaxHealth;

            return result;
        }

    }
}