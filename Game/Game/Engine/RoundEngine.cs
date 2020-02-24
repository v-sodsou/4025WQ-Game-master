﻿using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Engine
{
    class RoundEngine: TurnEngine
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
            for (var i = 0; i < MaxNumberPartyMonsters; i++)
            {
                var data = new MonsterModel();
                // Help identify which Monster it is
                data.Name += " " + MonsterList.Count() + 1;
                MonsterList.Add(new PlayerInfoModel(data));
            }

            return MonsterList.Count();
        }
    }
}
