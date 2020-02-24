using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.ViewModels;
using Game.Models;

namespace UnitTests.ViewModels
{
    [TestFixture]
    public class BaseViewModelTests : BaseViewModel<ItemModel>
    {
        BaseViewModel<ItemModel> ViewModel;

        [SetUp]
        public void Setup()
        {
            ViewModel = new BaseViewModel<ItemModel>();
        }

        [Test]
        public void BaseViewModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BaseViewModel<ItemModel>();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BaseViewModel_Get_Title_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BaseViewModel<ItemModel>().Title;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BaseViewModel_SetProperty_Changed_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BaseViewModel<ItemModel>();

            var isBusy = false;
            SetProperty<bool>(ref isBusy, true);

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
