using Game.Models;
using Game.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Game.Views
{
    /// <summary>
    /// Create Character
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class MonsterCreatePage : ContentPage
    {
        // The character to create
        GenericViewModel<Monster> ViewModel { get; set; }

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public MonsterCreatePage(GenericViewModel<Monster> data)
        {
            InitializeComponent();

            data.Data = new Monster();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Create Monster";

        }

       


    }
}