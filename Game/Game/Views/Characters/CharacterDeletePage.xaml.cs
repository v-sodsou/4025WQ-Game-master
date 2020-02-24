using Game.Models;
using Game.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Characters
{
    /// <summary>
    /// Character Delete Page Class
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterDeletePage : ContentPage
    {
        // Character viewModel object used for data binding
        readonly GenericViewModel<CharacterModel> viewModel;

        // Empty Constructor needed for Unit Tests
        public CharacterDeletePage(bool UnitTest) { }

        // Character Delete Page Constructor
        public CharacterDeletePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.viewModel = data;

            this.viewModel.Title = "Delete " + data.Title;
        }

        // Character Delete Button Click Event
        async void CharacterDelete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Delete", viewModel.Data);
            await Navigation.PopModalAsync();
        }

        // Character Cancel button click event
        async void CharacterCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        // Avoid Android issues with back button on modal pages
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}