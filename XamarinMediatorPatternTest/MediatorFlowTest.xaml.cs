using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMediatorPatternTest.Domain.Common.Enums;
using XamarinMediatorPatternTest.Domain.Services;

namespace XamarinMediatorPatternTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediatorFlowTest : ContentPage
    {
        public MediatorFlowTest()
        {
            InitializeComponent();

            MediatorService.Subscribe(
                ApplicationEvents.MediatorChallenged,
                MediatorFlowCallback);
        }

        private async void MediatorFlowButton_Clicked(object sender, EventArgs e)
        {
            if (MediatorFlowButton.IsEnabled)
            {
                MediatorFlowButton.IsEnabled = false;
                MediatorFlowLabel.Text = "The Button will be re-enabled in 15 seconds.";
            }
            else return;

            // Heavy task operation here.
            MediatorService.Send(ApplicationEvents.SendMessage);

            await DisplayAlert("Mediator flow started", "Please wait until the heavy task gets completed.", "Accept");
        }

        private async void MediatorFlowCallback()
        {
            await DisplayAlert("Callback reached", "The Mediator flow completed successfully. You can re-try the test now.", "Accept");

            MediatorFlowButton.IsEnabled = true;
            MediatorFlowLabel.Text = "Press the button to start the mediator flow test.";
        }
    }
}