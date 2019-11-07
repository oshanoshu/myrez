using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using MyRez.message;
using MyRez.Models;
using Xamarin.Forms;

namespace MyRez.Views
{
    public partial class Verification : ContentPage
    {
        public Verification()
        {
            InitializeComponent();
        }

        async void clicked(object sender, EventArgs e)
        {
            string uniqueCode="";
            List<MockUsers> mockDetailsDB;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://myrez.herokuapp.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("mockUsers");
                if (response.IsSuccessStatusCode)
                {
                    mockDetailsDB = await response.Content.ReadAsAsync<List<MockUsers>>();
                }
                else
                {
                mockDetailsDB = null;
                    Console.WriteLine("Internal server Error");
                }
            
            for (int i = 0; i < mockDetailsDB.Count; i++)
            {
                if (string.Equals("+1"+mockDetailsDB[i].phone, "+12084062637"))
                {
                    uniqueCode = mockDetailsDB[i].uniqueID;
                    sendmessage sendmessage = new sendmessage(mockDetailsDB[i].uniqueID);
                }
                
            }
            if ((code.Text.ToLower()).Equals(uniqueCode))
            {
                Application.Current.Properties["IsLoggedIn"] = true;
                await Application.Current.SavePropertiesAsync();
                Application.Current.MainPage = new NavigationPage(new MenuPageAdmin());
            }
        }
    }
}