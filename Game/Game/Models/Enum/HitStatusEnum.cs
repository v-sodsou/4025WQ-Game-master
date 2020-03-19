namespace Game.Models
{
    /// <summary>
    /// Types of Hits during a Turn.
    /// </summary>
    public enum HitStatusEnum
    {
        Unknown = 0,

        // Default for settings mode to use
        Default = 1,

        // Miss
        Miss = 10,

        // Critical Miss, miss and something bad happens
        CriticalMiss = 15,

        // Hit
        Hit = 20,

        // Critical Hit, bonus after hit happens
        CriticalHit = 25
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class HitStatusEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this HitStatusEnum value)
        {
            // Default String
            var Message = "Unknown";

            switch (value)
            {
                case HitStatusEnum.Hit:
                    Message = " hits ";
                    break;

                case HitStatusEnum.CriticalHit:
                    Message = " hits really hard ";
                    break;

                case HitStatusEnum.Miss:
                    Message = " misses ";
                    break;

                case HitStatusEnum.CriticalMiss:
                    Message = " misses really badly";
                    break;

                case HitStatusEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }
}