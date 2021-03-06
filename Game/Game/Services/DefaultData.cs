﻿using Game.Models;
using System.Collections.Generic;

namespace Game.Services
{
    /// <summary>
    /// DefaultData
    /// </summary>
    public static class DefaultData
    {
        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public static List<ItemModel> LoadData(ItemModel temp)
        {
            var datalist = new List<ItemModel>()
            {
                new ItemModel {
                    Name = "Blue Lightsaber",
                    Description = "Jedi weapon, only Jedi's can use it.",
                    ImageURI = "Saber.png",
                    Range = 9,
                    Damage = 9,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "black Blaster",
                    Description = "Shoots Powerful blasts of Proton energy!",
                    ImageURI = "Gun.png",
                    Range = 6,
                    Damage = 5,
                    Value = 7,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Blaster proof Helmet",
                    Description = "Personal Helmet - Protects against attacks.",
                    ImageURI = "Shield.png",
                    Range = 0,
                    Damage = 0,
                    Value = 8,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Umbrella",
                    Description = "Provides Supersonic Speed",
                    ImageURI = "umbrella.png",
                    Range = 0,
                    Damage = 0,
                    Value = 7,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Power Shield",
                    Description = "Increases Defense by Absorbing all Types of Blasts.",
                    ImageURI = "power_shield_png.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Thermal Detonator",
                    Description = "BLows up anything on its radio of blast.",
                    ImageURI = "Detonator1.png",
                    Range = 8,
                    Damage = 6,
                    Value = 8,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Red Saber",
                    Description = "Special Energy Red Saber",
                    ImageURI = "RedSaber.png",
                    Range = 6,
                    Damage = 4,
                    Value = 7,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack},
            };

            return datalist;
        }

        /// <summary>
        /// Load Data Argument ScoreModel
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<ScoreModel> LoadData(ScoreModel temp)
        {
            var datalist = new List<ScoreModel>()
            {
                new ScoreModel {
                    Name = "TheBestGmr's Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Sc0rpi0n's Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "LegoMaster's Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "MonstaKilla's Score",
                    Description = "Test Data",
                },
                
                new ScoreModel {
                    Name = "Overkill's Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "SimplyDaBst's Score",
                    Description = "Test Data",
                }
            };

            return datalist;
        }

        /// <summary>
        /// Load Data Argument CharacterModel
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<CharacterModel> LoadData(CharacterModel temp)
        {
            var datalist = new List<CharacterModel>()
            {
                new CharacterModel {
                    Name = "Rey",
                    Description = "New Jedi",
                    ImageURI = "rey.png",
                    HasForce = false,
                    Attack = 3,
                    Defense = 5,
                    Speed = 4,
                    CurrentHealth = 25,
                    MaxHealth = 25
        },

                new CharacterModel {
                    Name = "Luke",
                    Description = "An incredible Jedi",
                    ImageURI = "luke.png",
                    HasForce = true,
                    Attack = 6,
                    Defense = 6,
                    Speed = 8,
                    CurrentHealth = 20,
                    MaxHealth = 20
                },

                new CharacterModel {
                    Name = "Finn",
                    Description = "Force sensitive stormtrooper",
                    ImageURI = "finn.png",
                    HasForce = false,
                    Attack = 3,
                    Defense = 3,
                    Speed = 4,
                    CurrentHealth = 7,
                    MaxHealth = 7
                },

                new CharacterModel {
                    Name = "Ahsoka Tano",
                    Description = "A Togruta Jedi Padawan",
                    ImageURI = "ahsoka.png",
                    HasForce = false,
                    Attack = 3,
                    Defense = 5,
                    Speed = 4,
                    CurrentHealth = 10,
                    MaxHealth = 10
                },

                new CharacterModel {
                    Name = "Chewbacca & Solo",
                    Description = "Great duo fighter with incredible skills",
                    ImageURI = "chewy_solo.png",
                    HasForce = false,
                    Attack = 8,
                    Defense = 8,
                    Speed = 2,
                    CurrentHealth = 15,
                    MaxHealth = 15
                },

                new CharacterModel {
                    Name = "Obi-Wan Kenobi",
                    Description = "A legendary Jedi Master",
                    ImageURI = "obiwan.png",
                    HasForce = true,
                    Attack = 8,
                    Defense = 5,
                    Speed = 4,
                    CurrentHealth = 31,
                    MaxHealth = 31
                }
            };

            return datalist;
        }

        /// <summary>
        /// Load Data Argument MonsterModel
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<MonsterModel> LoadData(MonsterModel temp)
        {
            var datalist = new List<MonsterModel>()
            {
                new MonsterModel {
                    Name = "Darth Vader",
                    Description = "A Sith Lord",
                    ImageURI = "DarthVader.png"
                },

                new MonsterModel {
                    Name = "Palpatine",
                    Description = "Dark architect of the Galactic Empire",
                    ImageURI = "palpatine.png"
                },

                new MonsterModel {
                    Name = "Darth Maul",
                    Description = "A dangerous combatant",
                    ImageURI = "darthmaul.png"
                },

                new MonsterModel {
                    Name = "Count Dooku",
                    Description = "Possesses a brilliance and charisma",
                    ImageURI = "count_dooku.png"
                },

                new MonsterModel {
                    Name = "Asajj Ventress",
                    Description = "Slave, Nightsister, Jedi apprentice",
                    ImageURI = "Asajjventress.png"
                },

                new MonsterModel {
                    Name = "Kylo Ren",
                    Description = "The leader of the mysterious Knights of Ren",
                    ImageURI = "kyloren.png"
                }
            };

            return datalist;
        }
    }
}