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
    public partial class MonsterReadPage : ContentPage
    {
        /// <summary>
        /// view model variable
        /// </summary>
        readonly GenericViewModel<MonsterModel> ViewModel;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public MonsterReadPage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();
            BindingContext = this.ViewModel = data;
        }

        /// <summary>
        /// Edit Monster Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void EditMonster_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterUpdatePage(new GenericViewModel<MonsterModel>(ViewModel.Data))));
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Delete Monster Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void DeleteMonster_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterDeletePage(new GenericViewModel<MonsterModel>(ViewModel.Data))));
            await Navigation.PopAsync();
        }

    }
}