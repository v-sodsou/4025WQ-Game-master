﻿using NUnit.Framework;

using Game.Models;
using Game.Helpers;

namespace UnitTests.Models
{
    [TestFixture]
    public class ItemModelTests
    {
        [Test]
        public void ItemModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ItemModel();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemModel_Constructor_New_Item_Should_Copy()
        {
            // Arrange
            var dataNew = new ItemModel();
            dataNew.Value = 2;
            dataNew.Id = "oldID";

            // Act
            var result = new ItemModel(dataNew);

            // Reset

            // Assert 
            Assert.AreNotEqual("oldID", result.Id);
        }

    }
}