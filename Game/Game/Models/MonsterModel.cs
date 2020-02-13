using Game.Services;

namespace Game.Models
{
   
    public class MonsterModel : BaseModel<MonsterModel>
    {
        // Attributes
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }
        public int Experience { get; set; }
        public int id { get; set; }
        public int Level { get; set; }
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
    }
}