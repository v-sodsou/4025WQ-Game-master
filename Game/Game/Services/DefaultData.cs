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
                    ImageURI = "https://cdn.webshopapp.com/shops/209525/files/309648135/funko-pop-star-wars-307-rey.jpg"
                },

                new Character {
                    Name = "Luke",
                    Description = "An incredible Jedi",
                    ImageURI = "https://images-na.ssl-images-amazon.com/images/I/51-B25E3vTL._AC_SY450_.jpg"
                },

                new Character {
                    Name = "Finn",
                    Description = "Force sensitive stormtrooper",
                    ImageURI = "https://cdn10.bigcommerce.com/s-2znav/products/1463/images/4353/Finn_75176_with_blaster__82235.1554907493.1280.1280.jpg?c=2"
                },

                new Character {
                    Name = "Ahsoka Tano",
                    Description = "A Togruta Jedi Padawan",
                    ImageURI = "https://mygenerationtoys.com/images/Star%20Wars%20Galactic%20Heroes%20Ahsoka%20Tano.jpg"
                },

                new Character {
                    Name = "Chewbacca",
                    Description = "A tall, hirsute, and intelligent species",
                    ImageURI = "https://www.toysrus.ca/dw/image/v2/BDFX_PRD/on/demandware.static/-/Sites-toys-master-catalog/default/dwcda6d643/images/AFABDCFC_1.jpg?sw=767&sh=767&sm=fit"
                },

                new Character {
                    Name = "Obi-Wan Kenobi",
                    Description = "A legendary Jedi Master",
                    ImageURI = "https://images-na.ssl-images-amazon.com/images/I/51X10mZk4ML._AC_SL1082_.jpg"
                }
            };

            return datalist;
        }
    }
}