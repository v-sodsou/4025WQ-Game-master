﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Game.ViewModels;
using Game.Helpers;
using System.Diagnostics;
using Game.Models;

namespace Game.Models
{
    /// <summary>
    /// Player Model Base Class from which players will inherit
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BasePlayerModel<T>: BaseModel<T>
    {
        #region Attributes

        #region GameEngineAttributes
        // alive status, !alive will be removed from the list
        [Ignore]
        public bool Alive { get; set; } = true;

        // The type of player, character comes before monster
        [Ignore]
        public PlayerTypeEnum PlayerType { get; set; } = PlayerTypeEnum.Unknown;

        // TurnOrder
        [Ignore]
        public int Order { get; set; } = 0;

        // Remember who was first into the list...
        [Ignore]
        public int ListOrder { get; set; } = 0;

        #endregion GameEngineAttributes

        #region PlayerAttributes

        // The Dice to use when leveling up, default is d10
        public int HealthDice { get; set; } = 10;

        // Level of character or monster
        public int Level { get; set; } = 1;

        // The experience points the player has used in sorting ties...
        public int ExperiencePoints { get; set; } = 0;

        // Current Health
        public int CurrentHealth { get; set; } = 0;

        // Max Health
        public int MaxHealth { get; set; } = 0;

        // Total Experience
        public int ExperienceTotal { get; set; } = 0;

        // Total speed, including level and items
        public int Speed { get; set; } = 0;

        // The defense score, to be used for defending against attacks
        public int Defense { get; set; } = 0;

        // The Attack score to be used when attacking
        public int Attack { get; set; } = 0;

        // The Difficulty level
        public DifficultyEnum Difficulty { get; set; } = DifficultyEnum.Unknown;

        // The Experience available to given up
        public int ExperienceRemaining { get; set; }

        // The natural range for this Player, 1 is normal
        public int Range { get; set; } = 1;

        // Add to Health
        [Ignore]
        public int BuffHealthValue { get; set; } = 0;

        // Add to Attack
        [Ignore]
        public int BuffAttackValue { get; set; } = 0;

        // Add to defense
        [Ignore]
        public int BuffDefenseValue { get; set; } = 0;

        // Add to Speed
        [Ignore]
        public int BuffSpeedValue { get; set; } = 0;

        // The Job for the Player
        public CharacterJobEnum Job { get; set; } = CharacterJobEnum.Unknown;


        #endregion PlayerAttributes

        #endregion Attributes

        #region Items
        // ItemModel is a string referencing the database table
        public string Head { get; set; } = null;

        // Feet is a string referencing the database table
        public string Feet { get; set; } = null;

        // Necklasss is a string referencing the database table
        public string Necklass { get; set; } = null;

        // PrimaryHand is a string referencing the database table
        public string PrimaryHand { get; set; } = null;

        // Offhand is a string referencing the database table
        public string OffHand { get; set; } = null;

        // RightFinger is a string referencing the database table
        public string RightFinger { get; set; } = null;

        // LeftFinger is a string referencing the database table
        public string LeftFinger { get; set; } = null;

        // alive status, !alive will be removed from the list
        [Ignore]
        public bool HasForce { get; set; } = false;

        // Unique Drop Item for Monsters
        public string UniqueItem { get; set; } = null;
        #endregion Items

        #region AttributeDisplay

        // Following returns the values for each of the attributes with the modifiers

        #region Attack        
        [Ignore]
        // Return the attack value
        public int GetAttackLevelBonus { get { return LevelTableHelper.Instance.LevelDetailsList[Level].Attack; } }

        [Ignore]
        // Return the Attack with Item Bonus
        public int GetAttackItemBonus { get { return GetItemBonus(AttributeEnum.Attack); } }

        [Ignore]
        // Return the Total of All Attack
        public int GetAttackTotal { get { return GetAttack(); } }
        #endregion Attack

        #region Defense
        [Ignore]
        // Return the Defense value
        public int GetDefenseLevelBonus { get { return LevelTableHelper.Instance.LevelDetailsList[Level].Defense; } }

        [Ignore]
        // Return the Defense with Item Bonus
        public int GetDefenseItemBonus { get { return GetItemBonus(AttributeEnum.Defense); } }

        [Ignore]
        // Return the Total of All Defense
        public int GetDefenseTotal { get { return GetDefense(); } }
        #endregion Defense

        #region Speed
        [Ignore]
        // Return the Speed value
        public int GetSpeedLevelBonus { get { return LevelTableHelper.Instance.LevelDetailsList[Level].Speed; } }

        [Ignore]
        // Return the Speed with Item Bonus
        public int GetSpeedItemBonus { get { return GetItemBonus(AttributeEnum.Speed); } }

        [Ignore]
        // Return the Total of All Speed
        public int GetSpeedTotal { get { return GetSpeed(); } }
        #endregion Speed

        #region CurrentHealth
        [Ignore]
        // Return the CurrentHealth value
        public int GetCurrentHealthLevelBonus { get { return 0; } }

        [Ignore]
        // Return the CurrentHealth with Item Bonus
        public int GetCurrentHealthItemBonus { get { return GetItemBonus(AttributeEnum.CurrentHealth); } }

        [Ignore]
        // Return the Total of All CurrentHealth
        public int GetCurrentHealthTotal { get { return GetCurrentHealth(); } }
        #endregion CurrentHealth

        #region MaxHealth
        [Ignore]
        // Return the MaxHealth value
        public int GetMaxHealthLevelBonus { get { return 0; } }

        [Ignore]
        // Return the MaxHealth with Item Bonus
        public int GetMaxHealthItemBonus { get { return GetItemBonus(AttributeEnum.MaxHealth); } }

        [Ignore]
        // Return the Total of All MaxHealth
        public int GetMaxHealthTotal { get { return GetMaxHealth(); } }
        #endregion MaxHealth

        #region Damage
        [Ignore]
        // Return the Damage value, it is 25% of the Level rounded up
        public int GetDamageLevelBonus { get { return Convert.ToInt32(Math.Ceiling(Level * .25)); } }

        [Ignore]
        // Return the Damage with Item Bonus
        public int GetDamageItemBonus
        {
            get
            {
                var myItem = ItemIndexViewModel.Instance.GetItem(PrimaryHand);
                if (myItem == null)
                {
                    return 0;
                }
                return myItem.Damage;
            }
        }

        [Ignore]
        // Return the Damage Dice if there is one
        public string GetDamageItemBonusString
        {
            get
            {
                var data = GetDamageItemBonus;
                if (data == 0)
                {
                    return "-";
                }

                return string.Format("1D {0}", data);
            }
        }

        [Ignore]
        // Return the Total of All Damage
        public string GetDamageTotalString
        {
            get
            {

                if (GetDamageItemBonusString.Equals("-"))
                {
                    return GetDamageLevelBonus.ToString();
                }

                return GetDamageLevelBonus.ToString() + " + " + GetDamageItemBonusString;

            }
        }
        #endregion Damage

        #endregion AttributeDisplay

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        public BasePlayerModel()
        {
            Guid = Id;
        }

        /// <summary>
        /// Sets the Level to Scale Up to
        /// </summary>
        /// <param name="level">The New Level</param>
        /// <returns>True if New Level Occurs</returns>
        public bool LevelUpToValue(int level)
        {
            // No need of changing if level < 1
            if (level < 1)
            {
                return false;
            }

            // Don't go down in level...
            if (level < this.Level)
            {
                return false;
            }

            // Level > Max Level
            if (level > 20)
            {
                return false;
            }

            // Calculate Experience Remaining 
            Level = level;

            ExperienceTotal = LevelTableHelper.Instance.LevelDetailsList[Level + 1].Experience;

            Attack = LevelTableHelper.Instance.LevelDetailsList[Level].Attack;
            Defense = LevelTableHelper.Instance.LevelDetailsList[Level].Defense;
            Speed = LevelTableHelper.Instance.LevelDetailsList[Level].Speed;

            MaxHealth = DiceHelper.RollDice(Level, HealthDice);
            CurrentHealth = MaxHealth;

            return true;
        }

        // Level Up
        public void LevelUp()
        {
            // Start the Level Table in descending order
            for (var i = LevelTableHelper.Instance.LevelDetailsList.Count - 1; i > 0; i--)
            {
        
                // If the Level is > Experience for the Index, increment the Level.
                if (LevelTableHelper.Instance.LevelDetailsList[i].Experience <= ExperienceTotal)
                {
                    var NewLevel = LevelTableHelper.Instance.LevelDetailsList[i].Level;

                    // When leveling up, the current health is adjusted up by an offset of the MaxHealth, rather than full restore
                    var OldCurrentHealth = CurrentHealth;
                    var OldMaxHealth = MaxHealth;

                    // Calculate max Health addition
                    // New health, is d10 of the new level.  So leveling up 1 level is 1 d10, leveling up 2 levels is 2 d10.
                    var MaxHealthAddition = DiceHelper.RollDice(NewLevel - Level, 10);

                    // Increment Max health
                    MaxHealth += MaxHealthAddition;

                    CurrentHealth = (MaxHealth - (OldMaxHealth - OldCurrentHealth));

                    // Set the new level
                    Level = NewLevel;
                }
            }

           
        }

        /// <summary>
        /// Return the Range for the Attack Distance
        /// </summary>
        /// <returns></returns>
        public int GetRange()
        {
            // Base Attack
            var myReturn = Range;

            // Get Attack bonus from Items
            myReturn += GetItemRange();

            return myReturn;
        }

        // Add experience
        public bool AddExperience(int newExperience)
        {
           
            // newexperience cannot be lower than 0
            if (newExperience < 0)
            {
                return false;
            }

            // increment the experience
            ExperienceTotal += newExperience;

            // can't level up more than max.
            if (Level >= 20)
            {
                return false;
            }

            // if experience is higher than the experience at the next level, level up.
            if (ExperienceTotal >= LevelTableHelper.Instance.LevelDetailsList[Level + 1].Experience)
            {
                LevelUp();
            }
            return true;
        }

        #region GetAttributeValues
        /// <summary>
        /// Return the Total Attack Value
        /// </summary>
        /// <returns></returns>
        public int GetAttack()
        {
            // Base Attack
            var myReturn = Attack;

            // Attack Bonus from Level
            myReturn += GetAttackLevelBonus;

            // Get Attack bonus from Items
            myReturn += GetAttackItemBonus;

            return myReturn;
        }

        /// <summary>
        /// Return the Total Defense Value
        /// </summary>
        /// <returns></returns>
        public int GetDefense()
        {
            // Base Defense
            var myReturn = Defense;

            // Defense Bonus from Level
            myReturn += GetDefenseLevelBonus;

            // Get Defense bonus from Items
            myReturn += GetDefenseItemBonus;

            return myReturn;
        }

        /// <summary>
        /// Return the Total Speed Value
        /// </summary>
        /// <returns></returns>
        public int GetSpeed()
        {
            // Base Speed
            var myReturn = Speed;

            // Speed Bonus from Level
            myReturn += GetSpeedLevelBonus;

            // Get Speed bonus from Items
            myReturn += GetSpeedItemBonus;

            if(HasForce)
            {
                myReturn += 5;
            }

            return myReturn;
        }

        /// <summary>
        /// Return the Total CurrentHealth Value
        /// </summary>
        /// <returns></returns>
        public int GetCurrentHealth()
        {
            // Base CurrentHealth
            var myReturn = CurrentHealth;

            // CurrentHealth Bonus from Level
            myReturn += GetCurrentHealthLevelBonus;

            // Get CurrentHealth bonus from Items
            myReturn += GetCurrentHealthItemBonus;

            return myReturn;
        }

        /// <summary>
        /// Return the Total MaxHealth Value
        /// </summary>
        /// <returns></returns>
        public int GetMaxHealth()
        {
            // Base MaxHealth
            var myReturn = MaxHealth;

            // MaxHealth Bonus from Level
            myReturn += GetMaxHealthLevelBonus;

            // Get MaxHealth bonus from Items
            myReturn += GetMaxHealthItemBonus;

            return myReturn;
        }
        #endregion GetAttributeValues

        // Take Damage
        // If the damage recived, is > health, then death occurs
        // Return the number of experience received for this attack 
        // monsters give experience to characters.  Characters don't accept expereince from monsters
        public bool TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                return false;
            }

