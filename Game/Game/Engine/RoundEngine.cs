using Game.Models;
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
    }
}
