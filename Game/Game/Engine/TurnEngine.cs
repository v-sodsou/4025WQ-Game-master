﻿using Game.Helpers;
using Game.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Game.Engine
{
    /// <summary>
    /// TurnEngine Class
    /// </summary>
    public class TurnEngine: BaseEngine
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

        /// <summary>
        /// Decide which to attack
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public PlayerInfoModel AttackChoice(PlayerInfoModel data)
        {
            switch (data.PlayerType)
            {
                case PlayerTypeEnum.Monster:
                    return SelectCharacterToAttack();

                case PlayerTypeEnum.Character:
                default:
                    return SelectMonsterToAttack();
            }
        }


        /// <summary>
        /// Drop Items
        /// </summary>
        /// <param name="Target"></param>
        public int DropItems(PlayerInfoModel Target)
        {
            // Drop Items to ItemModel Pool
            var myItemList = Target.DropAllItems();

            // I feel generous, even when characters die, random drops happen :-)
            // If Random drops are enabled, then add some....
            myItemList.AddRange(GetRandomMonsterItemDrops(BattleScore.RoundCount));

            // Add to ScoreModel
            foreach (var ItemModel in myItemList)
            {
                BattleScore.ItemsDroppedList += ItemModel.FormatOutput() + "\n";
                BattleMessagesModel.TurnMessageSpecial += string.Format("\nItem(s) Dropped: {0}. ", ItemModel.Name);
            }

            ItemPool.AddRange(myItemList);

            return myItemList.Count();
        }

        /// <summary>
        /// Will drop between 1 and 4 items from the ItemModel set...
        /// </summary>
        /// <param name="round"></param>
        /// <returns></returns>
        public List<ItemModel> GetRandomMonsterItemDrops(int round)
        {
            // You decide how to drop monster items, level, etc.

            var NumberToDrop = DiceHelper.RollDice(1, round);

            var myList = new List<ItemModel>();

            for (var i = 0; i < NumberToDrop; i++)
            {
                myList.Add(new ItemModel());
            }
            return myList;
        }

        /// <summary>
        /// Target Died
        /// 
        /// Process for death...
        /// 
        /// Returns the count of items dropped at death
        /// </summary>
        /// <param name="Target"></param>
        public bool TargetDied(PlayerInfoModel Target)
        {
            bool found;

            // Mark Status in output
            BattleMessagesModel.TurnMessageSpecial = " and causes death. ";

            // Hackathon: Hack #30 - Did you hear that?
            //var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            //Thread.Sleep(500);
            //player.Load("shutdown.wav");
            //player.Play();

            // Using a switch so in the future additional PlayerTypes can be added (Boss...)
            switch (Target.PlayerType)
            {
                case PlayerTypeEnum.Character:
                    // Add the Character to the killed list
                    BattleScore.CharacterAtDeathList += Target.FormatOutput() + "\n";

                    BattleScore.CharacterModelDeathList.Add(Target);

                    DropItems(Target);

                    found = CharacterList.Remove(CharacterList.Find(m => m.Guid.Equals(Target.Guid)));
                    found = PlayerList.Remove(PlayerList.Find(m => m.Guid.Equals(Target.Guid)));

                    return true;

                case PlayerTypeEnum.Monster:
                default:
                    // Add one to the monsters killed count...
                    BattleScore.MonsterSlainNumber++;

                    // Add the MonsterModel to the killed list
                    BattleScore.MonstersKilledList += Target.FormatOutput() + "\n";

                    BattleScore.MonsterModelDeathList.Add(Target);

                    DropItems(Target);

                    found = MonsterList.Remove(MonsterList.Find(m => m.Guid.Equals(Target.Guid)));
                    found = PlayerList.Remove(PlayerList.Find(m => m.Guid.Equals(Target.Guid)));

                    return true;
            }
        }

        /// <summary>
        /// If Dead process Targed Died
        /// </summary>
        /// <param name="Target"></param>
        public bool RemoveIfDead(PlayerInfoModel Target)
        {
            // Check for alive
            if (Target.Alive == false)
            {
                TargetDied(Target);
                return true;
            }

            return false;
        }

        /// <summary>
        /// // MonsterModel Attacks CharacterModel
        /// </summary>
        /// <param name="Attacker"></param>
        /// <param name="AttackScore"></param>
        /// <param name="Target"></param>
        /// <param name="DefenseScore"></param>
        /// <returns></returns>
        public bool TurnAsAttack(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            if (Attacker == null)
            {
                return false;
            }

            if (Target == null)
            {
                return false;
            }

            BattleMessagesModel.TurnMessage = string.Empty;
            BattleMessagesModel.TurnMessageSpecial = string.Empty;
            BattleMessagesModel.AttackStatus = string.Empty;

            BattleMessagesModel.PlayerType = PlayerTypeEnum.Monster;

            var AttackScore = Attacker.Level + Attacker.GetAttack();
            var DefenseScore = Target.GetDefense() + Target.Level;

            // Choose who to attack

            BattleMessagesModel.TargetName = Target.Name;
            BattleMessagesModel.AttackerName = Attacker.Name;

            // Hackathon
            // Hackathon Scenario 2, Bob always misses
            if (Attacker.Name.Equals("Bob"))
            {
                BattleMessagesModel.HitStatus = HitStatusEnum.Miss;
                BattleMessagesModel.TurnMessage = "Bob always Misses";
                Debug.WriteLine(BattleMessagesModel.TurnMessage);
                return true;
            }

            BattleMessagesModel.HitStatus = RollToHitTarget(AttackScore, DefenseScore);

            Debug.WriteLine(BattleMessagesModel.GetTurnMessage());

            // It's a Miss
            if (BattleMessagesModel.HitStatus == HitStatusEnum.Miss)
            {
                // Hackathon: Hack #18. Did you hear that?
                //var player1 = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                //Thread.Sleep(500);
                //player1.Load("chimes.wav");
                //player1.Play();

                return true;
            }

            // It's a Hit
            if (BattleMessagesModel.HitStatus == HitStatusEnum.Hit)
            {
                // Hackathon: Hack #18. Did you hear that?
                //var player2 = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                //Thread.Sleep(500);
                //player2.Load("notify.wav");
                //player2.Play();

                //Calculate Damage
                BattleMessagesModel.DamageAmount = Attacker.GetDamageRollValue();

                Target.TakeDamage(BattleMessagesModel.DamageAmount);
            }

            BattleMessagesModel.CurrentHealth = Target.CurrentHealth;
            BattleMessagesModel.TurnMessageSpecial = BattleMessagesModel.GetCurrentHealthMessage();

            RemoveIfDead(Target);

            BattleMessagesModel.TurnMessage = string.Format("\"{0}\" attacks {1} \"{2}\" {3}",
                Attacker.Name,
                BattleMessagesModel.AttackStatus,
                Target.Name,
                BattleMessagesModel.TurnMessageSpecial);
            Debug.WriteLine(BattleMessagesModel.TurnMessage);

            return true;
        }

        /// <summary>
        /// Find a Desired Target
        /// Move close to them
        /// Get to move the number of Speed
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public bool MoveAsTurn(PlayerInfoModel Attacker)
        {

            /*
             * TODO: TEAMS Work out your own move logic if you are implementing move
             * 
             * Mike's Logic
             * The monster or charcter will move to a different square if one is open
             * Find the Desired Target
             * Jump to the closest space near the target that is open
             * 
             * If no open spaces, return false
             * 
             */

            if (Attacker.PlayerType == PlayerTypeEnum.Monster)
            {
                // For Attack, Choose Who
                CurrentDefender = AttackChoice(Attacker);

                if (CurrentDefender == null)
                {
                    return false;
                }

                // Get X, Y for Defender
                var locationDefender = MapModel.GetLocationForPlayer(CurrentDefender);
                if (locationDefender == null)
                {
                    return false;
                }

                var locationAttacker = MapModel.GetLocationForPlayer(Attacker);
                if (locationAttacker == null)
                {
                    return false;
                }

                // Find Location Nearest to Defender that is Open.

                // Get the Open Locations
                var openSquare = MapModel.ReturnClosestEmptyLocation(locationDefender);

                Debug.WriteLine(string.Format("{0} moves from {1},{2} to {3},{4}", locationAttacker.Player.Name, locationAttacker.Column, locationAttacker.Row, openSquare.Column, openSquare.Row));

                BattleMessagesModel.TurnMessage = Attacker.Name + " moves closer to " + CurrentDefender.Name;

                return MapModel.MovePlayerOnMap(locationAttacker, openSquare);
            }

            return true;
        }


        /// <summary>
        /// Attack as a Turn
        /// 
        /// Pick who to go after
        /// 
        /// Determine Attack Score
        /// Determine DefenseScore
        /// 
        /// Do the Attack
        /// 
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public bool Attack(PlayerInfoModel Attacker)
        {
            // For Attack, Choose Who
            var Target = AttackChoice(Attacker);

            if (Target == null)
            {
                return false;
            }

            // Do Attack
            TurnAsAttack(Attacker, Target);

            CurrentAttacker = new PlayerInfoModel(Attacker);
            CurrentDefender = new PlayerInfoModel(Target);

            return true;
        }

        /// <summary>
        /// CharacterModel Attacks...
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public bool TakeTurn(PlayerInfoModel Attacker)
        {
            // Choose Action.  Such as Move, Attack etc.

            // INFO: Teams, if you have other actions they would go here.

            bool result = false;

            // If the action is not set, then try to set it or use Attact
            if (CurrentAction == ActionEnum.Unknown)
            {
                // Set the action if one is not set
                CurrentAction = DetermineActionChoice(Attacker);

                // When in doubt, attack...
                if (CurrentAction == ActionEnum.Unknown)
                {
                    CurrentAction = ActionEnum.Attack;
                }
            }

            switch (CurrentAction)
            {
                //case ActionEnum.Unknown:
                //    // Action already happened
                //    break;

                case ActionEnum.Attack:
                    result = Attack(Attacker);
                    break;

                case ActionEnum.Ability:
                    result = UseAbility(Attacker);
                    break;

                case ActionEnum.Move:
                    result = MoveAsTurn(Attacker);
                    break;
            }

            BattleScore.TurnCount++;

            // Save the Previous Action off
            PreviousAction = CurrentAction;

            // Reset the Action to unknown for next time
            CurrentAction = ActionEnum.Unknown;

            return result;
        }

        /// <summary>
        /// Determine what Actions to do
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public ActionEnum DetermineActionChoice(PlayerInfoModel Attacker)
        {
            // If it is the characters turn, and NOT auto battle, use what was sent into the engine
            if (Attacker.PlayerType == PlayerTypeEnum.Character)
            {
                if (BattleScore.AutoBattle == false)
                {
                    return CurrentAction;
                }
            }

            /*
             * The following is Used for Monsters, and Auto Battle Characters
             * 
             * Order of Priority
             * If can attack Then Attack
             * Next use Ability or Move
             */

            // Assume Move if nothing else happens
            CurrentAction = ActionEnum.Move;

            // Check to see if ability is avaiable
            if (ChooseToUseAbility(Attacker))
            {
                CurrentAction = ActionEnum.Ability;
                return CurrentAction;
            }

            // See if Desired Target is within Range, and if so attack away
            if (MapModel.IsTargetInRange(Attacker, AttackChoice(Attacker)))
            {
                CurrentAction = ActionEnum.Attack;
            }

            return CurrentAction;
        }

        /// <summary>
        /// Use the Ability
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public bool UseAbility(PlayerInfoModel Attacker)
        {
            BattleMessagesModel.TurnMessage = Attacker.Name + " Uses Ability " + CurrentActionAbility.ToMessage();
            return (Attacker.UseAbility(CurrentActionAbility));
        }

        /// <summary>
        /// Decide to use an Ability or not
        /// 
        /// Set the Ability
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public bool ChooseToUseAbility(PlayerInfoModel Attacker)
        {
            // See if healing is needed.
            CurrentActionAbility = Attacker.SelectHealingAbility();
            if (CurrentActionAbility != AbilityEnum.Unknown)
            {
                CurrentAction = ActionEnum.Ability;
                return true;
            }

            // If not needed, then role dice to see if other ability should be used
            // <30% chance
            if (DiceHelper.RollDice(1, 10) < 3)
            {
                CurrentActionAbility = Attacker.SelectAbilityToUse();

                if (CurrentActionAbility != AbilityEnum.Unknown)
                {
                    // Ability can , switch to unknown to exit
                    CurrentAction = ActionEnum.Ability;
                    return true;
                }

                // No ability available
                return false;
            }

            // Don't try
            return false;
        }
    }
}
