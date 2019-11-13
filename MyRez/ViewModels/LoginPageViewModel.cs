using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MyRez.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using MyRez.Views;
using System.Net.Http.Headers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MyRez.Database;

namespace MyRez.ViewModels
{
    public class LoginPageViewModel:BaseViewModel
    {
        public LoginPageViewModel()
        {
            //GetUserLists = new Command(async () => await LoginSignUpAsync());
            AuthorizeUsers = new Command(async () => await AuthorizeAsync());
            
        }
        
        
        List<LoginSignUp> loginDetailsDB;
        string username=string.Empty;
        string password=string.Empty;
        bool isLogged = false;
        public string Username
        {
            
            get
            { 
                return username;
            }
            set
            {
                if (value != username)
                {

                    username = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value != password)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }
        private async Task AuthorizeAsync()
        {
            await LoginSignUpAsync();
            if (isLoggedIn)
            {
                if (Username == "Oshan")
                    Console.WriteLine("Good Job");
            }
            for(int i=0;i<loginDetailsDB.Count;i++)
            {
                if (string.Equals(loginDetailsDB[i].username,Username.ToLower()))
                {
                    if (string.Equals(loginDetailsDB[i].password, password.ToLower()))
                    {
                        isLoggedIn = true;
                        OnPropertyChanged(nameof(isLoggedIn));
                        Application.Current.Properties["IsLoggedIn"] = true;
                        await Application.Current.SavePropertiesAsync();
                        Application.Current.MainPage = new NavigationPage(new MenuPageAdmin());
                    }
                }
            }
        }

        public bool isLoggedIn
        {
            get { return isLogged; }
            set
            {
                if (value != isLogged)
                {
                    isLogged = value;
                    OnPropertyChanged(nameof(isLoggedIn));
                }
            }
        }

        
        public Command AuthorizeUsers { get; }
        public Command GetUserLists { get; }

        private async Task LoginSignUpAsync()
        {
            Database_API db = new Database_API();
            loginDetailsDB= await db.GetUsersAsync();

        }
    }
}
