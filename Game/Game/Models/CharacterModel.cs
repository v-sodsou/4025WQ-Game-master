using Game.Helpers;
using Game.Services;
using Game.ViewModels;
using System;
using System.Collections.Generic;

namespace Game.Models
{
   
    /// <summary>
    /// Character Model Class
    /// Inherits from BasePlayerModel Class
    /// </summary>
    public class CharacterModel : BasePlayerModel<CharacterModel>
    {

        /// <summary>
        /// Parameterless constructor for Character Model
        /// </summary>
        public CharacterModel()
        {
            PlayerType = PlayerTypeEnum.Character;
            Name = "Rebel Pilot";
            Description = "The force is with him";
            ImageURI = CharacterService.DefaultImageURI;
            HasForce = false;
            Attack = 1;
            Defense = 1;
            Speed = 1;
            CurrentHealth = 1;
            MaxHealth = 10;
            Level = 1;
        }

        /// <summary>
        /// Create a copy
        /// </summary>
        /// <param name="data"></param>
        public CharacterModel(CharacterModel data)
        {
            Update(data);
        }


    }
}