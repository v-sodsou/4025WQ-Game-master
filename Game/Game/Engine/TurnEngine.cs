﻿using Game.Helpers;
using Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Engine
{
    class TurnEngine: BaseEngine
    {

        #region Algrorithm
        // Attack or Move
        // Roll To Hit
        // Decide Hit or Miss
        // Decide Damage
        // Death
        // Drop Items
        // Turn Over
        #endregion Algrorithm


        /// <summary>
        /// Roll To Hit
        /// </summary>
        /// <param name="AttackScore"></param>
        /// <param name="DefenseScore"></param>
        /// <returns></returns>
        public HitStatusEnum RollToHitTarget(int AttackScore, int DefenseScore)
        {
            var d20 = DiceHelper.RollDice(1, 20);

            if (d20 == 1)
            {
                // Force Miss
                BattleMessagesModel.HitStatus = HitStatusEnum.Miss;
                return BattleMessagesModel.HitStatus;
            }

            if (d20 == 20)
            {
                // Force Hit
                BattleMessagesModel.HitStatus = HitStatusEnum.Hit;
                return BattleMessagesModel.HitStatus;
            }

            var ToHitScore = d20 + AttackScore;
            if (ToHitScore < DefenseScore)
            {
                BattleMessagesModel.AttackStatus = " misses ";
                // Miss
                BattleMessagesModel.HitStatus = HitStatusEnum.Miss;
                BattleMessagesModel.DamageAmount = 0;
                return BattleMessagesModel.HitStatus;
            }

            // Hit
            BattleMessagesModel.HitStatus = HitStatusEnum.Hit;
            return BattleMessagesModel.HitStatus;
        }

        /// <summary>
        /// Pick the Character to Attack
        /// </summary>
        /// <returns></returns>
        public PlayerInfoModel SelectCharacterToAttack()
        {
            if (CharacterList == null)
            {
                return null;
            }

            if (CharacterList.Count < 1)
            {
                return null;
            }

            // Select first in the list
            var Defender = CharacterList
                .Where(m => m.Alive)
                .OrderBy(m => m.ListOrder).FirstOrDefault();

            return Defender;
        }

        /// <summary>
        /// Pick the Monster to Attack
        /// </summary>
        /// <returns></returns>
        public PlayerInfoModel SelectMonsterToAttack()
        {
            if (MonsterList == null)
            {
                return null;
            }

            if (MonsterList.Count < 1)
            {
                return null;
            }

            // Select first one to hit in the list for now...
            // Attack the Weakness (lowest HP) MonsterModel first 
            var Defender = MonsterList
                .Where(m => m.Alive)
                .OrderBy(m => m.CurrentHealth).FirstOrDefault();

            return Defender;
        }


    }
}
