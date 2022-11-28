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
        private bool _needToSimulateHeavyTask = false;

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

            await DisplayAlert("Mediator flow started!", "Please wait until the heavy task gets completed.", "Accept");
        }

        private async void MediatorFlowWithParameterButton_Clicked(object sender, EventArgs e)
        {
            _needToSimulateHeavyTask = !_needToSimulateHeavyTask;

            if (_needToSimulateHeavyTask)
            {
                MediatorFlowLabel.Text = "Or Click again before the task gets completed. To navigate back to the home page. The task will be completed in 15 seconds anyway.";

                await DisplayAlert("Mediator flow started!", "Please wait until the heavy task gets completed.", "Accept");
            }
            else if (MediatorFlowWithParameterButton.IsEnabled)
            {
                MediatorFlowWithParameterButton.IsEnabled = false;
            }
            else return;
            
            // Heavy task operation here.
            MediatorService.Send<bool>(ApplicationEvents.SendMessageWithParameter, _needToSimulateHeavyTask);
        }

        private async void MediatorFlowCallback()
        {
            _needToSimulateHeavyTask = false;

            MediatorFlowButton.IsEnabled = true;
            MediatorFlowWithParameterButton.IsEnabled = true;

            MediatorFlowLabel.Text = "Press the button to start the mediator flow test.";

            await DisplayAlert("Mediator flow test finished!", "The Mediator flow completed successfully. You can re-try the test now.", "Accept");
        }
    }
}