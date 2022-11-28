using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinMediatorPatternTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void NavigateMediatorFlowTestPage_Clicked(object sender, EventArgs e)
        {
            if (MediatorFlowTestPageButton.IsEnabled)
            {
                MediatorFlowTestPageButton.IsEnabled = false;
            }
            else return;

            MediatorFlowTest navigation = new MediatorFlowTest();
            NavigationPage navpage = new NavigationPage(navigation);
            Application.Current.MainPage = navpage;
            await navpage.PushAsync(navigation);

            MediatorFlowTestPageButton.IsEnabled = true;
        }
    }
}
