using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyRez.Models;
using MyRez.ViewModels;
using MyRez.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MyRez
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void LogOutClicked(object sender, EventArgs events)
        {
            Application.Current.Properties["IsLoggedIn"] = false;
            await Application.Current.SavePropertiesAsync();
            Application.Current.MainPage=new NavigationPage( new LoginPage());
        }
      
    }
}
