
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;
using Game.Views.Battle;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PickCharactersPage : ContentPage
	{
		// The view model, used for data binding
		readonly CharacterIndexViewModel ViewModel;

		/// <summary>
		/// Constructor
		/// </summary>
		public PickCharactersPage()
		{
			InitializeComponent();

			BindingContext = ViewModel = CharacterIndexViewModel.Instance;

		}

		void OnCharacterSelected(object sender, EventArgs e)
		{
			//TBD
		}

		void OnChecked(object sender, EventArgs e)
		{
			// TBD	
		}

		/// <summary>
		/// Jump to the Battle
		/// 
		/// Its Modal because don't want user to come back...
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void BattleButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new ShowMonstersPage()));
			await Navigation.PopAsync();
		}
	}
}