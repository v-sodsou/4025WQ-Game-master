using Game.Services;

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