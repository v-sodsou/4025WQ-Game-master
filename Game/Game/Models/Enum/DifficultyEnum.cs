using System;

namespace Game.Models
{
    /// <summary>
    /// The Types of Difficultys
    /// Used by Item to specify what it modifies.
    /// </summary>
    public enum DifficultyEnum
    {
        // Not specified
        Unknown = 0,

        // Easier than mostThe speed of the character, impacts movement, and initiative
        Easy = 10,

        // Average
        Average = 12,

        // Hard
        Hard = 14,

        // Harder than Hard
        Difficult = 16,

        // The highest value
        Impossible = 18,
    }

   
}