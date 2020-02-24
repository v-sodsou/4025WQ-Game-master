using Game.Models;
using Game.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Game.Views
{
    /// <summary>
    /// Create Item
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class ScoreCreatePage : ContentPage
    {
        // The item to create
        GenericViewModel<ScoreModel> ViewModel { get; set; }

        // Constructor for Unit Testing
        public ScoreCreatePage(bool UnitTest) { }


        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public ScoreCreatePage(GenericViewModel<ScoreModel> data)
        {
            InitializeComponent();

            data.Data = new ScoreModel();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Create New Score";
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {

            // Add validation for Name and score
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                await DisplayAlert("Alert", "Please enter a name!", "OK");
            }
            else if (ViewModel.Data.ScoreTotal < 0)
            {
                await DisplayAlert("Alert", "Please enter a number greater than or equal than 0!", "OK");
            }
            else
            {
                MessagingCenter.Send(this, "Create", ViewModel.Data);
                await Navigation.PopModalAsync();
            }
            
        }

        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}