using Game.Services;

namespace Game.Models
{
   
    public class Monster : BaseModel<Monster>
    {
        public Monster()
        {
            ImageURI = MonsterService.DefaultImageURI;
            HasForce = false;
        }

        public Monster(Monster data)
        {
            Update(data);
        }

        public bool HasForce { get; set; }

        public override void Update(Monster newData)
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