using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Models;
using Game.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Monsters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterUpdatePage : ContentPage
    {
        // View Model for Monster
        readonly GenericViewModel<MonsterModel> ViewModel;

        
        /// <summary>
        /// Constructor for Monster Update Page
        /// </summary>
        /// <param name="data"></param>
        public MonsterUpdatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();
            BindingContext = this.ViewModel = data;
        }

        /// <summary>
        /// Save Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Update", ViewModel.Data);

            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Cancel_Clicked(object sender, EventArgs e)
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
        /// Stepper for Attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ValueStepperAttack(object sender, ValueChangedEventArgs e)
        {
            ValueAttack.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Stepper for Defense
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ValueStepperDefense(object sender, ValueChangedEventArgs e)
        {
            ValueDefense.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Stepper for Speed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ValueStepperSpeed(object sender, ValueChangedEventArgs e)
        {
            ValueSpeed.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Force switch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnToggled(object sender, ToggledEventArgs e)
        {
            this.ViewModel.Data.HasForce = e.Value;
        }
    }
}