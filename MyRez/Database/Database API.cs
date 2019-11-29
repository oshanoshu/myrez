using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using MyRez.Models;
using MyRez.Extensions;
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

        //Get all workOrders
        public async System.Threading.Tasks.Task<ObservableCollection<WorkOrder>> GetWorkOrdersAsync()
        {
            IEnumerable<WorkOrder> workOrders;
            HttpResponseMessage response = await client.GetAsync("workorder");
            if (response.IsSuccessStatusCode)
            {
                //Setting the data to the model
                workOrders = await response.Content.ReadAsAsync<IEnumerable<WorkOrder>>();
                if (workOrders != null)
                    return workOrders.ToObservableCollection();
                else
                    return new ObservableCollection<WorkOrder>();
            }
            else
                return new ObservableCollection<WorkOrder>();
            
        }

        //Get userverification details
        public async System.Threading.Tasks.Task<List<MockUsers>> GetUsersVerificationAsync()
        {
            List<MockUsers> mockUsers;
            HttpResponseMessage response = await client.GetAsync("mockusers");
            if (response.IsSuccessStatusCode)
            {
                //Setting the data to the model
                return mockUsers = await response.Content.ReadAsAsync<List<MockUsers>>();
            }
            Console.WriteLine("Internal server Error");
            return mockUsers = null;

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
            loginSignUp.role = "Admin";

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

        //Post New  User
        public async void SignUpResidentUsersAsync(LoginSignUp loginSignUp, Residents residents)
        {
            loginSignUp.role = "Resident";
            HttpResponseMessage response1 = await client.PostAsJsonAsync("users", loginSignUp);
            if (!response1.IsSuccessStatusCode)
            {
                ////Setting the data to the model
                //return loginDetailsDB = await response.Content.ReadAsAsync<List<LoginSignUp>>();
                Console.WriteLine("Internal server Error");
            }
            HttpResponseMessage response2 = await client.PostAsJsonAsync("userresident", residents);
            if (!response2.IsSuccessStatusCode)
            {
                Console.WriteLine("Internal server Error");

            }
            //return loginDetailsDB = null;

        }

    }
}
