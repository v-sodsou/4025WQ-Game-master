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
    }
}
