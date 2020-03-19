using System;
using System.Collections.Generic;

namespace Game.Models
{
    /// <summary>
    /// Player for the game.
    /// 
    /// Either Monster or Character
    /// 
    /// Constructor Player to Player used a T in Round
    /// </summary>
    public class PlayerInfoModel : BasePlayerModel<PlayerInfoModel>
    {
        // Track the Abilities in the Battle
        // The Ability will be the List of Abilities per Job, and a count of how many times they can use it per round
        public Dictionary<AbilityEnum, int> AbilityTracker = new Dictionary<AbilityEnum, int>();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PlayerInfoModel() { }

        /// <summary>
        /// Copy from one PlayerInfoModel into Another
        /// </summary>
        /// <param name="data"></param>
        public PlayerInfoModel(PlayerInfoModel data)
        {
            PlayerType = data.PlayerType;
            Guid = data.Guid;
            Alive = data.Alive;
            ExperiencePoints = data.ExperienceTotal;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;
            Speed = data.GetSpeed();
            ImageURI = data.ImageURI;
            CurrentHealth = data.GetCurrentHealthTotal;
            MaxHealth = data.GetMaxHealthTotal;

            // Set the strings for the items
            Head = data.Head;
            Feet = data.Feet;
            Necklass = data.Necklass;
            RightFinger = data.RightFinger;
            LeftFinger = data.LeftFinger;
            Feet = data.Feet;
        }

        /// <summary>
        /// Create PlayerInfoModel from character
        /// </summary>
        /// <param name="data"></param>
        public PlayerInfoModel(CharacterModel data)
        {
            PlayerType = data.PlayerType;
            Guid = data.Guid;
            Alive = data.Alive;
            ExperiencePoints = data.ExperienceTotal;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;
            Speed = data.GetSpeed();
            ImageURI = data.ImageURI;
            CurrentHealth = data.GetCurrentHealthTotal;
            MaxHealth = data.GetMaxHealthTotal;

            // Set the strings for the items
            Head = data.Head;
            Feet = data.Feet;
            Necklass = data.Necklass;
            RightFinger = data.RightFinger;
            LeftFinger = data.LeftFinger;
            Feet = data.Feet;
        }

        /// <summary>
        /// Crate PlayerInfoModel from Monster
        /// </summary>
        /// <param name="data"></param>
        public PlayerInfoModel(MonsterModel data)
        {
            PlayerType = data.PlayerType;
            Guid = data.Guid;
            Alive = data.Alive;
            ExperiencePoints = data.ExperienceTotal;
            Level = data.Level;
            Name = data.Name;
            Description = data.Description;
            Speed = data.GetSpeed();
            ImageURI = data.ImageURI;
            CurrentHealth = data.GetCurrentHealthTotal;
            MaxHealth = data.GetMaxHealthTotal;

            // Set the strings for the items
            Head = data.Head;
            Feet = data.Feet;
            Necklass = data.Necklass;
            RightFinger = data.RightFinger;
            LeftFinger = data.LeftFinger;
            Feet = data.Feet;
        }

        /// <summary>
        /// Use the Ability
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public bool UseAbility(AbilityEnum ability)
        {
            var avaible = AbilityTracker.TryGetValue(ability, out int remaining);
            if (avaible == false)
            {
                // does not exist
                return false;
            }

            if (remaining < 1)
            {
                // out of tries
                return false;
            }

            switch (ability)
            {
                case AbilityEnum.Heal:
                case AbilityEnum.Bandage:
                    BuffHealth();
                    break;

                case AbilityEnum.Toughness:
                case AbilityEnum.Barrier:
                    BuffDefense();
                    break;

                case AbilityEnum.Curse:
                case AbilityEnum.Focus:
                    BuffAttack();
                    break;

                case AbilityEnum.Quick:
                case AbilityEnum.Nimble:
                    BuffSpeed();
                    break;
            }

            // Reduce the count
            AbilityTracker[ability] = remaining - 1;

            return true;
        }

        /// <summary>
        /// Check to see if healing would help
        /// 
        /// if not, return unknown
        /// </summary>
        /// <returns></returns>
        public AbilityEnum SelectHealingAbility()
        {
            // Save the Health for when it is needed
            // If health is 25% or less of max health, try to heal
            if (GetCurrentHealth() < (GetMaxHealth() * .25))
            {
                // Try to use Heal or Bandage
                if (IsAbilityAvailable(AbilityEnum.Heal))
                {
                    return AbilityEnum.Heal;
                }

                if (IsAbilityAvailable(AbilityEnum.Bandage))
                {
                    return AbilityEnum.Bandage;
                }
            }

            return AbilityEnum.Unknown;
        }

        /// <summary>
        /// Is ability available method
        /// </summary>
        /// <param name="ability"></param>
        /// <returns></returns>
        public bool IsAbilityAvailable(AbilityEnum ability)
        {
            var avaible = AbilityTracker.TryGetValue(ability, out int remaining);
            if (avaible == false)
            {
                // does not exist
                return false;
            }

            if (remaining < 1)
            {
                // out of tries
                return false;
            }

            return true;
        }

        /// <summary>
        /// Walk the Abilities and return one to use
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public AbilityEnum SelectAbilityToUse()
        {
            // Walk the other abilities and see which can be used
            foreach (var ability in AbilityTracker)
            {
                var data = ability.Key;

                // Skip over Heal and Bandage because covered in healing
                if (data == AbilityEnum.Heal)
                {
                    continue;
                }

                if (data == AbilityEnum.Bandage)
                {
                    continue;
                }

                var result = AbilityTracker.TryGetValue(data, out int remaining);
                if (remaining > 0)
                {
                    // Got one so can prepare it to be used
                    return data;
                }
            }

            return AbilityEnum.Unknown;
        }
    }
}