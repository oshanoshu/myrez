using System;
using System.Collections.Generic;
using MyRez.ViewModels;
using Xamarin.Forms;
using MyRez.Views;
namespace MyRez.Views
{
    public partial class LoginPage : ContentPage
    {
        
        public LoginPage()
        {
            
            InitializeComponent();
            BindingContext = new LoginPageViewModel();
        }
        
        private async void LogIn(bool isLoggedIn)
        {
            if (isLoggedIn == true)
            {
                Application.Current.Properties["IsLoggedIn"] = true;
                await Application.Current.SavePropertiesAsync();
                Application.Current.MainPage=new NavigationPage(new MenuPageAdmin());
                //await Navigation.PopAsync();
            }
        }

        LoginPageViewModel viewModel;
        //async void OnLogInButtonClicked(object sender, EventArgs e)
        //{

        //    if (viewModel.isLoggedIn == true)
        //    {
        //        Application.Current.Properties["IsLoggedIn"] = true;
        //        await Application.Current.SavePropertiesAsync();
        //        
        //    }
        //}
        async void OnLogInButtonClicked(object sender, EventArgs e)
        {
            viewModel = (LoginPageViewModel)BindingContext;
            LogIn(viewModel.isLoggedIn);
        }
        async void OnSignUpAdminButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPageAdmin());
        }
        async void OnSignUpUserButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPageUser());
        }
    }
}
