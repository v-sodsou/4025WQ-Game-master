using System;
using Game.Engine;
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
		// Hold the Engine, so it can be swapped out for unit testing
		public AutoBattleEngine Engine = new AutoBattleEngine();
		/// <summary>
		/// Constructor
		/// </summary>
		public AutoBattlePage()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Auto Battle Method
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public async void AutobattleButton_Clicked(object sender, EventArgs e)
		{
			// Call into Auto Battle from here to do the Battle...

			var Engine = new Game.Engine.AutoBattleEngine();

			string BattleMessage = "";

			var result = await Engine.RunAutoBattle();

			var Score = Engine.GetScoreObject();

			BattleMessage = string.Format("Rounds Played: {0}", Score.RoundCount);

			BattleMessage += string.Format("\nMonsters Slained: {0}", Score.MonsterSlainNumber);

			BattleMessage += string.Format("\nExperience Gained: {0}", Score.ExperienceGainedTotal);

			// TBD: Do we show the Score for Autobattle?
			// BattleMessage += string.Format("\nScore Total: {0}", Score.ScoreTotal);

			BattleMessageValue.Text = BattleMessage;

			Begin_Battle.IsVisible = false;
			Battle_Ended.IsVisible = true;

		}
	}
}