using Game.Services;

namespace Game.Models
{
   
    public class CharacterModel : BaseModel<CharacterModel>
    {
        public CharacterModel()
        {
            ImageURI = CharacterService.DefaultImageURI;
            HasForce = false;
        }

        public CharacterModel(CharacterModel data)
        {
            Update(data);
        }

        public bool HasForce { get; set; }

        public override void Update(CharacterModel newData)
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