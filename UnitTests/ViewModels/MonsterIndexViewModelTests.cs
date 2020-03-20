using Game.Models;
using Game.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
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
        public async Task MonsterIndexViewModel_Read_Invalid_ID_Bogus_Should_Fail()
        {
            // Arrange

            // Act
            var result = await ViewModel.ReadAsync("bogus");

            // Reset

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void MonsterIndexViewModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterIndexViewModel_SortDataSet_Default_Should_Pass()
        {
            // Arrange

            // Add items into the list Z ordered
            var dataList = new List<MonsterModel>
            {
                new MonsterModel { Name = "z" },
                new MonsterModel { Name = "m" },
                new MonsterModel { Name = "a" }
            };

            // Act
            var result = ViewModel.SortDataset(dataList);

            // Reset

            // Assert
            Assert.AreEqual("a", result[0].Name);
            Assert.AreEqual("m", result[1].Name);
            Assert.AreEqual("z", result[2].Name);
        }

        [Test]
        public async Task MonsterIndexViewModel_CheckIfItemExists_Default_Should_Pass()
        {
            // Arrange

            // Add items into the list Z ordered
            var dataTest = new MonsterModel { Name = "test" };
            await ViewModel.CreateAsync(dataTest);

            await ViewModel.CreateAsync(new MonsterModel { Name = "z" });
            await ViewModel.CreateAsync(new MonsterModel { Name = "m" });
            await ViewModel.CreateAsync(new MonsterModel { Name = "a" });

            // Act
            var result = ViewModel.CheckIfExists(dataTest);

            // Reset

            // Assert
            Assert.AreEqual(dataTest.Id, result.Id);
        }

        [Test]
        public async Task MonsterIndexViewModel_CheckIfItemExists_InValid_Missing_Should_Fail()
        {
            // Arrange

            // Add items into the list Z ordered
            var dataTest = new MonsterModel { Name = "test" };
            // Don't add it to the list await ViewModel.CreateAsync(dataTest);

            await ViewModel.CreateAsync(new MonsterModel { Name = "z" });
            await ViewModel.CreateAsync(new MonsterModel { Name = "m" });
            await ViewModel.CreateAsync(new MonsterModel { Name = "a" });

            // Act
            var result = ViewModel.CheckIfExists(dataTest);

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task MonsterIndexViewModel_Delete_Valid_Should_Pass()
        {
            // Arrange
            await ViewModel.CreateAsync(new MonsterModel());
            var first = ViewModel.Dataset.FirstOrDefault();

            // Act
            var result = await ViewModel.DeleteAsync(first);
            var exists = await ViewModel.ReadAsync(first.Id);

            // Reset

            // Assert
            Assert.AreEqual(true, result);  // Delete returned pass
            Assert.AreEqual(null, exists);  // Should not exist so is null
        }

        [Test]
        public async Task MonsterIndexViewModel_Delete_Invalid_Should_Fail()
        {
            // Arrange
            var data = new MonsterModel
            {
                Id = "bogus"
            };

            // Act
            var result = await ViewModel.DeleteAsync(data);

            // Reset

            // Assert
            Assert.AreEqual(false, result);  // Delete returned fail
        }

        [Test]
        public async Task MonsterIndexViewModel_Delete_Invalid_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = await ViewModel.DeleteAsync(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MonsterIndexViewModel_Message_Create_Valid_Should_Pass()
        {
            // Arrange

            // Make a new Item
            var data = new MonsterModel();

            // Make a Delete Page
            var myPage = new Game.Views.MonsterCreatePage(true);

            var countBefore = ViewModel.Dataset.Count();

            // Act
            MessagingCenter.Send(myPage, "Create", data);
            var countAfter = ViewModel.Dataset.Count();

            // Reset

            // Assert
            Assert.AreEqual(countBefore + 1, countAfter); // Count of 0 for the load was skipped
        }

        [Test]
        public async Task MonsterIndexViewModel_Message_Update_Valid_Should_Pass()
        {
            // Arrange
            await ViewModel.CreateAsync(new MonsterModel());

            // Get the item to delete
            var first = ViewModel.Dataset.FirstOrDefault();
            first.Name = "test";

            // Make a Delete Page
            var myPage = new Game.Views.MonsterUpdatePage(true);

            // Act
            MessagingCenter.Send(myPage, "Update", first);
            var result = await ViewModel.ReadAsync(first.Id);

            // Reset

            // Assert
            Assert.AreEqual("test", result.Name); // Count of 0 for the load was skipped
        }

        [Test]
        public async Task MonsterIndexViewModel_Message_SetDataSource_Valid_Should_Pass()
        {
            // Arrange

            // Get the item to delete
            var data = 3000; // Non existing value

            // Make the page Page
            var myPage = new Game.Views.AboutPage(true);

            // Act
            MessagingCenter.Send(myPage, "SetDataSource", data);
            var result = ViewModel.GetCurrentDataSource();

            // Reset
            await ViewModel.SetDataSource(0);

            // Assert
            Assert.AreEqual(0, result); // Count of 0 for the load was skipped
        }

        [Test]
        public async Task MonsterIndexViewModel_Message_WipeDataList_Valid_Should_Pass()
        {
            // Arrange

            // Make the page Page
            var myPage = new Game.Views.AboutPage(true);

            ViewModel.Dataset.Clear();

            await ViewModel.CreateAsync(new MonsterModel());

            // Act
            MessagingCenter.Send(myPage, "WipeDataList", true);
            var countAfter = ViewModel.Dataset.Count();

            // Reset

            // Assert
            Assert.AreEqual(6, countAfter); // Count of 0 for the load was skipped
        }
    }
}
