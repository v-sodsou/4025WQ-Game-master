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
        readonly GenericViewModel<MonsterModel> ViewModel;
        public MonsterReadPage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();
            BindingContext = this.ViewModel = data;
        }

        async void EditMonster_Clicked(object sender, System.EventArgs e)
        {
            // await Navigation.PushModalAsync(new NavigationPage(new MonsterUpdatePage(new GenericViewModel<CharacterModel>(ViewModel.Data))));
            await Navigation.PopAsync();
        }

        async void DeleteMonster_Clicked(object sender, System.EventArgs e)
        {
            // await Navigation.PushModalAsync(new NavigationPage(new MonsterDeletePage(new GenericViewModel<CharacterModel>(ViewModel.Data))));
            await Navigation.PopAsync();
        }

    }
}