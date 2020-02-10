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

        private void EditCharacter_Clicked(object sender, System.EventArgs e)
        {

        }

        private void DeleteCharacter_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}