using NUnit.Framework;
using Game.ViewModels;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using Game.Services;
using System.Threading.Tasks;
using Game.Models;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ViewModels
{
    public class ItemIndexViewModelTests
    {
        ItemIndexViewModel ViewModel;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            // Add each model here to warm up and load it.
            Game.Helpers.DataSetsHelper.WarmUp();

            ViewModel = ItemIndexViewModel.Instance;
        }

        /// <summary>
        /// Reset the data store
        /// </summary>
        public async Task ResetDataAsync()
        {
            await ViewModel.WipeDataListAsync();
        }

        [Test]
        public async Task ItemIndexViewModel_Read_Invalid_ID_Bogus_Should_Fail()
        {
            // Arrange

            // Act
            var result = await ViewModel.ReadAsync("bogus");

            // Reset

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void ItemIndexViewModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemIndexViewModel_SortDataSet_Default_Should_Pass()
        {
            // Arrange

            // Add items into the list Z ordered
            var dataList = new List<ItemModel>();
            dataList.Add(new ItemModel { Name = "z" });
            dataList.Add(new ItemModel { Name = "m" });
            dataList.Add(new ItemModel { Name = "a" });

            // Act
            var result = ViewModel.SortDataset(dataList);

            // Reset

            // Assert
            Assert.AreEqual("a", result[0].Name);
            Assert.AreEqual("m", result[1].Name);
            Assert.AreEqual("z", result[2].Name);
        }

        [Test]
        public async Task ItemIndexViewModel_CheckIfItemExists_Default_Should_Pass()
        {
            // Arrange

            // Add items into the list Z ordered
            var dataTest = new ItemModel { Name = "test" };
            await ViewModel.CreateAsync(dataTest);

            await ViewModel.CreateAsync(new ItemModel { Name = "z" });
            await ViewModel.CreateAsync(new ItemModel { Name = "m" });
            await ViewModel.CreateAsync(new ItemModel { Name = "a" });

            // Act
            var result = ViewModel.CheckIfExists(dataTest);

            // Reset
            await ResetDataAsync();

            // Assert
            Assert.AreEqual(dataTest.Id, result.Id);
        }

        [Test]
        public async Task ItemIndexViewModel_CheckIfItemExists_InValid_Missing_Should_Fail()
        {
            // Arrange

            // Add items into the list Z ordered
            var dataTest = new ItemModel { Name = "test" };
            // Don't add it to the list await ViewModel.CreateAsync(dataTest);

            await ViewModel.CreateAsync(new ItemModel { Name = "z" });
            await ViewModel.CreateAsync(new ItemModel { Name = "m" });
            await ViewModel.CreateAsync(new ItemModel { Name = "a" });

            // Act
            var result = ViewModel.CheckIfExists(dataTest);

            // Reset
            await ResetDataAsync();

            // Assert
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task ItemIndexViewModel_Message_Delete_Valid_Should_Pass()
        {
            // Arrange

            // Get the item to delete
            var first = ViewModel.Dataset.FirstOrDefault();

            // Make a Delete Page
            var myPage = new Game.Views.ItemDeletePage(true);

            // Act
            MessagingCenter.Send(myPage, "Delete", first);

            var data = await ViewModel.ReadAsync(first.Id);

            // Reset
            await ResetDataAsync();

            // Assert
            Assert.AreEqual(null, data); // Item is removed
        }
    }
}