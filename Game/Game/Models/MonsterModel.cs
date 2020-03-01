using Game.Services;

namespace Game.Models
{
   
    /// <summary>
    /// Monster Model Class
    /// </summary>
    public class MonsterModel : BasePlayerModel<MonsterModel>
    {
        /// <summary>
        /// Parameterless constructor for MonsterModel Class
        /// </summary>
        public MonsterModel()
        {
            PlayerType = PlayerTypeEnum.Monster;
            Name = "boba Fett";
            Description = "Bounty Hunter";
            ImageURI = MonsterService.DefaultImageURI;
            Attack = 1;
            Defense = 1;
            CurrentHealth = 1;
            Speed = 1;
            ExperiencePoints = 1;
            Level = 1;
        }

        /// <summary>
        /// Make a copy
        /// </summary>
        /// <param name="data"></param>
        public MonsterModel(MonsterModel data)
        {
            Update(data);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="newData"></param>
        /// <returns></returns>
        public override bool Update(MonsterModel newData)
        {
            if (newData == null)
            {
                return false;
            }

            PlayerType = newData.PlayerType;
            Guid = newData.Guid;
            Name = newData.Name;
            Description = newData.Description;
            Level = newData.Level;
            ImageURI = newData.ImageURI;

            Difficulty = newData.Difficulty;

            Speed = newData.Speed;
            Defense = newData.Defense;
            Attack = newData.Attack;

            ExperienceTotal = newData.ExperienceTotal;
            ExperienceRemaining = newData.ExperienceRemaining;
            CurrentHealth = newData.CurrentHealth;
            MaxHealth = newData.MaxHealth;

            UniqueItem = newData.UniqueItem;
            HasForce = newData.HasForce;

            return true;
        }

    }
}