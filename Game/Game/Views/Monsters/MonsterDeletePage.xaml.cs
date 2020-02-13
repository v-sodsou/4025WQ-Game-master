using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models;
using Game.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Monsters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterDeletePage : ContentPage
    {
        /// <summary>
        /// Monster view model
        /// </summary>
        readonly GenericViewModel<MonsterModel> viewModel;

        /// <summary>
        /// Parameterless Constructor
        /// </summary>
        public MonsterDeletePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor MonsterDeletePage
        /// </summary>
        /// <param name="data"></param>
        public MonsterDeletePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.viewModel = data;

            this.viewModel.Title = "Delete " + data.Title;
        }

        /// <summary>
        /// MonsterDelete click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void MonsterDelete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Delete", viewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Monster Cancel Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void MonsterCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Fix issue with Android back button
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}