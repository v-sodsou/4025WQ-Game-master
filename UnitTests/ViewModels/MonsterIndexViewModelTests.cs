using Game.Models;
using Game.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Mocks;

namespace UnitTests.ViewModels
{
    class MonsterIndexViewModelTests
    {
        MonsterIndexViewModel ViewModel;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            ViewModel = MonsterIndexViewModel.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            MonsterIndexViewModel.Instance.Dataset.Clear();
        }

        [Test]
        public async Task MonsterIndexViewModel_Read_Invalid_ID_Should_Fail()
        {
            // Arrange

            // Act
            var result = await ViewModel.ReadAsync("bogus");

            // Reset

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task MonsterIndexViewModel_Update_Invalid_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = await ViewModel.UpdateAsync(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public async Task MonsterIndexViewModel_Create_Valid_Should_Pass()
        {
            // Arrange
            var data = new MonsterModel
            {
                Name = "New Item"
            };

            // Act
            var result = await ViewModel.CreateAsync(data);

            // Reset

            // Assert
            Assert.AreEqual(true, result);  // Update returned Pass
        }

        [Test]
        public async Task MonsterIndexViewModel_Create_InValid_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = await ViewModel.CreateAsync(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MonsterIndexViewModel_ExecuteLoadDataCommand_Valid_Should_Pass()
        {
            // Arrange

            // Clear the Dataset, so no records
            ViewModel.Dataset.Clear();

            // Act
            ViewModel.LoadDatasetCommand.Execute(null);

            // Reset

            // Assert
            Assert.AreEqual(true, ViewModel.Dataset.Count() > 0); // Check that there are rows of data
        }

    }
}
