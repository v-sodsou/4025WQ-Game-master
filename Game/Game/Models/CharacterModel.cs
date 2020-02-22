using Game.Helpers;
using Game.Services;
using Game.ViewModels;
using System;
using System.Collections.Generic;

namespace Game.Models
{
   
    public class CharacterModel : BaseModel<CharacterModel>
    {
        //Attributes 

        // Flag indicating whether a Character has force special ability
        public bool HasForce { get; set; }

        //Attack of the character
        public int Attack { get; set; }

        //Defence of the character
        public int Defense { get; set; }

        //Speed of the charcater
        public int Speed { get; set; }

        //Current health of the character
        public int CurrentHealth { get; set; }

        //Maximum health of the character
        public int MaxHealth { get; set; }

        //Current level of the character
        public int Level { get; set; }

        // Character status
        public bool Alive = true;


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

        #endregion Items

        // Parameterless constructor
        public CharacterModel()
        {
            ImageURI = CharacterService.DefaultImageURI;
            HasForce = false;
            Attack = 1;
            Defense = 1;
            Speed = 1;
            CurrentHealth = 1;
            MaxHealth = 10;
            Level = 1;
        }

        // Constructor
        public CharacterModel(CharacterModel data)
        {
            Update(data);
        }

        // Update all the fields in the Data, except for the Id and guid
        public override bool Update(CharacterModel newData)
        {
            if (newData == null)
            {
                return false;
            }

            Name = newData.Name;
            Description = newData.Description;
            ImageURI = newData.ImageURI;
            HasForce = newData.HasForce;
            Attack = newData.Attack;
            Defense = newData.Defense;
            Speed = newData.Speed;
            CurrentHealth = newData.CurrentHealth;
            MaxHealth = newData.MaxHealth;
            return true;

         }

        //Up the character level
        public void LevelUp(int level)
        {
            // Donot update if it is the same level
            if (level == this.Level)
                return;

            // Level must be between 1-20
            if (level < 1 || level > 20)
                return;

            this.Level = level;
        }


        // Get Attack
        public int GetAttack()
        {
            return this.Attack;
        }

        // Get Speed
        public int GetSpeed()
        {
            return this.Speed;
        }

        // Get Defense
        public int GetDefense()
        {
            return this.Defense;
        }

        // Get Max Health
        public int GetHealthMax()
        {
            return this.MaxHealth;
        }

        // Get Current Health
        public int GetHealthCurrent()
        {
            return this.CurrentHealth;
        }

        /// <summary>
        /// Calculate damage
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public bool TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                return false;
            }

            CurrentHealth = CurrentHealth - damage;
            // if current health is 0 or less character is dead
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;

                // Set Alive to false
                Alive = false;
                return Alive;
            }

            return true;
        }


        /// <summary>
        /// Add experience to a character
        /// </summary>
        /// <param name="newExperience"></param>
        /// <returns></returns>
        public bool AddExperience(int newExperience)
        { 
            return true;
        }

        /// <summary>
        /// Remove an item from a character
        /// </summary>
        /// <param name="itemlocation"></param>
        /// <returns></returns>
        public ItemModel RemoveItem(ItemLocationEnum itemlocation)
        {
            var myReturn = AddItem(itemlocation, null);
            // Save Changes
            return myReturn;
        }

        /// <summary>
        /// Add an item to a character
        /// </summary>
        /// <param name="itemlocation"></param>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public ItemModel AddItem(ItemLocationEnum itemlocation, string itemID)
        {
            return new ItemModel();
        }

        /// <summary>
        /// Drop all items
        /// </summary>
        /// <returns></returns>
        public List<ItemModel> DropAllItems()
        {
            return new List<ItemModel>();
        }

        /// <summary>
        /// Format output
        /// </summary>
        /// <returns></returns>
        public string FormatOutput() { return ""; }

        /// <summary>
        /// /\GetDamageLevelBonus
        /// </summary>
        public int GetDamageLevelBonus { get { return Convert.ToInt32(Math.Ceiling(Level * .25)); } }

        /// <summary>
        /// GetDamageRollValue
        /// </summary>
        /// <returns></returns>
        public int GetDamageRollValue()
        {
            var myReturn = 0;
            var myItem = ItemIndexViewModel.Instance.GetItem(PrimaryHand);
            if (myItem != null)
            {
                myReturn += DiceHelper.RollDice(1, myItem.Damage);
            }
            myReturn += GetDamageLevelBonus;
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

        // Get the Item at a known string location (head, foot etc.)
        public ItemModel GetItem(string itemString)
        {
            return ItemIndexViewModel.Instance.GetItem(itemString);
        }


        // Walk all the Items on the Character.
        // Add together all Items that modify the Attribute Enum Passed in
        // Return the sum
        public int GetItemBonus(AttributeEnum attributeEnum)
        {
            var myReturn = 0;
            ItemModel myItem;

            myItem = GetItem(Head);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = GetItem(Necklass);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = GetItem(PrimaryHand);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = GetItem(OffHand);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = GetItem(RightFinger);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

            myItem = GetItem(LeftFinger);
            if (myItem != null)
            {
                if (myItem.Attribute == attributeEnum)
                {
                    myReturn += myItem.Value;
                }
            }

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
        /// LevelUpToValue
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int LevelUpToValue(int value) 
        {
            return 0;

        }

        /// <summary>
        /// GetDamageDice
        /// </summary>
        /// <returns></returns>
        public int GetDamageDice()
        {
            var myReturn = 0;
            var myItem = ItemIndexViewModel.Instance.GetItem(PrimaryHand);
            if (myItem != null)
            {
                myReturn += myItem.Damage;
            }
            return myReturn;
        }
    }
}