using System;
using MyRez.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyRez
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            if (!Current.Properties.ContainsKey("IsLoggedIn"))
            {
                Current.Properties["IsLoggedIn"] = false;
                Current.SavePropertiesAsync();
                MainPage = new NavigationPage(new LoginPage());
            }
            else if (!((bool)Current.Properties["IsLoggedIn"]))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new MenuPageAdmin());
            }
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