            CurrentHealth = CurrentHealth - damage;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;

                // Death...
                CauseDeath();
            }

            return true;
        }

        /// <summary>
        /// Roll the Damage Dice, and add to the Damage
        /// </summary>
        /// <returns></returns>
        public int GetDamageRollValue()
        {
            var myReturn = 0;

            var myItem = ItemIndexViewModel.Instance.GetItem(PrimaryHand);
            if (myItem != null)
            {
                // Dice of the weapon.  So sword of Damage 10 is d10
                myReturn += DiceHelper.RollDice(1, myItem.Damage);
            }

            // Add in the Level as extra damage per game rules
            myReturn += GetDamageLevelBonus;

            return myReturn;
        }

        // Death
        // Alive turns to False
        /*public virtual bool CauseDeath()
        {
            Alive = false;
            return Alive;
        }*/

        [Ignore]
        // Revive characters from death using select toggles
        public int Revived { get; set; } = 1;

        public bool oneTimeBattle = true;

        /// <summary>
        /// Causes death by setting Alive property to false;
        /// If Miracle Max Enable, character can be resurrected
        /// </summary>
        /// 

        public bool CauseDeath()
        {
            Alive = false;

            if (CharacterModel.EnableHackathon9 && oneTimeBattle && (int)this.PlayerType == 1)
            {
                oneTimeBattle = false;
                if (Revived > 0)
                {
                    Revived--;
                    CurrentHealth = MaxHealth;
                    Alive = true;
                    return Alive;

                }
            }
            return Alive;
        }

            public string FormatOutput() {
            var result = Name + " , " +
                         "Type: " + PlayerType + ", " +
                         "Alive: " + Alive + ", " +
                         "Level: " + Level + ", " +
                         "Experience: " + ExperienceTotal + ", " +
                         "Speed: " + Speed + ", " +
                         "Defense: " + Defense + ", " +
                         "Attack: " + Attack + ", " +
                         "Current Health: " + CurrentHealth + ", " +
                         "Max Health: " + MaxHealth;

            return result.Trim(); 
        }

        /// <summary>
        /// Calculate The amount of Experience to give
        /// Reduce the remaining by what was given
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public int CalculateExperienceEarned(int damage)
        {
            if (damage < 1)
            {
                return 0;
            }

            int remainingHealth = Math.Max(CurrentHealth - damage, 0); // Go to 0 is OK...
            double rawPercent = (double)remainingHealth / (double)CurrentHealth;
            double deltaPercent = 1 - rawPercent;
            var pointsAllocate = (int)Math.Floor(ExperienceRemaining * deltaPercent);

            // Catch rounding of low values, and force to 1.
            if (pointsAllocate < 1)
            {
                pointsAllocate = 1;
            }

            // Take away the points from remaining experience
            ExperienceRemaining -= pointsAllocate;
            if (ExperienceRemaining < 0)
            {
                pointsAllocate = 1;
            }

            return pointsAllocate;
        }


        #region Items
        // Get the Item at a known string location (head, foot etc.)
        public ItemModel GetItem(string itemString)
        {
            return ItemIndexViewModel.Instance.GetItem(itemString);
        }

        // Drop All Items
        // Return a list of items for the pool of items
        public List<ItemModel> DropAllItems()
        {
            var myReturn = new List<ItemModel>();

            // Drop all Items
            ItemModel myItem;

            // Remove Item from Head
            myItem = RemoveItem(ItemLocationEnum.Head);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            // Remove Item from Neckless
            myItem = RemoveItem(ItemLocationEnum.Necklass);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            // Remove Item from Primary Hand
            myItem = RemoveItem(ItemLocationEnum.PrimaryHand);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            // Remove Item from Off Hand
            myItem = RemoveItem(ItemLocationEnum.OffHand);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            // Remove Item from Right Finger
            myItem = RemoveItem(ItemLocationEnum.RightFinger);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            // Remove item from Left Finger
            myItem = RemoveItem(ItemLocationEnum.LeftFinger);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            // Remove Item from feet
            myItem = RemoveItem(ItemLocationEnum.Feet);
            if (myItem != null)
            {
                myReturn.Add(myItem);
            }

            return myReturn;
        }

        // Remove ItemModel from a set location
        // Does this by adding a new ItemModel of Null to the location
        // This will return the previous ItemModel, and put null in its place
        // Returns the ItemModel that was at the location
        // Nulls out the location
        public ItemModel RemoveItem(ItemLocationEnum itemlocation)
        {
            var myReturn = AddItem(itemlocation, null);

            // Save Changes
            return myReturn;
        }

        // Get the ItemModel at a known string location (head, foot etc.)
        public ItemModel GetItemByLocation(ItemLocationEnum itemLocation)
        {
            switch (itemLocation)
            {
                case ItemLocationEnum.Head:
                    return GetItem(Head);

                case ItemLocationEnum.Necklass:
                    return GetItem(Necklass);

                case ItemLocationEnum.PrimaryHand:
                    return GetItem(PrimaryHand);

                case ItemLocationEnum.OffHand:
                    return GetItem(OffHand);

                case ItemLocationEnum.RightFinger:
                    return GetItem(RightFinger);

                case ItemLocationEnum.LeftFinger:
                    return GetItem(LeftFinger);

                case ItemLocationEnum.Feet:
                    return GetItem(Feet);
            }

            return null;
        }

        // Add ItemModel
        // Looks up the ItemModel
        // Puts the ItemModel ID as a string in the location slot
        // If ItemModel is null, then puts null in the slot
        // Returns the ItemModel that was in the location
        public ItemModel AddItem(ItemLocationEnum itemlocation, string itemID)
        {
            ItemModel myReturn;

            switch (itemlocation)
            {
                case ItemLocationEnum.Feet:
                    myReturn = GetItem(Feet);
                    Feet = itemID;
                    break;

                case ItemLocationEnum.Head:
                    myReturn = GetItem(Head);
                    Head = itemID;
                    break;

                case ItemLocationEnum.Necklass:
                    myReturn = GetItem(Necklass);
                    Necklass = itemID;
                    break;

                case ItemLocationEnum.PrimaryHand:
                    myReturn = GetItem(PrimaryHand);
                    PrimaryHand = itemID;
                    break;

                case ItemLocationEnum.OffHand:
                    myReturn = GetItem(OffHand);
                    OffHand = itemID;
                    break;

                case ItemLocationEnum.RightFinger:
                    myReturn = GetItem(RightFinger);
                    RightFinger = itemID;
                    break;

                case ItemLocationEnum.LeftFinger:
                    myReturn = GetItem(LeftFinger);
                    LeftFinger = itemID;
                    break;

                default:
                    myReturn = null;
                    break;
            }

            return myReturn;
        }

        // Walk all the Items on the Character.
        // Add together all Items that modify the Attribute Enum Passed in
        // Return the sum
        public int GetItemBonus(AttributeEnum attributeEnum)
        {
            var myReturn = 0;
            ItemModel myItem;

            // Get the item from the Head 
            myItem = GetItem(Head);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            // Get the item from the Neckless
            myItem = GetItem(Necklass);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            // Get the item from the Primary Hand
            myItem = GetItem(PrimaryHand);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            // Get the item from the Off Hand
            myItem = GetItem(OffHand);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            // Get the item from the Right Finger
            myItem = GetItem(RightFinger);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            // // Get the item from the Left Finger
            myItem = GetItem(LeftFinger);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            // // Get the item from the Feet
            myItem = GetItem(Feet);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            return myReturn;
        }

        /// <summary>
        /// Get the Range value for the equipped primary weapon
        /// 
        /// If it has a positive value, return that
        /// 
        /// Else return 0
        /// </summary>
        /// <returns></returns>
        public int GetItemRange()
        {
            var weapon = GetItemByLocation(ItemLocationEnum.PrimaryHand);
            if (weapon == null)
            {
                return 0;
            }

            if (weapon.Range < 0)
            {
                return 0;
            }

            return weapon.Range;
        }

        #endregion Items

        /// <summary>
        /// Add to Health
        /// </summary>
        public int BuffAttack()
        {
            return BuffAttackValue += 5;
        }

        /// <summary>
        /// Add to Health
        /// </summary>
        public int BuffHealth()
        {
            return BuffHealthValue += 5;
        }

        /// <summary>
        /// Add to Health
        /// </summary>
        public int BuffDefense()
        {
            return BuffDefenseValue += 5;
        }

        /// <summary>
        /// Add to Health
        /// </summary>
        public int BuffSpeed()
        {
            return BuffSpeedValue += 5;
        }

        #endregion Methods
    }
}
