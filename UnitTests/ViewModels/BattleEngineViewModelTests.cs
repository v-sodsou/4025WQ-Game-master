using Game.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Mocks;

namespace UnitTests.ViewModels
{
    class BattleEngineViewModelTests
    {
        BattleEngineViewModel ViewModel;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            ViewModel = BattleEngineViewModel.Instance;
        }

        [Test]
        public void BattleEngineViewModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = ViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
