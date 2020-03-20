using NUnit.Framework;

using Game.Helpers;
using Game.Models;
using Game.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Helpers
{
    [TestFixture]
    public class RandomPlayerHelperTests
    {
        [Test]
        public void RandomPlayerHelper_GetAbilityValue_2_Should_Return_2()
        {
            // Arrange
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(2);

            // Act
            var result = RandomPlayerHelper.GetAbilityValue();

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(2 - 1, result);
        }

        [Test]
        public void RandomPlayerHelper_GetLevel_2_Should_Return_2()
        {
            // Arrange
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(2);

            // Act
            var result = RandomPlayerHelper.GetLevel();

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void RandomPlayerHelper_GetHealth_2_Should_Return_2()
        {
            // Arrange
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(2);

            // Act
            var result = RandomPlayerHelper.GetHealth(1);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void RandomPlayerHelper_GetMonsterName_2_Should_Return_2()
        {
            // Arrange
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(2);

            // Act
            var result = RandomPlayerHelper.GetMonsterName();

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual("Palpatine", result);
        }

      

        [Test]
        public void RandomPlayerHelper_GetCharacterDescription_2_Should_Return_2()
        {
            // Arrange
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(2);

            // Act
            var result = RandomPlayerHelper.GetCharacterDescription();

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual("the awesome", result);
        }

        [Test]
        public void RandomPlayerHelper_GetCharacterName_2_Should_Return_2()
        {
            // Arrange
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(2);

            // Act
            var result = RandomPlayerHelper.GetCharacterName();

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual("Chewy", result);
        }


        [Test]
        public void RandomPlayerHelper_GetMonsterDifficultyValue_Should_Pass()
        {
            // Arrange
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(2);

            // Act
            var result = RandomPlayerHelper.GetMonsterDifficultyValue();

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(DifficultyEnum.Average, result);
        }

     
       

        [Test]
        public void RandomPlayerHelper_GetCharacterImage_2_Should_Return_2()
        {
            // Arrange
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(2);

            // Act
            var result = RandomPlayerHelper.GetCharacterImage();

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual("chewy_solo.png", result);
        }

      
        [Test]
        public void RandomPlayerHelper_GetRandomMonster_InValid_Empty_List_Should_Return_New_Monster()
        {
            // Arrange
            var save = MonsterIndexViewModel.Instance.Dataset;
            MonsterIndexViewModel.Instance.Dataset.Clear();

            // Act
            var result = RandomPlayerHelper.GetRandomMonster(1);

            // Reset
            MonsterIndexViewModel.Instance.Dataset = save;

            // Assert
            Assert.AreEqual(PlayerTypeEnum.Monster, result.PlayerType);
        }

        [Test]
        public void RandomPlayerHelper_GetRandomMonster_Valid_Should_Return_New_Monster()
        {
            // Arrange

            // Act
            var result = RandomPlayerHelper.GetRandomMonster(1);

            // Reset

            // Assert
            Assert.AreEqual(PlayerTypeEnum.Monster, result.PlayerType);
        }

      

        [Test]
        public void RandomPlayerHelper_GetRandomMonster_Valid_Items_False_Should_Return_New_Monster()
        {
            // Arrange

            // Act
            var result = RandomPlayerHelper.GetRandomMonster(1, false);

            // Reset

            // Assert
            Assert.AreEqual(PlayerTypeEnum.Monster, result.PlayerType);
        }
    }
}