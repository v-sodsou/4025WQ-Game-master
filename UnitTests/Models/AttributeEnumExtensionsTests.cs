using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class AttributeEnumExtensionsTests
    {
        [Test]
        public void AttributeEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AttributeEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Unknown", result);
        }
    }
}