using Game.Services;

namespace Game.Models
{
   
    public class MonsterModel : BaseModel<MonsterModel>
    {
        // Attributes

        //Attack of the monster
        public int Attack { get; set; }

        //Defence of the monster
        public int Defense { get; set; }

        //Current health of the monster
        public int Health { get; set; }

        //Speed of the monster
        public int Speed { get; set; }

        // Amount of experience the monster has
        public int Experience { get; set; }

        // Current level of the monster
        public int Level { get; set; }

        // Flag indicating whether a Monster has force special ability
        public bool HasForce { get; set; }

        //Current health of the character
        public int CurrentHealth { get; set; }

        // Monster status
        public bool Alive = true;

        //Maximum health of the character
        public int MaxHealth { get; set; }


        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public MonsterModel()
        {
            ImageURI = MonsterService.DefaultImageURI;
            Attack = 1;
            Defense = 1;
            Health = 1;
            Speed = 1;
            Experience = 1;
            Level = 1;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public MonsterModel(MonsterModel data)
        {
            Update(data);
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
        /// Update a monster
        /// </summary>
        /// <param name="newData"></param>
        public override bool Update(MonsterModel newData)
        {
            if (newData == null)
            {
                return false;
            }

            // Update all the fields in the Data, except for the Id and guid
            Name = newData.Name;
            Description = newData.Description;
            ImageURI = newData.ImageURI;
            HasForce = newData.HasForce;
            return true;
        }

        //Up the monster level
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

        /// <summary>
        /// Calculate Monster damage
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
            // if current health is 0 or less monster is dead
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
        /// Format output
        /// </summary>
        /// <returns></returns>
        public string FormatOutput() { return string.Empty; }
    }
}