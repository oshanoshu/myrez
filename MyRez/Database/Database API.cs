using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using MyRez.Models;

namespace MyRez.Database
{
    public class Database_API
    {
        private HttpClient client;
        public Database_API()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://myrez.herokuapp.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Get login details
        public async System.Threading.Tasks.Task<List<LoginSignUp>> GetUsersAsync()
        {
            List<LoginSignUp> loginDetailsDB;
            HttpResponseMessage response = await client.GetAsync("users");
            if (response.IsSuccessStatusCode)
            {
                //Setting the data to the model
                return loginDetailsDB = await response.Content.ReadAsAsync<List<LoginSignUp>>();
            }
            Console.WriteLine("Internal server Error");
            return loginDetailsDB = null;
            
        }

        //Post New Admin User
        public async void SignUpAdminUsersAsync(LoginSignUp loginSignUp, Administrators administrators)
        {
          
            HttpResponseMessage response1 = await client.PostAsJsonAsync("users", loginSignUp);
            if (!response1.IsSuccessStatusCode)
            {
                ////Setting the data to the model
                //return loginDetailsDB = await response.Content.ReadAsAsync<List<LoginSignUp>>();
                Console.WriteLine("Internal server Error");
            }
            HttpResponseMessage response2 = await client.PostAsJsonAsync("useradmin",administrators);
            if(!response2.IsSuccessStatusCode)
            {
                Console.WriteLine("Internal server Error");

            }
            //return loginDetailsDB = null;

        }

    }
}
