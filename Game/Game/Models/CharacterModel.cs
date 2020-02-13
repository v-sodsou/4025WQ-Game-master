using Game.Services;

namespace Game.Models
{
   
    public class CharacterModel : BaseModel<CharacterModel>
    {
        // Special Attribute
        public bool HasForce { get; set; }

        //Attributes
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }

        // Parameterless constructor
        public CharacterModel()
        {
            ImageURI = CharacterService.DefaultImageURI;
            HasForce = false;
            Attack = 100;
        }

        // Constructor
        public CharacterModel(CharacterModel data)
        {
            Update(data);
        }

        // Update all the fields in the Data, except for the Id and guid
        public override void Update(CharacterModel newData)
        {
            if (newData == null)
            {
                return;
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

    }
    }
}