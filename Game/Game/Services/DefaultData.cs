using Game.Models;
using System.Collections.Generic;

namespace Game.Services
{
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
                    ImageURI = "lightblue_lightsaber.jpg",
                    Range = 9,
                    Damage = 9,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "black Blaster",
                    Description = "Shoots Powerful blasts of Proton energy!",
                    ImageURI = "black_blaster.jpg",
                    Range = 6,
                    Damage = 5,
                    Value = 7,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Personal Shield",
                    Description = "Personal Shield Generator - Protects against attacks.",
                    ImageURI = "personal_shield.jpg",
                    Range = 0,
                    Damage = 0,
                    Value = 8,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Umbrella",
                    Description = "Provides Supersonic Speed",
                    ImageURI = "umbrella.jpg",
                    Range = 0,
                    Damage = 0,
                    Value = 7,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Power Shield",
                    Description = "Increases Defense by Absorbing all Types of Blasts.",
                    ImageURI = "power_shield.jpeg",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Thermal Detonator",
                    Description = "BLows up anything on its radio of blast.",
                    ImageURI = "thermal_detonator.jpg",
                    Range = 8,
                    Damage = 6,
                    Value = 8,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Bowcaster",
                    Description = "Shoots Special Energy Beam Arrows",
                    ImageURI = "wookie_bowcaster.jpg",
                    Range = 6,
                    Damage = 4,
                    Value = 7,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack},
            };

            return datalist;
        }

        public static List<ScoreModel> LoadData(ScoreModel temp)
        {
            var datalist = new List<ScoreModel>()
            {
                new ScoreModel {
                    Name = "First Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Second Score",
                    Description = "Test Data",
                }
            };

            return datalist;
        }

        public static List<CharacterModel> LoadData(CharacterModel temp)
        {
            var datalist = new List<CharacterModel>()
            {
                new CharacterModel {
                    Name = "Princess Leia",
                    Description = "Member of the Imperial Senate",
                    ImageURI = "rey.jpg",
                    HasForce = false,
                    Attack = 3,
                    Defense = 5,
                    Speed = 4,
                    CurrentHealth = 8,
                    MaxHealth = 9
        },

                new CharacterModel {
                    Name = "Luke",
                    Description = "An incredible Jedi",
                    ImageURI = "luke.jpg",
                    HasForce = true,
                    Attack = 6,
                    Defense = 6,
                    Speed = 8,
                    CurrentHealth = 7,
                    MaxHealth = 9
                },

                new CharacterModel {
                    Name = "Finn",
                    Description = "Force sensitive stormtrooper",
                    ImageURI = "finn.jpg",
                    HasForce = false,
                    Attack = 3,
                    Defense = 3,
                    Speed = 4,
                    CurrentHealth = 6,
                    MaxHealth = 7
                },

                new CharacterModel {
                    Name = "Ahsoka Tano",
                    Description = "A Togruta Jedi Padawan",
                    ImageURI = "tano.jpg",
                    HasForce = false,
                    Attack = 3,
                    Defense = 5,
                    Speed = 4,
                    CurrentHealth = 7,
                    MaxHealth = 9
                },

                new CharacterModel {
                    Name = "Chewbacca",
                    Description = "A tall, hirsute, and intelligent species",
                    ImageURI = "chewbacca.jpg",
                    HasForce = false,
                    Attack = 8,
                    Defense = 8,
                    Speed = 2,
                    CurrentHealth = 8,
                    MaxHealth = 9
                },

                new CharacterModel {
                    Name = "Obi-Wan Kenobi",
                    Description = "A legendary Jedi Master",
                    ImageURI = "obiwan.png",
                    HasForce = true,
                    Attack = 8,
                    Defense = 5,
                    Speed = 4,
                    CurrentHealth = 8,
                    MaxHealth = 9
                }
            };

            return datalist;
        }

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