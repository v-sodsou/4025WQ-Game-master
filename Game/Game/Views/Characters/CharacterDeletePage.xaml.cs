﻿using Game.Models;
using Game.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Characters
{
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterDeletePage : ContentPage
    {
        readonly GenericViewModel<CharacterModel> viewModel;

        // Empty Constructor needed for Unit Tests
        public CharacterDeletePage(bool UnitTest) { }

        public CharacterDeletePage(GenericViewModel<CharacterModel> data)
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