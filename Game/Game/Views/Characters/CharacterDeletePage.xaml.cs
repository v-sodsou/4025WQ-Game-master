using Game.Models;
using Game.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Game.Views.Characters
{
    [DesignTimeVisible(false)]
    public partial class CharacterDeletePage : ContentPage
    {
        readonly GenericViewModel<Character> viewModel;
        public CharacterDeletePage()
        {
            InitializeComponent();
        }

        public CharacterDeletePage(GenericViewModel<Character> data)
        {
            InitializeComponent();

            BindingContext = this.viewModel = data;

            this.viewModel.Title = "Delete " + data.Title;
        }

        async void CharacterDelete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Delete", viewModel.Data);
            await Navigation.PopModalAsync();
        }

        async void CharacterCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}