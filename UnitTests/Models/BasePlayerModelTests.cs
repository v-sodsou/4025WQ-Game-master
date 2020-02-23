using Game.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Models
{
    [TestFixture]
    class BasePlayerModelTests
    {
        [TearDown]
        public async Task TearDown()
        {
            await Game.Helpers.DataSetsHelper.WipeData();
        }

        [Test]
        public void BasePlayerModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BasePlayerModel<CharacterModel>();

            // Reset

            // Assert
            Assert.AreEqual("Enter a name here...", result.Name);
        }

        [Test]
        public void BasePlayerModel_GetItemByLocation_Head_Default_Should_Pass()
        {
            // Arrange
            var data = new BasePlayerModel<CharacterModel>();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.Head);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public void BasePlayerModel_GetItemByLocation_Feet_Default_Should_Pass()
        {
            // Arrange
            var data = new BasePlayerModel<CharacterModel>();

            // Act
            var result = data.GetItemByLocation(ItemLocationEnum.Feet);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

    }
}
