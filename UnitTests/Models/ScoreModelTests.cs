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

    }
}
