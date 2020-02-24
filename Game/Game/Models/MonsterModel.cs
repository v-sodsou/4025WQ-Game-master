using Game.Services;

namespace Game.Models
{
   
    public class MonsterModel : BasePlayerModel<MonsterModel>
    {
        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public MonsterModel()
        {
            PlayerType = PlayerTypeEnum.Monster;
            Name = "Kylo Ren";
            Description = "Member of the Knights of Ren.";
            ImageURI = MonsterService.DefaultImageURI;
            Attack = 1;
            Defense = 1;
            CurrentHealth = 1;
            Speed = 1;
            ExperiencePoints = 1;
            Level = 1;
        }

    }
}