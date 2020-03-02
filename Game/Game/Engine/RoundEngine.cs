﻿using Game.Helpers;
using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Engine
{
    /// <summary>
    /// Round Engine Class.
    /// Inherits from TurnEngine Class
    /// </summary>
    public class RoundEngine: TurnEngine
    {

        /// <summary>
        /// Clear the List between Rounds
        /// </summary>
        /// <returns></returns>
        private bool ClearLists()
        {
            ItemPool.Clear();
            MonsterList.Clear();
            return true;
        }

        /// <summary>
        /// Swap out the item if it is better
        /// 
        /// Uses Value to determine
        /// </summary>
        /// <param name="character"></param>
        /// <param name="setLocation"></param>
        public bool GetItemFromPoolIfBetter(PlayerInfoModel character, ItemLocationEnum setLocation)
        {
            var myList = ItemPool.Where(a => a.Location == setLocation)
                .OrderByDescending(a => a.Value)
                .ToList();

            // If no items in the list, return...
            if (!myList.Any())
            {
                return false;
            }

            var CharacterItem = character.GetItemByLocation(setLocation);
            if (CharacterItem == null)
            {
                // If no ItemModel in the slot then put on the first in the list
                character.AddItem(setLocation, myList.FirstOrDefault().Id);
                return true;
            }

            foreach (var PoolItem in myList)
            {
                if (PoolItem.Value > CharacterItem.Value)
                {
                    // Put on the new ItemModel, which drops the one back to the pool
                    var droppedItem = character.AddItem(setLocation, PoolItem.Id);

                    // Remove the ItemModel just put on from the pool
                    ItemPool.Remove(PoolItem);

                    if (droppedItem != null)
                    {
                        // Add the dropped ItemModel to the pool
                        ItemPool.Add(droppedItem);
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Pickup Items Dropped
        /// </summary>
        /// <param name="character"></param>
        public bool PickupItemsFromPool(PlayerInfoModel character)
        {
            // Have the character, walk the items in the pool, and decide if any are better than current one.

            GetItemFromPoolIfBetter(character, ItemLocationEnum.Head);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.Necklass);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.PrimaryHand);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.OffHand);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.RightFinger);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.LeftFinger);
            GetItemFromPoolIfBetter(character, ItemLocationEnum.Feet);

            return true;
        }

        /// <summary>
        /// At the end of the round
        /// Clear the ItemModel List
        /// Clear the MonsterModel List
        /// </summary>
        /// <returns></returns>
        public bool EndRound()
        {
            // Have each character pickup items...
            foreach (var character in CharacterList)
            {
                PickupItemsFromPool(character);
            }

            // Reset Monster and Item Lists
            ClearLists();

            return true;
        }


        /// <summary>
        /// Add Monsters to the Round
        /// 
        /// Because Monsters can be duplicated, will add 1, 2, 3 to their name
        ///   
        /*
            * Hint: 
            * I don't have crudi monsters yet so will add 6 new ones...
            * If you have crudi monsters, then pick from the list

            * Consdier how you will scale the monsters up to be appropriate for the characters to fight
            */
        /// </summary>
        /// <returns></returns>
        public int AddMonstersToRound()
        {
            //  no need to add more if monster list s full
            if (MonsterList.Count() >= MaxNumberPartyMonsters)
            {
                return 0;
            }

            var myMonsterViewModel = MonsterIndexViewModel.Instance;
            if (myMonsterViewModel.Dataset.Count() > 0)
            {
                // Scale monsters within the range of the Characters

                var ScaleLevelMax = 1;
                var ScaleLevelMin = 1;
                var ScaleLevelAverage = 1;

                if (CharacterList.Any())
                {
                    ScaleLevelMax = GetMaxCharacterLevel();
                    ScaleLevelMin = GetMinCharacterLevel();
                    ScaleLevelAverage = GetAverageCharacterLevel();
                }

                do
                {
                    var rnd = DiceHelper.RollDice(1, MonsterIndexViewModel.Instance.Dataset.Count);
                    {
                        var monster = new MonsterModel(myMonsterViewModel.Dataset[rnd - 1]);

                        // Identify which monster it is...
                        monster.Name += " " + (1 + MonsterList.Count()).ToString();

                        // Scale the monster to be between the average level of the characters+1
                        var rndScale = DiceHelper.RollDice(1, ScaleLevelAverage + 1);
                        var item = new PlayerInfoModel(monster);
                        item.LevelUpToValue(rndScale);
                        MonsterList.Add(item);
                    }

                } while (MonsterList.Count() < MaxNumberPartyMonsters);
            }
            else
            {
                // If no monsters in DB, add 6 new ones...
                for (var i = 0; i < MaxNumberPartyMonsters; i++)
                {
                    var item = new MonsterModel();
                    item.Name += " " + MonsterList.Count() + 1;
                    MonsterList.Add(new PlayerInfoModel(item));
                }
            }

            return MonsterList.Count();
        }

        /// <summary>
        /// Will return the Min, Max, Average for the Characters in the party
        /// So the monster can get scaled to the appropraite level
        /// </summary>
        /// <returns></returns>
        public int GetAverageCharacterLevel()
        {
            var data = CharacterList.Average(m => m.Level);
            return (int)Math.Floor(data);
        }

        /// <summary>
        /// Will return the Min, Max, Average for the Characters in the party
        /// So the monster can get scaled to the appropraite level
        /// </summary>
        /// <returns></returns>
        public int GetMinCharacterLevel()
        {
            var data = CharacterList.Min(m => m.Level);
            return data;
        }

        /// <summary>
        /// Will return the Min, Max, Average for the Characters in the party
        /// So the monster can get scaled to the appropraite level
        /// </summary>
        /// <returns></returns>
        public int GetMaxCharacterLevel()
        {
            var data = CharacterList.Max(m => m.Level);
            return data;
        }

        /// <summary>
        /// Who is Playing this round?
        /// </summary>
        public List<PlayerInfoModel> MakePlayerList()
        {
            // Start from a clean list of players
            PlayerList.Clear();

            // Remeber the Insert order, used for Sorting
            var ListOrder = 0;

            foreach (var data in CharacterList)
            {
                if (data.Alive)
                {
                    PlayerList.Add(
                        new PlayerInfoModel(data)
                        {
                            // Remember the order
                            ListOrder = ListOrder
                        });

                    ListOrder++;
                }
            }

            foreach (var data in MonsterList)
            {
                if (data.Alive)
                {
                    PlayerList.Add(
                        new PlayerInfoModel(data)
                        {
                            // Remember the order
                            ListOrder = ListOrder
                        });

                    ListOrder++;
                }
            }

            return PlayerList;
        }


        // Call to make a new set of monsters...
        public bool NewRound()
        {
            // End the existing round
            EndRound();

            // Populate New Monsters...
            AddMonstersToRound();

            // Make the PlayerList
            MakePlayerList();

            // Update Score for the RoundCount
            BattleScore.RoundCount++;

            return true;
        }

        /// <summary>
        /// Get the Information about the Player
        /// </summary>
        /// <returns></returns>
        public PlayerInfoModel GetNextPlayerInList()
        {
            // Walk the list from top to bottom
            // If Player is found, then see if next player exist, if so return that.
            // If not, return first player (looped)

            // If List is empty, return null
            if (PlayerList.Count == 0)
            {
                return null;
            }

            // No current player, so set the first one
            if (PlayerCurrent == null)
            {
                return PlayerList.FirstOrDefault();
            }

            // Find current player in the list
            var index = PlayerList.FindIndex(m => m.Guid.Equals(PlayerCurrent.Guid));

            // If at the end of the list, return the first element
            if (index == PlayerList.Count() - 1)
            {
                return PlayerList.FirstOrDefault();
            }

            // Return the next element
            return PlayerList[index + 1];

            
        }

        /// <summary>
        /// Order the Players in Turn Sequence
        /// </summary>
        public List<PlayerInfoModel> OrderPlayerListByTurnOrder()
        {
            // Order is based by... 
            // Order by Speed (Desending)
            // Then by Highest level (Descending)
            // Then by Highest Experience Points (Descending)
            // Then by Character before MonsterModel (enum assending)
            // Then by Alphabetic on Name (Assending)
            // Then by First in list order (Assending

            // Work with the Class variable PlayerList
            PlayerList = MakePlayerList();

            PlayerList = PlayerList.OrderByDescending(a => a.GetSpeed())
                .ThenByDescending(a => a.Level)
                .ThenByDescending(a => a.ExperiencePoints)
                .ThenByDescending(a => a.PlayerType)
                .ThenBy(a => a.Name)
                .ThenBy(a => a.ListOrder)
                .ToList();

            return PlayerList;
        }


        /// <summary>
        /// Manage Next Turn
        /// 
        /// Decides Who's Turn
        /// Remembers Current Player
        /// 
        /// Starts the Turn
        /// 
        /// </summary>
        /// <returns></returns>
        public RoundEnum RoundNextTurn()
        {
            // No characters, game is over...
            if (CharacterList.Count < 1)
            {
                // Game Over
                RoundStateEnum = RoundEnum.GameOver;
                return RoundStateEnum;
            }

            // Check if round is over
            if (MonsterList.Count < 1)
            {
                // If over, New Round
                RoundStateEnum = RoundEnum.NewRound;
                return RoundEnum.NewRound;
            }

            // Decide Who gets next turn
            // Remember who just went...
            PlayerCurrent = GetNextPlayerTurn();

            // Do the turn....
            TakeTurn(PlayerCurrent);

            RoundStateEnum = RoundEnum.NextTurn;

            return RoundStateEnum;
        }

        /// <summary>
        /// Get the Next Player to have a turn
        /// </summary>
        /// <returns></returns>
        public PlayerInfoModel GetNextPlayerTurn()
        {
            // Recalculate Order
            OrderPlayerListByTurnOrder();

            // Get Next Player
            var PlayerCurrent = GetNextPlayerInList();

            return PlayerCurrent;
        }


    }
}
