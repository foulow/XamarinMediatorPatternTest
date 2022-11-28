using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMediatorPatternTest.Domain.Common.Enums;
using XamarinMediatorPatternTest.Domain.Services;

namespace XamarinMediatorPatternTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MediatorService.Subscribe<bool>(
                ApplicationEvents.MediatorChallengedWithParameter,
                MediatorFlowWithParameterCallback);
        }

        private async void NavigateMediatorFlowTestPage_Clicked(object sender, EventArgs e)
        {
            if (MediatorFlowTestPageButton.IsEnabled)
            {
                MediatorFlowTestPageButton.IsEnabled = false;
            }
            else return;

            MediatorFlowTest mediatorPage = new MediatorFlowTest();
            NavigationPage navigationPage = (NavigationPage)App.Current.MainPage;
            await navigationPage.PushAsync(mediatorPage);

            MediatorFlowTestPageButton.IsEnabled = true;
        }

        private async void MediatorFlowWithParameterCallback(bool completedSuccessfully)
        {
            if (completedSuccessfully)
            {
                MediatorService.Send(ApplicationEvents.MediatorChallenged);

                await DisplayAlert("Mediator flow test finished!", "The Mediator flow with parameter completed successfully.", "Accept");
            }
            else
            {
                NavigationPage navigationPage = (NavigationPage)App.Current.MainPage;
                await navigationPage.PopAsync();
            }
        }
    }
}
