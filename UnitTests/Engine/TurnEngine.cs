using NUnit.Framework;

using System.Linq;
using System.Collections.Generic;

using Game.Engine;
using Game.Models;
using Game.Helpers;
using Game.ViewModels;

namespace UnitTests.Engine
{
    [TestFixture]
    public class TurnEngineTests
    {
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new BattleEngine();
            Engine.StartBattle(true);   // Start engine in auto battle mode
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void TurnEngine_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void TurnEngine_Attack_Valid_Empty_Monster_List_Should_Fail()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel(new CharacterModel());

            // Act
            var result = Engine.Attack(PlayerInfo);

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_Attack_InValid_Empty_Character_List_Should_Fail()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel(new MonsterModel());

            // Cause an error by making the list empty
            Engine.CharacterList.Clear();

            // Act
            var result = Engine.Attack(PlayerInfo);

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_Attack_Valid_Correct_List_Should_Pass()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel();
            Engine.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));

            // Act
            var result = Engine.Attack(PlayerInfo);

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(true, result);
        }

        //[Test]
        //public void TurnEngine_SelectMonsterToAttack_InValid_Null_List_Should_Fail()
        //{
        //    // Arrange

        //    // remember the list
        //    var saveList = Engine.PlayerList;

        //    Engine.PlayerList = null;

        //    // Act
        //    var result = Engine.SelectMonsterToAttack();

        //    // Reset

        //    // Restore the List
        //    Engine.PlayerList = saveList;
        //    Engine.StartBattle(false);   // Clear the Engine

        //    // Assert
        //    Assert.AreEqual(null, result);
        //}

        //[Test]
        //public void TurnEngine_SelectMonsterToAttack_InValid_Empty_List_Should_Fail()
        //{
        //    // Arrange

        //    // remember the list
        //    var saveList = Engine.PlayerList;

        //    Engine.PlayerList = new List<PlayerInfoModel>();

        //    // Act
        //    var result = Engine.SelectMonsterToAttack();

        //    // Reset

        //    // Restore the List
        //    Engine.PlayerList = saveList;
        //    Engine.StartBattle(false);   // Clear the Engine

        //    // Assert
        //    Assert.AreEqual(null, result);
        //}

        //[Test]
        //public void TurnEngine_SelectMonsterToAttack_InValid_Dead_List_Should_Fail()
        //{
        //    // Arrange

        //    // remember the list
        //    var saveList = Engine.PlayerList;

        //    Engine.PlayerList = new List<PlayerInfoModel>();

        //    var data = new PlayerInfoModel(new MonsterModel());
        //    data.Alive = false;
        //    Engine.PlayerList.Add(data);

        //    // Act
        //    var result = Engine.SelectMonsterToAttack();

        //    // Reset

        //    // Restore the List
        //    Engine.PlayerList = saveList;
        //    Engine.StartBattle(false);   // Clear the Engine

        //    // Assert
        //    Assert.AreEqual(null, result);
        //}

        //[Test]
        //public void TurnEngine_SelectMonsterToAttack_InValid_Dead_Character_List_Should_Fail()
        //{
        //    // Arrange

        //    // remember the list
        //    var saveList = Engine.PlayerList;

        //    Engine.PlayerList = new List<PlayerInfoModel>();

        //    var data = new PlayerInfoModel(new MonsterModel());
        //    data.Alive = false;
        //    data.PlayerType = PlayerTypeEnum.Character;
        //    Engine.PlayerList.Add(data);

        //    // Act
        //    var result = Engine.SelectMonsterToAttack();

        //    // Reset

        //    // Restore the List
        //    Engine.PlayerList = saveList;
        //    Engine.StartBattle(false);   // Clear the Engine

        //    // Assert
        //    Assert.AreEqual(null, result);
        //}

        //[Test]
        //public void TurnEngine_SelectMonsterToAttack_InValid_Alive_Character_List_Should_Fail()
        //{
        //    // Arrange

        //    // remember the list
        //    var saveList = Engine.PlayerList;

        //    Engine.PlayerList = new List<PlayerInfoModel>();

        //    var data = new PlayerInfoModel(new MonsterModel());
        //    data.Alive = true;
        //    data.PlayerType = PlayerTypeEnum.Character;
        //    Engine.PlayerList.Add(data);

        //    // Act
        //    var result = Engine.SelectMonsterToAttack();

        //    // Reset

        //    // Restore the List
        //    Engine.PlayerList = saveList;
        //    Engine.StartBattle(false);   // Clear the Engine

        //    // Assert
        //    Assert.AreEqual(null, result);
        //}

        [Test]
        public void TurnEngine_SelectMonsterToAttack_Valid_List_Should_Pass()
        {
            // Arrange

            // remember the list
            var saveList = Engine.PlayerList;

            Engine.PlayerList = new List<PlayerInfoModel>();

            var data = new PlayerInfoModel(new MonsterModel());
            Engine.PlayerList.Add(data);

            // Act
            var result = Engine.SelectMonsterToAttack();

            // Reset

            // Restore the List
            Engine.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreNotEqual(null, result);
        }

        // mike

        [Test]
        public void TurnEngine_SelectCharacterToAttack_InValid_Null_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.PlayerList;

            Engine.PlayerList = null;

            // Act
            var result = Engine.SelectCharacterToAttack();

            // Reset

            // Restore the List
            Engine.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectCharacterToAttack_InValid_Empty_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.PlayerList;

            Engine.PlayerList = new List<PlayerInfoModel>();

            // Act
            var result = Engine.SelectCharacterToAttack();

            // Reset

            // Restore the List
            Engine.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectCharacterToAttack_InValid_Dead_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.PlayerList;

            Engine.PlayerList = new List<PlayerInfoModel>();

            var data = new PlayerInfoModel(new CharacterModel());
            data.Alive = false;
            Engine.PlayerList.Add(data);

            // Act
            var result = Engine.SelectCharacterToAttack();

            // Reset

            // Restore the List
            Engine.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectCharacterToAttack_InValid_Dead_Monster_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.PlayerList;

            Engine.PlayerList = new List<PlayerInfoModel>();

            var data = new PlayerInfoModel(new CharacterModel());
            data.Alive = false;
            data.PlayerType = PlayerTypeEnum.Monster;
            Engine.PlayerList.Add(data);

            // Act
            var result = Engine.SelectCharacterToAttack();

            // Reset

            // Restore the List
            Engine.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void TurnEngine_SelectCharacterToAttack_InValid_Alive_Monster_List_Should_Fail()
        {
            // Arrange

            // remember the list
            var saveList = Engine.PlayerList;

            Engine.PlayerList = new List<PlayerInfoModel>();

            var data = new PlayerInfoModel(new CharacterModel());
            data.Alive = true;
            data.PlayerType = PlayerTypeEnum.Monster;
            Engine.PlayerList.Add(data);

            // Act
            var result = Engine.SelectCharacterToAttack();

            // Reset

            // Restore the List
            Engine.PlayerList = saveList;
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(null, result);
        }

        //[Test]
        //public void TurnEngine_SelectCharacterToAttack_Valid_List_Should_Pass()
        //{
        //    // Arrange

        //    // remember the list
        //    var saveList = Engine.PlayerList;

        //    Engine.PlayerList = new List<PlayerInfoModel>();

        //    var data = new PlayerInfoModel(new CharacterModel());
        //    Engine.PlayerList.Add(data);

        //    // Act
        //    var result = Engine.SelectCharacterToAttack();

        //    // Reset

        //    // Restore the List
        //    Engine.PlayerList = saveList;
        //    Engine.StartBattle(false);   // Clear the Engine

        //    // Assert
        //    Assert.AreNotEqual(null, result);
        //}


        //[Test]
        //public void TurnEngine_RolltoHitTarget_Hit_Should_Pass()
        //{
        //    // Arrange
        //    var AttackScore = 10;
        //    var DefenseScore = 0;

        //    DiceHelper.EnableForcedRolls();
        //    DiceHelper.SetForcedRollValue(3); // Always roll a 3.

        //    // Act
        //    var result = Engine.RollToHitTarget(AttackScore, DefenseScore);

        //    // Reset
        //    DiceHelper.DisableForcedRolls();

        //    // Assert
        //    Assert.AreEqual(HitStatusEnum.Hit, result);
        //}

        //[Test]
        //public void TurnEngine_RolltoHitTarget_Miss_Should_Pass()
        //{
        //    // Arrange
        //    var AttackScore = 1;
        //    var DefenseScore = 100;

        //    DiceHelper.EnableForcedRolls();
        //    DiceHelper.SetForcedRollValue(2);

        //    // Act
        //    var result = Engine.RollToHitTarget(AttackScore, DefenseScore);

        //    // Reset
        //    DiceHelper.DisableForcedRolls();

        //    // Assert
        //    Assert.AreEqual(HitStatusEnum.Miss, result);
        //}

        [Test]
        public void TurnEngine_RolltoHitTarget_Forced_1_Should_Miss()
        {
            // Arrange
            var AttackScore = 1;
            var DefenseScore = 100;

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(1);

            // Act
            var result = Engine.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }

        [Test]
        public void TurnEngine_RolltoHitTarget_Forced_20_Should_Hit()
        {
            // Arrange
            var AttackScore = 1;
            var DefenseScore = 100;

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Act
            var result = Engine.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }

        [Test]
        public void TurnEngine_TakeTurn_Default_Should_Pass()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel(new CharacterModel());

            // Act
            var result = Engine.TakeTurn(PlayerInfo);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        //[Test]
        //public void TurnEngine_TakeTurn_Ability_Should_Pass()
        //{
        //    // Arrange

        //    Engine.CurrentAction = ActionEnum.Ability;
        //    Engine.CurrentActionAbility = AbilityEnum.Bandage;

        //    var PlayerInfo = new PlayerInfoModel(new CharacterModel());

        //    // Act
        //    var result = Engine.TakeTurn(PlayerInfo);

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(true, result);
        //}

        [Test]
        public void TurnEngine_TakeTurn_Move_Should_Pass()
        {
            // Arrange

            Engine.CurrentAction = ActionEnum.Move;

            var character = new PlayerInfoModel(new CharacterModel());
            var monster = new PlayerInfoModel(new CharacterModel());

            Engine.PlayerList.Add(character);
            Engine.PlayerList.Add(monster);

            Engine.MapModel.PopulateMapModel(Engine.PlayerList);

            // Act
            var result = Engine.TakeTurn(character);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_DropItems_No_Items_Should_Return_0()
        {
            // Arrange
            var player = new CharacterModel();

            var PlayerInfo = new PlayerInfoModel(player);

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(0);

            // Act
            var result = Engine.DropItems(PlayerInfo);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TurnEngine_DropItems_Character_Items_2_Should_Return_2()
        {
            // Arrange
            var player = new CharacterModel
            {
                Head = ItemIndexViewModel.Instance.Dataset.FirstOrDefault().Id,
                Feet = ItemIndexViewModel.Instance.Dataset.FirstOrDefault().Id,
            };

            var PlayerInfo = new PlayerInfoModel(player);

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(0);

            // Act
            var result = Engine.DropItems(PlayerInfo);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(2, result);
        }

        //[Test]
        //public void TurnEngine_DropItems_Monster_Items_0_Random_Drop_1_Should_Return_1()
        //{
        //    // Arrange
        //    var player = new CharacterModel();

        //    var PlayerInfo = new PlayerInfoModel(player);

        //    DiceHelper.EnableForcedRolls();

        //    // Drop is 0-Number, so 2 will yield 1
        //    DiceHelper.SetForcedRollValue(2);

        //    // Act
        //    var result = Engine.DropItems(PlayerInfo);

        //    // Reset
        //    DiceHelper.DisableForcedRolls();

        //    // Assert
        //    Assert.AreEqual(1, result);
        //}

        [Test]
        public void TurnEngine_TargedDied_Character_Should_Pass()
        {
            // Arrange
            var player = new CharacterModel();

            var PlayerInfo = new PlayerInfoModel(player);
            Engine.CharacterList.Add(PlayerInfo);

            // Act
            var result = Engine.TargetDied(PlayerInfo);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TargedDied_Monseter_Should_Pass()
        {
            // Arrange
            var player = new MonsterModel();

            var PlayerInfo = new PlayerInfoModel(player);
            Engine.CharacterList.Add(PlayerInfo);

            // Act
            var result = Engine.TargetDied(PlayerInfo);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TurnAsAttack_Character_Attacks_Null_Should_Fail()
        {
            // Arrange
            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.CharacterList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.MonsterList.Add(MonsterPlayer);

            // Act
            var result = Engine.TurnAsAttack(CharacterPlayer, null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_TurnAsAttack_Null_Attacks_Character_Should_Fail()
        {
            // Arrange
            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.CharacterList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.MonsterList.Add(MonsterPlayer);

            // Act
            var result = Engine.TurnAsAttack(null, CharacterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_TurnAsAttack_Character_Attacks_Monster_Miss_Should_Pass()
        {
            // Arrange
            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.CharacterList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.MonsterList.Add(MonsterPlayer);

            // Forece a Miss
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(1);

            // Act
            var result = Engine.TurnAsAttack(CharacterPlayer, MonsterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TurnAsAttack_Character_Attacks_Monster_Hit_Should_Pass()
        {
            // Arrange
            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.CharacterList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.MonsterList.Add(MonsterPlayer);

            // Forece a Miss
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Act
            var result = Engine.TurnAsAttack(CharacterPlayer, MonsterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
        }


        [Test]
        public void TurnEngine_TurnAsAttack_Character_Attacks_Monster_Hit_Death_Should_Pass()
        {
            // Arrange
            var Character = new CharacterModel();
            Character.CurrentHealth = 1;
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.CharacterList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.MonsterList.Add(MonsterPlayer);

            // Forece a Miss
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Act
            var result = Engine.TurnAsAttack(CharacterPlayer, MonsterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TurnAsAttack_Monster_Attacks_Character_Miss_Should_Pass()
        {
            // Arrange
            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.CharacterList.Add(CharacterPlayer);

            // Forece a Miss
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(1);

            // Act
            var result = Engine.TurnAsAttack(MonsterPlayer, CharacterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TurnAsAttack_Monster_Attacks_Character_Hit_Should_Pass()
        {
            // Arrange
            var Monster = new MonsterModel();
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel();
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.CharacterList.Add(CharacterPlayer);

            // Forece a Miss
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            // Act
            var result = Engine.TurnAsAttack(MonsterPlayer, CharacterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_RemoveIfDead_Dead_True_Should_Return_False()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                CurrentHealth = 1,
                Alive = true,
                Guid = "me"
            };

            var PlayerInfo = new PlayerInfoModel(Monster);

            Engine.MonsterList.Clear();
            Engine.MonsterList.Add(PlayerInfo);
            Engine.MakePlayerList();

            // Act
            var result = Engine.RemoveIfDead(PlayerInfo);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_RemoveIfDead_Dead_false_Should_Return_true()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                CurrentHealth = 1,
                Alive = true,
                Guid = "me"
            };

            var PlayerInfo = new PlayerInfoModel(Monster);

            Engine.MonsterList.Clear();
            Engine.MonsterList.Add(PlayerInfo);
            Engine.MakePlayerList();

            // Act
            var result = Engine.RemoveIfDead(PlayerInfo);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        //[Test]
        //public void TurnEngine_TurnAsAttack_Character_Attacks_Monster_Levels_Up_Should_Pass()
        //{
        //    // Arrange
        //    var Monster = new MonsterModel();
        //    var MonsterPlayer = new PlayerInfoModel(Monster);
        //    Engine.MonsterList.Add(MonsterPlayer);

        //    var Character = new CharacterModel();

        //    var CharacterPlayer = new PlayerInfoModel(Character);

        //    CharacterPlayer.ExperienceTotal = 300;    // Enough for next level

        //    Engine.CharacterList.Add(CharacterPlayer);

        //    // Forece a Miss
        //    DiceHelper.EnableForcedRolls();
        //    DiceHelper.SetForcedRollValue(20);

        //    // Act
        //    var result = Engine.TurnAsAttack(CharacterPlayer, MonsterPlayer);

        //    // Reset
        //    DiceHelper.DisableForcedRolls();

        //    // Assert
        //    Assert.AreEqual(true, result);
        //    Assert.AreEqual(2, CharacterPlayer.Level);
        //}

        [Test]
        public void TurnEngine_UseAbility_InValid_Ability_Null_Should_Fail()
        {
            // Arrange
            Engine.CurrentActionAbility = AbilityEnum.Unknown;

            var characterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Unknown });

            // remove it so it is not found
            characterPlayer.AbilityTracker.Remove(AbilityEnum.Unknown);

            // Act
            var result = Engine.UseAbility(characterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_UseAbility_InValid_Ability_Count_0_Should_Fail()
        {
            // Arrange
            Engine.CurrentActionAbility = AbilityEnum.Unknown;

            var characterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Unknown });

            // remove it so it is not found
            characterPlayer.AbilityTracker[AbilityEnum.Unknown] = 0;

            // Act
            var result = Engine.UseAbility(characterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_UseAbility_Valid_Ability_Heal_1_Should_Pass()
        {
            // Arrange

            var characterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Unknown });

            // remove it so it is not found
            characterPlayer.AbilityTracker.Add(AbilityEnum.Heal, 1);
            Engine.CurrentActionAbility = AbilityEnum.Heal;

            // Act
            var result = Engine.UseAbility(characterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_UseAbility_Valid_Ability_Toughness_1_Should_Pass()
        {
            // Arrange

            var characterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Unknown });

            // remove it so it is not found
            characterPlayer.AbilityTracker.Add(AbilityEnum.Toughness, 1);
            Engine.CurrentActionAbility = AbilityEnum.Toughness;

            // Act
            var result = Engine.UseAbility(characterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_UseAbility_Valid_Ability_Quick_1_Should_Pass()
        {
            // Arrange

            var characterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Unknown });

            // remove it so it is not found
            characterPlayer.AbilityTracker.Add(AbilityEnum.Quick, 1);
            Engine.CurrentActionAbility = AbilityEnum.Quick;

            // Act
            var result = Engine.UseAbility(characterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_UseAbility_Valid_Ability_Curse_1_Should_Pass()
        {
            // Arrange

            var characterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Unknown });

            // remove it so it is not found
            characterPlayer.AbilityTracker.Add(AbilityEnum.Curse, 1);
            Engine.CurrentActionAbility = AbilityEnum.Curse;

            // Act
            var result = Engine.UseAbility(characterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_BattleSettingsOverrideHitStatusEnum_Hit_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine.BattleSettingsOverrideHitStatusEnum(HitStatusEnum.Hit);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }

        [Test]
        public void TurnEngine_BattleSettingsOverrideCriticalHitStatusEnum_CriticalHit_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine.BattleSettingsOverrideHitStatusEnum(HitStatusEnum.CriticalHit);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.CriticalHit, result);
        }

        [Test]
        public void TurnEngine_BattleSettingsOverrideCriticalMissStatusEnum_CriticalMiss_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine.BattleSettingsOverrideHitStatusEnum(HitStatusEnum.CriticalMiss);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.CriticalMiss, result);
        }

        [Test]
        public void TurnEngine_BattleSettingsOverrideMissStatusEnum_Miss_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine.BattleSettingsOverrideHitStatusEnum(HitStatusEnum.Miss);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }

        [Test]
        public void TurnEngine_DetermineCriticalMissProblem_InValid_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = Engine.DetermineCriticalMissProblem(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_DetermineCriticalMissProblem_Monster_Drops_Random_Should_Pass()
        {
            // Arrange
            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(6);

            // Act
            var result = Engine.DetermineCriticalMissProblem(MonsterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(true, result);
        }

        //[Test]
        //public void TurnEngine_TakeTurn_Unknown_Should_Return_false()
        //{
        //    // Arrange
        //    var CharacterPlayer = new PlayerInfoModel(new CharacterModel());

        //    Engine.CurrentAction = ActionEnum.Unknown;

        //    // Act
        //    var result = Engine.TakeTurn(CharacterPlayer);

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(false, result);
        //}

        //[Test]
        //public void TurnEngine_DetermineActionChoice_Monster_Should_Return_CurrentAction()
        //{
        //    // Arrange
        //    var MonsterPlayer = new PlayerInfoModel(new MonsterModel());

        //    MonsterPlayer.CurrentHealth = 1;
        //    MonsterPlayer.MaxHealth = 1000;

        //    Engine.CurrentAction = ActionEnum.Unknown;

        //    // Act
        //    var result = Engine.DetermineActionChoice(MonsterPlayer);

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(ActionEnum.Ability, result);
        //}

        //[Test]
        //public void TurnEngine_DetermineActionChoice_Character_Should_Return_CurrentAction()
        //{
        //    // Arrange
        //    var CharacterPlayer = new PlayerInfoModel(new CharacterModel());

        //    CharacterPlayer.CurrentHealth = 1;
        //    CharacterPlayer.MaxHealth = 1000;

        //    Engine.CurrentAction = ActionEnum.Unknown;
        //    Engine.BattleScore.AutoBattle = true;

        //    // Act
        //    var result = Engine.DetermineActionChoice(CharacterPlayer);

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(ActionEnum.Ability, result);
        //}

        [Test]
        public void TurnEngine_DetermineActionChoice_Character_Range_Should_Return_Attack()
        {
            // Arrange

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel());

            // Get the longest range weapon in stock.
            var weapon = ItemIndexViewModel.Instance.Dataset.Where(m => m.Range > 1).ToList().OrderByDescending(m => m.Range).FirstOrDefault();
            CharacterPlayer.PrimaryHand = weapon.Id;
            Engine.PlayerList.Add(CharacterPlayer);

            var Monster = new MonsterModel();
            Engine.PlayerList.Add(new PlayerInfoModel(Monster));
            Engine.PlayerList.Add(new PlayerInfoModel(Monster));

            Engine.MapModel.PopulateMapModel(Engine.PlayerList);

            Engine.CurrentAction = ActionEnum.Unknown;
            Engine.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.DetermineActionChoice(CharacterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(ActionEnum.Attack, result);
        }

        //[Test]
        //public void TurnEngine_ChooseToUseAbility_Heal_Should_Return_True()
        //{
        //    // Arrange

        //    var CharacterPlayer = new PlayerInfoModel(new CharacterModel());

        //    // Get the longest range weapon in stock.
        //    var weapon = ItemIndexViewModel.Instance.Dataset.Where(m => m.Range > 1).ToList().OrderByDescending(m => m.Range).FirstOrDefault();
        //    CharacterPlayer.PrimaryHand = weapon.Id;
        //    CharacterPlayer.CurrentHealth = 1;
        //    CharacterPlayer.MaxHealth = 100;

        //    Engine.PlayerList.Add(CharacterPlayer);

        //    Engine.MapModel.PopulateMapModel(Engine.PlayerList);

        //    Engine.CurrentAction = ActionEnum.Unknown;
        //    Engine.BattleScore.AutoBattle = true;

        //    // Act
        //    var result = Engine.ChooseToUseAbility(CharacterPlayer);

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(true, result);
        //}

        //[Test]
        //public void TurnEngine_ChooseToUseAbility_Roll_9_Should_Return_False()
        //{
        //    // Arrange

        //    var CharacterPlayer = new PlayerInfoModel(new CharacterModel());

        //    // Get the longest range weapon in stock.
        //    var weapon = ItemIndexViewModel.Instance.Dataset.Where(m => m.Range > 1).ToList().OrderByDescending(m => m.Range).FirstOrDefault();
        //    CharacterPlayer.PrimaryHand = weapon.Id;

        //    Engine.PlayerList.Add(CharacterPlayer);

        //    Engine.MapModel.PopulateMapModel(Engine.PlayerList);

        //    Engine.CurrentAction = ActionEnum.Unknown;
        //    Engine.BattleScore.AutoBattle = true;

        //    DiceHelper.EnableForcedRolls();
        //    DiceHelper.SetForcedRollValue(9);
        //    // Act
        //    var result = Engine.ChooseToUseAbility(CharacterPlayer);

        //    // Reset
        //    DiceHelper.DisableForcedRolls();

        //    // Assert
        //    Assert.AreEqual(false, result);
        //}

        [Test]
        public void TurnEngine_ChooseToUseAbility_Roll_2_No_Ability_Should_Return_False()
        {
            // Arrange

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel());

            // Get the longest range weapon in stock.
            var weapon = ItemIndexViewModel.Instance.Dataset.Where(m => m.Range > 1).ToList().OrderByDescending(m => m.Range).FirstOrDefault();
            CharacterPlayer.PrimaryHand = weapon.Id;
            CharacterPlayer.AbilityTracker.Clear();

            Engine.PlayerList.Add(CharacterPlayer);

            Engine.MapModel.PopulateMapModel(Engine.PlayerList);

            Engine.CurrentAction = ActionEnum.Unknown;
            Engine.BattleScore.AutoBattle = true;

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(2);
            // Act
            var result = Engine.ChooseToUseAbility(CharacterPlayer);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(false, result);
        }

        //[Test]
        //public void TurnEngine_ChooseToUseAbility_Roll_2_Yes_Ability_Should_Return_True()
        //{
        //    // Arrange

        //    var CharacterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });

        //    // Get the longest range weapon in stock.
        //    var weapon = ItemIndexViewModel.Instance.Dataset.Where(m => m.Range > 1).ToList().OrderByDescending(m => m.Range).FirstOrDefault();
        //    CharacterPlayer.PrimaryHand = weapon.Id;

        //    Engine.PlayerList.Add(CharacterPlayer);

        //    Engine.MapModel.PopulateMapModel(Engine.PlayerList);

        //    Engine.CurrentAction = ActionEnum.Unknown;
        //    Engine.BattleScore.AutoBattle = true;

        //    DiceHelper.EnableForcedRolls();
        //    DiceHelper.SetForcedRollValue(2);
        //    // Act
        //    var result = Engine.ChooseToUseAbility(CharacterPlayer);

        //    // Reset
        //    DiceHelper.DisableForcedRolls();

        //    // Assert
        //    Assert.AreEqual(true, result);
        //}

        [Test]
        public void TurnEngine_MoveAsTurn_Character_Should_Pass()
        {
            // Arrange

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });

            Engine.PlayerList.Add(CharacterPlayer);

            Engine.MapModel.PopulateMapModel(Engine.PlayerList);

            Engine.CurrentAction = ActionEnum.Unknown;
            Engine.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.MoveAsTurn(CharacterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        //[Test]
        //public void TurnEngine_MoveAsTurn_Monster_Should_Pass()
        //{
        //    // Arrange

        //    var MonsterPlayer = new PlayerInfoModel(new MonsterModel());
        //    Engine.PlayerList.Add(MonsterPlayer);

        //    var CharacterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
        //    Engine.PlayerList.Add(CharacterPlayer);

        //    Engine.MapModel.PopulateMapModel(Engine.PlayerList);

        //    Engine.CurrentAction = ActionEnum.Unknown;
        //    Engine.BattleScore.AutoBattle = true;

        //    // Act
        //    var result = Engine.MoveAsTurn(MonsterPlayer);

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(true, result);
        //}

        [Test]
        public void TurnEngine_MoveAsTurn_Monster_InValid_No_Defender_Should_Fail()
        {
            // Arrange

            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());

            // Remove everyone
            Engine.PlayerList.Clear();

            Engine.PlayerList.Add(MonsterPlayer);

            Engine.MapModel.PopulateMapModel(Engine.PlayerList);

            Engine.CurrentAction = ActionEnum.Unknown;
            Engine.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.MoveAsTurn(MonsterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_MoveAsTurn_Monster_InValid_Defender_Not_On_Map_Should_Fail()
        {
            // Arrange
            var CharacterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            Engine.PlayerList.Add(CharacterPlayer);

            // Not on map.... 
            Engine.MapModel.PopulateMapModel(Engine.PlayerList);

            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());
            Engine.PlayerList.Add(MonsterPlayer);

            Engine.CurrentAction = ActionEnum.Unknown;
            Engine.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.MoveAsTurn(MonsterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_MoveAsTurn_Monster_InValid_Attacker_Not_On_Map_Should_Fail()
        {
            // Arrange

            var MonsterPlayer = new PlayerInfoModel(new MonsterModel());
            Engine.PlayerList.Add(MonsterPlayer);

            Engine.MapModel.PopulateMapModel(Engine.PlayerList);

            // Add player after map is made, so player is not on the map

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel { Job = CharacterJobEnum.Cleric });
            Engine.PlayerList.Add(CharacterPlayer);

            Engine.CurrentAction = ActionEnum.Unknown;
            Engine.BattleScore.AutoBattle = true;

            // Act
            var result = Engine.MoveAsTurn(MonsterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
    }
}