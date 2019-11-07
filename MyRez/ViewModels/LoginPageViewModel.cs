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

namespace MyRez.ViewModels
{
    public class LoginPageViewModel:INotifyPropertyChanged
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
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
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
                        NotifyPropertyChanged(nameof(isLoggedIn));
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
                    NotifyPropertyChanged(nameof(isLoggedIn));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Command AuthorizeUsers { get; }
        public Command GetUserLists { get; }
        private async Task LoginSignUpAsync()
        {
            //var client = new HttpClient();
            //var response=client.GetStringAsync("https://myrez.herokuapp.com/users");
            //loginDetailsDB = JsonConvert.DeserializeObject<List<LoginSignUp>>(response.ToString());
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://myrez.herokuapp.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("users");
                if (response.IsSuccessStatusCode)
                {
                    loginDetailsDB = await response.Content.ReadAsAsync<List<LoginSignUp>>();
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

        }
    }
}
