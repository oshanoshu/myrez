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
        public async System.Threading.Tasks.Task<ObservableCollection<MockUsers>> GetUsersVerificationAsync()
        {
            IEnumerable<MockUsers> mockUsers;
            HttpResponseMessage response = await client.GetAsync("mockusers");
            if (response.IsSuccessStatusCode)
            {
                //Setting the data to the model
                mockUsers = await response.Content.ReadAsAsync<IEnumerable<MockUsers>>();
                if (mockUsers != null)
                    return mockUsers.ToObservableCollection();
                else
                    return new ObservableCollection<MockUsers>();
            }
            Console.WriteLine("Internal server Error");
            return new ObservableCollection<MockUsers>();

        }

        //Get login details
        public async System.Threading.Tasks.Task<ObservableCollection<LoginSignUp>> GetUsersAsync()
        {
            IEnumerable<LoginSignUp> loginDetailsDB;
            HttpResponseMessage response = await client.GetAsync("users");
            if (response.IsSuccessStatusCode)
            {
                //Setting the data to the model
                loginDetailsDB = await response.Content.ReadAsAsync<IEnumerable<LoginSignUp>>();
                return loginDetailsDB.ToObservableCollection();
            }
            Console.WriteLine("Internal server Error");
            return new ObservableCollection<LoginSignUp>();
            
        }

        //Get resident users
        public async System.Threading.Tasks.Task<ObservableCollection<Residents>> GetResidentsAsync()
        {
            IEnumerable<Residents> discussionsDB;
            HttpResponseMessage response = await client.GetAsync("userresident");
            if (response.IsSuccessStatusCode)
            {
                discussionsDB = await response.Content.ReadAsAsync<IEnumerable<Residents>>();

                if (discussionsDB != null)
                    return discussionsDB.ToObservableCollection();
                else
                    return new ObservableCollection<Residents>();
            }
            else
                return new ObservableCollection<Residents>();

        }


        //Get admin users
        public async System.Threading.Tasks.Task<ObservableCollection<Administrators>> GetAdministratorsAsync()
        {
            IEnumerable<Administrators> discussionsDB;
            HttpResponseMessage response = await client.GetAsync("useradmin");
            if (response.IsSuccessStatusCode)
            {
                discussionsDB = await response.Content.ReadAsAsync<IEnumerable<Administrators>>();

                if (discussionsDB != null)
                    return discussionsDB.ToObservableCollection();
                else
                    return new ObservableCollection<Administrators>();
            }
            else
                return new ObservableCollection<Administrators>();

        }

        //Post New Admin User
        public async void SignUpAdminUsersAsync(LoginSignUp loginSignUp, Administrators administrators)
        {
            loginSignUp.Role = "Admin";

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
            loginSignUp.Role = "user";
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
        
         //Get discussions
        public async System.Threading.Tasks.Task<ObservableCollection<Discussions>> GetDiscussionsAsync()
        {
            IEnumerable<Discussions> discussionsDB;
            HttpResponseMessage response = await client.GetAsync("discussions");
            if (response.IsSuccessStatusCode)
            {
               discussionsDB = await response.Content.ReadAsAsync<IEnumerable<Discussions>>();

               if (discussionsDB != null)
                    return discussionsDB.ToObservableCollection();
                else
                    return new ObservableCollection<Discussions>();
            }
            else
                return new ObservableCollection<Discussions>();

        }

        //Post discussions
        public async void postNewDiscussionsAsync(Discussions discussions)
        {
            HttpResponseMessage response1 = await client.PostAsJsonAsync("discussions", discussions);
            if (!response1.IsSuccessStatusCode)
            {
                ////Setting the data to the model
                //return discussionsDB = await response.Content.ReadAsAsync<List<discussions>>();
                Console.WriteLine("Internal server Error");
            }
            

        }


        //Post workorders
        public async void postNewWorkOrderAsync(WorkOrder workorder)
        {
            HttpResponseMessage response1 = await client.PostAsJsonAsync("workorder",workorder);
            if (!response1.IsSuccessStatusCode)
            {
                ////Setting the data to the model
                //return workorderDB = await response.Content.ReadAsAsync<List<workorder>>();
                Console.WriteLine("Internal server Error");
            }


        }

        //Get Comments
        public async System.Threading.Tasks.Task<ObservableCollection<Comments>> GetCommentsAsync()
        {
            IEnumerable<Comments> commentsDB;
            HttpResponseMessage response = await client.GetAsync("comments");
            if (response.IsSuccessStatusCode)
            {
                commentsDB = await response.Content.ReadAsAsync<IEnumerable<Comments>>();

               if (commentsDB != null)
                    return commentsDB.ToObservableCollection();
                else
                    return new ObservableCollection<Comments>();
            }
            else
                return new ObservableCollection<Comments>();

        }

        //Post comments
        public async void postNewCommentsAsync(Comments comments)
        {
            HttpResponseMessage response1 = await client.PostAsJsonAsync("comments",comments);
            if (!response1.IsSuccessStatusCode)
            {
                ////Setting the data to the model
                //return commentsDB = await response.Content.ReadAsAsync<List<comments>>();
                Console.WriteLine("Internal server Error");
            }


        }

        //Get Fines
        public async System.Threading.Tasks.Task<ObservableCollection<Fines>> GetFinesAsync()
        {
            IEnumerable<Fines> finesDB;
            HttpResponseMessage response = await client.GetAsync("fines");
            if (response.IsSuccessStatusCode)
            {
               finesDB = await response.Content.ReadAsAsync<IEnumerable<Fines>>();

               if (finesDB != null)
                    return finesDB.ToObservableCollection();
                else
                    return new ObservableCollection<Fines>();
            }
            else
                return new ObservableCollection<Fines>();

        }

        //Post Fines
        public async void postNewFineAsync(Fines  fines)
        {
            HttpResponseMessage response1 = await client.PostAsJsonAsync("fines",fines);
            if (!response1.IsSuccessStatusCode)
            {
                ////Setting the data to the model
                //return finesDB = await response.Content.ReadAsAsync<List<fines>>();
                Console.WriteLine("Internal server Error");
            }


        }

        //Get Guests
        public async System.Threading.Tasks.Task<ObservableCollection<Guest>> GetGuestAsync()
        {
            IEnumerable<Guest> guestsDB;
            HttpResponseMessage response = await client.GetAsync("guests");
            if (response.IsSuccessStatusCode)
            {
                guestsDB = await response.Content.ReadAsAsync<IEnumerable<Guest>>();

               if (guestsDB != null)
                    return guestsDB.ToObservableCollection();
                else
                    return new ObservableCollection<Guest>();
            }
            else
                return new ObservableCollection<Guest>();
        }

        //Post New Guests
        public async void postNewGuestAsync(Guest guests)
        {
            HttpResponseMessage response1 = await client.PostAsJsonAsync("guests",guests);
            if (!response1.IsSuccessStatusCode)
            {
                ////Setting the data to the model
                //return guestsDB = await response.Content.ReadAsAsync<List<guests>>();
                Console.WriteLine("Internal server Error");
            }


        }

        //Get Emergency Alerts
        public async System.Threading.Tasks.Task<ObservableCollection<EmergencyAlerts>> GetEmergencyAlertsAsync()
        {
            IEnumerable<EmergencyAlerts> emergencyalertsDB;
            HttpResponseMessage response = await client.GetAsync("emergencyalerts");
            if (response.IsSuccessStatusCode)
            {
                emergencyalertsDB = await response.Content.ReadAsAsync<IEnumerable<EmergencyAlerts>>();

               if (emergencyalertsDB != null)
                    return emergencyalertsDB.ToObservableCollection();
                else
                    return new ObservableCollection<EmergencyAlerts>();
            }
            else
                return new ObservableCollection<EmergencyAlerts>();

        }

        //Post Emergency Alerts
        public async void postNewEmergencyAlertsAsync(EmergencyAlerts emergencyalerts)
        {
            HttpResponseMessage response1 = await client.PostAsJsonAsync("emergencyalerts",emergencyalerts);
            if (!response1.IsSuccessStatusCode)
            {
                ////Setting the data to the model
                //return emergencyalertsDB = await response.Content.ReadAsAsync<List<emergencyalerts>>();
                Console.WriteLine("Internal server Error");
            }


        }

    }
}
