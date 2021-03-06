﻿using System;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Engine;
using Game.Models;
using Game.ViewModels;
using System.Threading.Tasks;
using Plugin.SimpleAudioPlayer;
using System.IO;
using System.Reflection;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BattlePage : ContentPage
    {
        // This uses the Instance so it can be shared with other Battle Pages as needed
        public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        #region PageHandelerVariables
        // Hold the Selected Characters
        public PickCharactersPage ModalPickCharactersPage;

        // Hold the New Round Page where monsters are shown
        public NewRoundPage ModalNewRoundPage;

        // Hold Round Over Page
        public RoundOverPage ModalRoundOverPage;

        // Hold the Game Over Page where the Final Score is shown
        public ScorePage ModalShowScorePage;

        // HTML Formatting for message output box
        public HtmlWebViewSource htmlSource = new HtmlWebViewSource();

        // Wait time before proceeding
        public int WaitTime = 1500;

        //public int BattleEngine be;

        #endregion PageHandelerVariables

        /// <summary>
        /// Constructor
        /// </summary>
        public BattlePage()
        {
            InitializeComponent();

            // Set up the UI to Defaults
            BindingContext = EngineViewModel;

            // Start the Battle Engine
            EngineViewModel.Engine.StartBattle(false);

            // Ask the Game engine to select who goes first
            EngineViewModel.Engine.CurrentAttacker = null;
            EngineViewModel.Engine.CurrentAttacker = EngineViewModel.Engine.GetNextPlayerTurn();

            // Let them select the one they want to attack
            EngineViewModel.Engine.CurrentDefender = EngineViewModel.Engine.AttackChoice(EngineViewModel.Engine.CurrentAttacker);

            // Show the New Round Screen
            ShowModalNewRoundPage(); 

            // Draw the Characters
            foreach (var data in EngineViewModel.Engine.CharacterList)
            {
                // Hackathon Hack #30: Who will volunteer to be first?
                // The first character in the list gets their base Attack, Speed and Defense
                // values doubled.
                if (data.Name == EngineViewModel.Engine.CharacterList[0].Name)
                {
                    // Handle the attack == 0 case; otherwise double it.
                    data.Attack = (data.Attack == 0) ? data.Attack = 2 : data.Attack *= 2;
                    
                    // Handle the speed == 0 case; otherwise double it.
                    data.Speed = (data.Speed == 0) ? data.Speed = 2 : data.Speed *= 2;

                    // Handle the defense == 0 case; otherwise double it.
                    data.Defense = (data.Defense == 0) ? data.Defense = 2 : data.Defense *= 2;

                }

                CharacterBox.Children.Add(CreatePlayerDisplayBox(data));
            }

            // Draw the Monsters
            foreach (var data in EngineViewModel.Engine.MonsterList)
            {
                MonsterBox.Children.Add(CreatePlayerDisplayBox(data));
            }

            // Add Players to Display
            DrawGameBoardAttackerDefender();


        }


        /// <summary>
        /// Return a stack layout with the Player information inside
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StackLayout CreatePlayerDisplayBox(PlayerInfoModel data)
        {
            if (data == null)
            {
                data = new PlayerInfoModel();
            }

            // Hookup the image
            var PlayerImage = new Image
            {
                Style = (Style)Application.Current.Resources["PlayerBattleSmallStyle"],
                Source = data.ImageURI
            };

            // Add the Level
            var PlayerLevelLabel = new Label
            {
                Text = "Level : " + data.Level,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Add the HP
            var PlayerHPLabel = new Label
            {
                Text = "HP : " + data.GetCurrentHealthTotal,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            var PlayerNameLabel = new Label()
            {
                Text = data.Name,
                Style = (Style)Application.Current.Resources["ValueStyle"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = 0,
                LineBreakMode = LineBreakMode.TailTruncation,
                CharacterSpacing = 1,
                LineHeight = 1,
                MaxLines = 1,
            };

            // Put the Image Button and Text inside a layout
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["PlayerInfoBox"],
                HorizontalOptions = LayoutOptions.Center,
                Padding = 0,
                Spacing = 0,
                Children = {
                    PlayerImage,
                    PlayerNameLabel,
                    PlayerLevelLabel,
                    PlayerHPLabel,
                },
            };
            // Mauricio: Testing
            //var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            //player.Load("star_wars_theme.mp3");
            //player.Play();

            //ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            //player.Load(GetStreamFromFile("star_wars_theme.mp3"));
            //player.Play();

            //var alertSound = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            //alertSound.Load("")
            return PlayerStack;
        }

        
        /// <summary>
        /// In the future will try to make this work
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("YourApp." + filename);
            return stream;
        }


        /// <summary>
        /// Draws the Game Board Attacker and Defender
        /// </summary>
        public void DrawGameBoardAttackerDefender()
        {
            DrawGameBoardClear();

            // Get an attacker
            if (EngineViewModel.Engine.CurrentAttacker != null)
            {
                AttackerImage.Source = EngineViewModel.Engine.CurrentAttacker.ImageURI;
                AttackerName.Text = EngineViewModel.Engine.CurrentAttacker.Name;
                AttackerHealth.Text = EngineViewModel.Engine.CurrentAttacker.GetCurrentHealthTotal.ToString() + " / " + EngineViewModel.Engine.CurrentAttacker.GetMaxHealthTotal.ToString();
            }

            // Get a defender
            if (EngineViewModel.Engine.CurrentDefender != null)
            {
                DefenderImage.Source = EngineViewModel.Engine.CurrentDefender.ImageURI;
                DefenderName.Text = EngineViewModel.Engine.CurrentDefender.Name;
                DefenderHealth.Text = EngineViewModel.Engine.CurrentDefender.GetCurrentHealthTotal.ToString() + " / " + EngineViewModel.Engine.CurrentDefender.GetMaxHealthTotal.ToString();

                // If the defender is dead, fade out its image
                if (EngineViewModel.Engine.CurrentDefender.Alive == false)
                {

                    DefenderImage.FadeTo(.2, 100);

                }

            }

            //BattlePlayerBoxVersus.Text = "vs";
        }

        /// <summary>
        /// Draws the Game Board Attacker and Defender areas to be null
        /// </summary>
        public void DrawGameBoardClear()
        {
            AttackerImage.Source = string.Empty;
            AttackerName.Text = string.Empty;
            AttackerHealth.Text = string.Empty;

            DefenderImage.Source = string.Empty;
            DefenderName.Text = string.Empty;
            DefenderHealth.Text = string.Empty;
            DefenderImage.FadeTo(1, 250);

            // Added grid but keep this message just in case
            // BattlePlayerBoxVersus.Text = string.Empty;
        }

        /// <summary>
        /// Attack Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AttackButton_Clicked(object sender, EventArgs e)
        {
            // Hackathon: Hack #18. Did you hear that? 
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("chord.wav");
            player.Play();

            NextAttackExample();
        }


        /// <summary>
        /// New button to change attacker if desired
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NewAttackerButton_Clicked(object sender, EventArgs e)
        {
            SelectNewAttacker();
        }

        /// <summary>
        /// Private method to select a new attacker
        /// </summary>
        private void SelectNewAttacker()
        {
            // Get the turn, set the current player and attacker to match
            EngineViewModel.Engine.CurrentAttacker = EngineViewModel.Engine.GetNextPlayerTurn();

            if (EngineViewModel.Engine.CurrentAttacker.PlayerType == PlayerTypeEnum.Character)
            {
                // User would select who to attack

                // for now just auto selecting
                EngineViewModel.Engine.CurrentDefender = EngineViewModel.Engine.AttackChoice(EngineViewModel.Engine.CurrentAttacker);
                DrawGameBoardAttackerDefender();
                return;
            }

            // Monsters turn, so auto pick a Character to Attack
            EngineViewModel.Engine.CurrentDefender = EngineViewModel.Engine.AttackChoice(EngineViewModel.Engine.CurrentAttacker);
            DrawGameBoardAttackerDefender();
        }


        /// <summary>
        /// Next Attack Example
        /// 
        /// This code example follows the rule of
        /// 
        /// Auto Select Attacker
        /// Auto Select Defender
        /// 
        /// Do the Attack and show the result
        /// 
        /// So the pattern is Click Next, Next, Next until game is over
        /// 
        /// </summary>
        private void NextAttackExample()
        {
            // Redraw Game Board

            // Hold the current state
            var RoundCondition = EngineViewModel.Engine.RoundNextTurn();

            if (RoundCondition == RoundEnum.NewRound)
            {
                // Show the New Monster List, and Items Gained
                EngineViewModel.Engine.NewRound();
                ShowModalNewRoundPage();
                Debug.WriteLine("New Round");
            }

            // Check for Game Over
            if (RoundCondition == RoundEnum.GameOver)
            {
                Debug.WriteLine("Game Over");
                GameOver();
                return;
            }

            // Set the board for the next action
            DrawGameBoardAttackerDefender();
            ClearMessages();

            // Output the Message of what happened.
            GameMessage();

            // Get the turn, set the current player and attacker to match
            EngineViewModel.Engine.CurrentAttacker = EngineViewModel.Engine.GetNextPlayerTurn();

            if (EngineViewModel.Engine.CurrentAttacker.PlayerType == PlayerTypeEnum.Character)
            {
                // User would select who to attack

                // for now just auto selecting
                EngineViewModel.Engine.CurrentDefender = EngineViewModel.Engine.AttackChoice(EngineViewModel.Engine.CurrentAttacker);

                return;
            }

            // Monsters turn, so auto pick a Character to Attack
            EngineViewModel.Engine.CurrentDefender = EngineViewModel.Engine.AttackChoice(EngineViewModel.Engine.CurrentAttacker);

            // Auto Advance the Monster attack
            // Task.Delay(WaitTime);
            // NextAttackExample();
        }

        /// <summary>
        /// Game is over
        /// 
        /// Show Buttons
        /// 
        /// Clean up the Engine
        /// 
        /// Show the Score
        /// 
        /// Clear the Board
        /// 
        /// </summary>
        public void GameOver()
        {
            // Wrap up
            EngineViewModel.Engine.EndBattle();

            // Save the Score to the Score View Model, by sending a message to it.
            var Score = EngineViewModel.Engine.BattleScore;
            MessagingCenter.Send(this, "AddData", Score);

            // Clear the players from the center of the board
            DrawGameBoardClear();
            ClearMessages();

            // Hide the Game Board
            GameUIDisplay.IsVisible = false;

            // Show the Game Over Display
            GameOverDisplay.IsVisible = true;
        }

        /// <summary>
        /// Builds up the output message
        /// </summary>
        /// <param name="message"></param>
        public void GameMessage()
        {
            // Output The Message that happened.
            BattleMessages.Text = string.Format("{0} \n {1}", EngineViewModel.Engine.BattleMessagesModel.TurnMessage, BattleMessages.Text);

            Debug.WriteLine(BattleMessages.Text);

            if (!string.IsNullOrEmpty(EngineViewModel.Engine.BattleMessagesModel.LevelUpMessage))
            {
                BattleMessages.Text = string.Format("{0} \n {1}", EngineViewModel.Engine.BattleMessagesModel.LevelUpMessage, BattleMessages.Text);
            }

            htmlSource.Html = EngineViewModel.Engine.BattleMessagesModel.GetHTMLFormattedTurnMessage();
            HtmlBox.Source = HtmlBox.Source = htmlSource;
        }

        /// <summary>
        ///  Clears the messages on the UX
        /// </summary>
        public void ClearMessages()
        {
            BattleMessages.Text = "";
            htmlSource.Html = EngineViewModel.Engine.BattleMessagesModel.GetHTMLBlankMessage();
            HtmlBox.Source = htmlSource;
        }

        #region PageHandelers

        /// <summary>
        /// Battle Over, so Exit Button
        /// Need to show this for the user to click on.
        /// The Quit does a prompt, exit just exits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ExitButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Show the Game Over Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void ShowScoreButton_Clicked(object sender, EventArgs args)
        {
            Debug.WriteLine("Showing Score Page : " + EngineViewModel.Engine.BattleScore.ScoreTotal.ToString());

            ShowModalScorePage();
        }

        /// <summary>
        /// Handle Pick Characters and new round modal pages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleModalPopping(object sender, ModalPoppingEventArgs e)
        {
            if (e.Modal == ModalNewRoundPage)
            {
                ModalNewRoundPage = null;

                // remember to remove the event handler:
                App.Current.ModalPopping -= HandleModalPopping;
            }

            if (e.Modal == ModalPickCharactersPage)
            {
                ModalPickCharactersPage = null;

                // remember to remove the event handler:
                App.Current.ModalPopping -= HandleModalPopping;
            }
        }

        /// <summary>
        /// Show the Page for New Round
        /// 
        /// Upcomming Monsters
        /// 
        /// </summary>
        public async void ShowModalNewRoundPage()
        {
            // When you want to show the modal page, just call this method
            // add the event handler for to listen for the modal popping event:
            App.Current.ModalPopping += HandleModalPopping;
            ModalNewRoundPage = new NewRoundPage();
            await Navigation.PushModalAsync(ModalNewRoundPage);
        }

        /// <summary>
        /// Show the Round Over Page
        /// 
        /// Item Picker results
        /// 
        /// </summary>
        public async void ShowModalRoundOverPage()
        {
            // When you want to show the modal page, just call this method
            // add the event handler for to listen for the modal popping event:
            App.Current.ModalPopping += HandleModalPopping;
            ModalRoundOverPage = new RoundOverPage();
            await Navigation.PushModalAsync(ModalRoundOverPage);
        }

        /// <summary>
        /// Show the Select Characters Page
        /// 
        /// Let User Pick the Characters for the battle
        /// 
        /// </summary>
        public async void ShowModalPageCharcterSelect()
        {
            // When you want to show the modal page, just call this method
            // add the event handler for to listen for the modal popping event:
            App.Current.ModalPopping += HandleModalPopping;
            ModalPickCharactersPage = new PickCharactersPage();
            await Navigation.PushModalAsync(ModalPickCharactersPage);
        }

        /// <summary>
        /// Show the Game Over Page
        ///
        /// All Done
        /// 
        /// </summary>
        public async void ShowModalScorePage()
        {
            // When you want to show the modal page, just call this method
            // add the event handler for to listen for the modal popping event:
            App.Current.ModalPopping += HandleModalPopping;
            ModalShowScorePage = new ScorePage();
            await Navigation.PushModalAsync(ModalShowScorePage);
        }
        #endregion PageHandelers
    }
}