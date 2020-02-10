using Game.Models;
using Game.ViewModels;
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
    }
}