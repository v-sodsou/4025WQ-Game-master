using Game.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models
{
    [TestFixture]
    class BaseModelTests
    {
        [Test]
        public void BaseModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BaseModel<ItemModel>();

            // Reset

            // Assert
            Assert.AreEqual("Enter a name here...", result.Name);
        }

        [Test]
        public void BaseModel_Set_Default_Should_Pass()
        {
            // Arrange
            var result = new BaseModel<ItemModel>();

            // Act
            result.Id = "bogus";
            result.ImageURI = "uri";

            // Reset

            // Assert
            Assert.AreEqual("bogus", result.Id);
            Assert.AreEqual("uri", result.ImageURI);
        }

    }
}
