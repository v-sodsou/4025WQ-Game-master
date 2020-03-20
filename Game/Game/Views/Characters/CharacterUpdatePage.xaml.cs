using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models;
using Game.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Characters
{
    /// <summary>
    /// Character Update Page Class
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterUpdatePage : ContentPage
    {
        // View Model for data binding
        public readonly GenericViewModel<CharacterModel> ViewModel;

        // Empty Constructor for Tests
        public CharacterUpdatePage(bool UnitTest) { }

        /// <summary>
        /// Character Update constructor
        /// </summary>
        /// <param name="data"></param>
        public CharacterUpdatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;
        }

        /// <summary>
        /// Save Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Update", ViewModel.Data);

            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            // Pop the modal Update page off the ModalStack
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Do not respond to Android back button
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        /// <summary>
        /// Attack stepper Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ValueStepperAttack(object sender, ValueChangedEventArgs e)
        {
            ValueAttack.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Defense Stepper Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ValueStepperDefense(object sender, ValueChangedEventArgs e)
        {
            ValueDefense.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Speed Stepper Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ValueStepperSpeed(object sender, ValueChangedEventArgs e)
        {
            ValueSpeed.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Force Toggled Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnToggled(object sender, ToggledEventArgs e)
        {
            this.ViewModel.Data.HasForce = e.Value;
        }

    }
}