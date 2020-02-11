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
                    Name = "Gold Sword",
                    Description = "Sword made of Gold, really expensive looking",
                    ImageURI = "http://www.clker.com/cliparts/e/L/A/m/I/c/sword-md.png",
                    Range = 0,
                    Damage = 9,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Strong Shield",
                    Description = "Enough to hide behind",
                    ImageURI = "http://www.clipartbest.com/cliparts/4T9/LaR/4T9LaReTE.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Bunny Hat",
                    Description = "Pink hat with fluffy ears",
                    ImageURI = "http://www.clipartbest.com/cliparts/yik/e9k/yike9kMyT.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Speed},
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

        public static List<Character> LoadData(Character temp)
        {
            var datalist = new List<Character>()
            {
                new Character {
                    Name = "Princess Leia",
                    Description = "Member of the Imperial Senate",
                    ImageURI = "rey.jpg"
                },

                new Character {
                    Name = "Luke",
                    Description = "An incredible Jedi",
                    ImageURI = "luke.jpg"
                },

                new Character {
                    Name = "Finn",
                    Description = "Force sensitive stormtrooper",
                    ImageURI = "finn.jpg"
                },

                new Character {
                    Name = "Ahsoka Tano",
                    Description = "A Togruta Jedi Padawan",
                    ImageURI = "tano.jpg"
                },

                new Character {
                    Name = "Chewbacca",
                    Description = "A tall, hirsute, and intelligent species",
                    ImageURI = "chewbacca.jpg"
                },

                new Character {
                    Name = "Obi-Wan Kenobi",
                    Description = "A legendary Jedi Master",
                    ImageURI = "obiwan.png"
                }
            };

            return datalist;
        }
    }
}