using Game.Services;

namespace Game.Models
{
   
    public class Character : BaseModel<Character>
    {
        public Character()
        {
            ImageURI = CharacterService.DefaultImageURI;
            HasForce = false;
        }

        public Character(Character data)
        {
            Update(data);
        }

        public bool HasForce { get; set; }

        public override void Update(Character newData)
        {
            if (newData == null)
            {
                return;
            }

            // Update all the fields in the Data, except for the Id and guid
            Name = newData.Name;
            Description = newData.Description;
            Name = newData.Name;
            Description = newData.Description;
            ImageURI = newData.ImageURI;
            HasForce = newData.HasForce;
        }
    }
}