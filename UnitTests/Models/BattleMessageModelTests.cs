using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    class BattleMessageModelTests
    {
        [Test]
        public void BattleMessageModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BattleMessagesModel();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
