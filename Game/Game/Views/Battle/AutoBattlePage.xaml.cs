﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
	/// <summary>
	/// The Main Game Page
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AutoBattlePage: ContentPage
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public AutoBattlePage()
		{
			InitializeComponent ();
		}

		public async void AutobattleButton_Clicked(object sender, EventArgs e)
		{
			
		}
	}
}