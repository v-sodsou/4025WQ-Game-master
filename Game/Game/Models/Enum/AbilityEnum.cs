using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Models
{
    /// <summary>
    /// The Types of s a Ability can have
    /// Used in Ability Crudi, and in Battles.
    /// </summary>
    public enum AbilityEnum
    {
        // Not specified
        Unknown = 0,

        // Not specified
        None = 1,

        // General Abilities 10 Range
        // Heal Self
        Bandage = 10,




        // Fighter Abilities > 20 Range
        // Buff Speed
        Nimble = 21,

        // Buff Defense
        Toughness = 22,

        // Buff Attack
        Focus = 23,



        // Cleric Abilities > 50 Range
        // Buff Speed
        Quick = 51,

        // Buff Defense
        Barrier = 52,

        // Buff Attack
        Curse = 53,

        // Heal Self
        Heal = 54,
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class AbilityEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this AbilityEnum value)
        {
            // Default String
            var Message = "None";

            switch (value)
            {
                case AbilityEnum.Bandage:
                    Message = "Apply Bandages";
                    break;

                case AbilityEnum.Nimble:
                    Message = "React Quickly";
                    break;

                case AbilityEnum.Toughness:
                    Message = "Toughen Up";
                    break;

                case AbilityEnum.Focus:
                    Message = "Mental Focus";
                    break;

                case AbilityEnum.Quick:
                    Message = "Anticipate";
                    break;

                case AbilityEnum.Barrier:
                    Message = "Barrier Defense";
                    break;

                case AbilityEnum.Curse:
                    Message = "Shout Curse";
                    break;

                case AbilityEnum.Heal:
                    Message = "Heal Self";
                    break;

                case AbilityEnum.None:
                case AbilityEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }
}
