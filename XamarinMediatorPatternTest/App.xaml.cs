using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMediatorPatternTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage startPage = new MainPage();
            NavigationPage navigationPage = new NavigationPage(startPage);
            Application.Current.MainPage = navigationPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
