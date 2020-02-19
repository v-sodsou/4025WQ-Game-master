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

        public MonsterModel(MonsterModel data)
        {
            Update(data);
        }

        public override void Update(MonsterModel newData)
        {
            if (newData == null)
            {
                return;
            }

            // Update all the fields in the Data, except for the Id and guid
            Name = newData.Name;
            Description = newData.Description;
            ImageURI = newData.ImageURI;
            HasForce = newData.HasForce;
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
    }
}