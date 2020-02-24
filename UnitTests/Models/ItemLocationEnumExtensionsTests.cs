using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    class ItemLocationEnumExtensionsTests
    {
        [Test]
        public void ItemLocationEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Unknown", result);
        }
    }
}
