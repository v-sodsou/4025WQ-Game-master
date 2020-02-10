using Game.Models;
using Game.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
namespace Game.Views.Characters
{
    [DesignTimeVisible(false)]
    public partial class CharacterReadPage : ContentPage
    {
        readonly GenericViewModel<Character> ViewModel;
        public CharacterReadPage(GenericViewModel<Character> data)
        {
            InitializeComponent();
            BindingContext = this.ViewModel = data;
        }

        async void EditCharacter_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterUpdatePage(new GenericViewModel<Character>(ViewModel.Data))));
            await Navigation.PopAsync();
        }

        async void DeleteCharacter_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CharacterDeletePage(new GenericViewModel<Character>(ViewModel.Data))));
            await Navigation.PopAsync();
        }
    }
}