using Game.Models;
using Game.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
namespace Game.Views.Characters
{
    /// <summary>
    /// Character Read Page
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class CharacterReadPage : ContentPage
    {
        // Character view model for data binding
        readonly GenericViewModel<CharacterModel> ViewModel;

        // Empty Constructor for UTs
        public CharacterReadPage(bool UnitTest) { }

        // Character Read Page Constructor
        public CharacterReadPage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();
            BindingContext = this.ViewModel = data;
        }

        // Edit character button event
        public async void EditCharacter_Clicked(object sender, System.EventArgs e)
        {
            // Push a new modal page onto the modal stack
            await Navigation.PushModalAsync(new NavigationPage(new CharacterUpdatePage(new GenericViewModel<CharacterModel>(ViewModel.Data))));
            // Pop a page from the stack
            await Navigation.PopAsync();
        }

        public async void DeleteCharacter_Clicked(object sender, System.EventArgs e)
        {
            // Push a new modal page onto the modal stack
            await Navigation.PushModalAsync(new NavigationPage(new CharacterDeletePage(new GenericViewModel<CharacterModel>(ViewModel.Data))));
            // Pop a page from the stack
            await Navigation.PopAsync();
        }
    }
}