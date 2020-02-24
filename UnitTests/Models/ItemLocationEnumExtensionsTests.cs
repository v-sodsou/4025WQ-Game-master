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

        [Test]
        public void ItemLocationEnumExtensionsTests_Head_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnum.Head.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Head", result);
        }

        [Test]
        public void ItemLocationEnumExtensionsTests_Necklass_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnum.Necklass.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Necklass", result);
        }

        [Test]
        public void ItemLocationEnumExtensionsTests_PrimaryHand_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ItemLocationEnum.PrimaryHand.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Primary Hand", result);
        }
    }
}
