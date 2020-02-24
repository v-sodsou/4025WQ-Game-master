﻿using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    class ScoreModelTests
    {
        [Test]
        // Score Model Constructor UT
        public void ScoreModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ScoreModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        [Test]
        // Score Model Constructor Compare two objects are not the same
        public void ScoreModel_Constructor_New_Item_Should_Copy()
        {
            // Arrange
            var dataNew = new ScoreModel();

            dataNew.Id = "oldID";

            dataNew.BattleNumber = 100;
            dataNew.ScoreTotal = 200;
            dataNew.GameDate = System.DateTime.MinValue;
            dataNew.AutoBattle = true;
            dataNew.TurnCount = 300;
            dataNew.RoundCount = 400;
            dataNew.MonsterSlainNumber = 500;
            dataNew.ExperienceGainedTotal = 600;
            dataNew.CharacterAtDeathList = "characters";
            dataNew.MonstersKilledList = "monsters";
            dataNew.ItemsDroppedList = "items";


            // Act
            var result = new ScoreModel(dataNew);

            // Reset

            // Assert 
            Assert.AreNotEqual("oldID", result.Id);
        }

        [Test]
        // Score Model Get Default Test
        public void ScoreModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ScoreModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result.BattleNumber);
            Assert.IsNotNull(result.ScoreTotal);
            Assert.IsNotNull(result.GameDate);
            Assert.IsNotNull(result.AutoBattle);
            Assert.IsNotNull(result.TurnCount);
            Assert.IsNotNull(result.RoundCount);
            Assert.IsNotNull(result.MonsterSlainNumber);
            Assert.IsNotNull(result.ExperienceGainedTotal);

            Assert.AreEqual(string.Empty, result.CharacterAtDeathList);
            Assert.AreEqual(string.Empty, result.MonstersKilledList);
            Assert.AreEqual(string.Empty, result.ItemsDroppedList);
        }

        [Test]
        // Score model Set Default
        public void ScoreModel_Set_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ScoreModel();
            result.BattleNumber = 100;
            result.ScoreTotal = 200;
            result.GameDate = System.DateTime.MinValue;
            result.AutoBattle = true;
            result.TurnCount = 300;
            result.RoundCount = 400;
            result.MonsterSlainNumber = 500;
            result.ExperienceGainedTotal = 600;
            result.CharacterAtDeathList = "characters";
            result.MonstersKilledList = "monsters";
            result.ItemsDroppedList = "items";

            // Reset

            // Assert 
            Assert.AreEqual(100, result.BattleNumber);
            Assert.AreEqual(200, result.ScoreTotal);
            Assert.AreEqual(System.DateTime.MinValue, result.GameDate);
            Assert.AreEqual(true, result.AutoBattle);
            Assert.AreEqual(300, result.TurnCount);
            Assert.AreEqual(400, result.RoundCount);
            Assert.AreEqual(500, result.MonsterSlainNumber);
            Assert.AreEqual(600, result.ExperienceGainedTotal);
            Assert.AreEqual("characters", result.CharacterAtDeathList);
            Assert.AreEqual("monsters", result.MonstersKilledList);
            Assert.AreEqual("items", result.ItemsDroppedList);
        }

        [Test]
        // Score Model Update Test
        public void ScoreModel_Update_Default_Should_Pass()
        {
            // Arrange
            var dataOriginal = new ScoreModel();

            var dataNew = new ScoreModel();
            dataNew.BattleNumber = 100;
            dataNew.ScoreTotal = 200;
            dataNew.GameDate = System.DateTime.MinValue;
            dataNew.AutoBattle = true;
            dataNew.TurnCount = 300;
            dataNew.RoundCount = 400;
            dataNew.MonsterSlainNumber = 500;
            dataNew.ExperienceGainedTotal = 600;
            dataNew.CharacterAtDeathList = "characters";
            dataNew.MonstersKilledList = "monsters";
            dataNew.ItemsDroppedList = "items";

            // Act
            var result = dataOriginal.Update(dataNew);

            // Reset

            // Assert 
            Assert.AreEqual(100, dataNew.BattleNumber);
            Assert.AreEqual(200, dataNew.ScoreTotal);
            Assert.AreEqual(System.DateTime.MinValue, dataNew.GameDate);
            Assert.AreEqual(true, dataNew.AutoBattle);
            Assert.AreEqual(300, dataNew.TurnCount);
            Assert.AreEqual(400, dataNew.RoundCount);
            Assert.AreEqual(500, dataNew.MonsterSlainNumber);
            Assert.AreEqual(600, dataNew.ExperienceGainedTotal);
            Assert.AreEqual("characters", dataNew.CharacterAtDeathList);
            Assert.AreEqual("monsters", dataNew.MonstersKilledList);
            Assert.AreEqual("items", dataNew.ItemsDroppedList);
        }


    }
}
