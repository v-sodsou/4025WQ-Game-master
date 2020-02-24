using NUnit.Framework;

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

    }
}
