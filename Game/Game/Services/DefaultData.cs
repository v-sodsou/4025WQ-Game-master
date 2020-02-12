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

        public static List<Monster> LoadData(Monster temp)
        {
            var datalist = new List<Monster>()
            {
                new Monster {
                    Name = "Darth Vader",
                    Description = "A Sith Lord",
                    ImageURI = "https://asset.swarovski.com/images/$size_500/t_swa101/t_swa103/b_rgb:fafafa%2Cc_scale%2Cdpr_auto%2Cf_auto%2Cw_auto/5379499_png/star-wars---darth-vader-swarovski-5379499.png"
                },

                new Monster {
                    Name = "Palpatine",
                    Description = "Dark architect of the Galactic Empire",
                    ImageURI = "https://vignette.wikia.nocookie.net/legostarwars/images/3/3a/Palpatine-2010.jpg/revision/latest?cb=20130508042046"
                },

                new Monster {
                    Name = "Darth Maul",
                    Description = "A dangerous combatant",
                    ImageURI = "https://cdn11.bigcommerce.com/s-0kvv9/images/stencil/1280x1280/products/267953/373898/legomaulsilverneckclasp__32262.1533582731.jpg?c=2&imbypass=on"
                },

                new Monster {
                    Name = "Count Dooku",
                    Description = "Possesses a brilliance and charisma",
                    ImageURI = "https://vignette.wikia.nocookie.net/lego/images/b/b6/COUNT_DOOKU.jpg/revision/latest/scale-to-width-down/340?cb=20121209122119"
                },

                new Monster {
                    Name = "Asajj Ventress",
                    Description = "Slave, Nightsister, Jedi apprentice",
                    ImageURI = "https://i5.walmartimages.com/asr/ac68cc88-27f4-45d5-8c2e-80c1bca1eaea_1.1b21820c39305147ce46939cac56a37b.jpeg?odnWidth=450&odnHeight=450&odnBg=ffffff"
                },

                new Monster {
                    Name = "Kylo Ren",
                    Description = "The leader of the mysterious Knights of Ren",
                    ImageURI = "https://i5.walmartimages.com/asr/c04b2f2d-8c50-4389-9171-6c4430168b0f_1.355f2607f02a8a7138583db341ddfd5a.jpeg?odnWidth=450&odnHeight=450&odnBg=ffffff"
                }
            };

            return datalist;
        }
    }
}