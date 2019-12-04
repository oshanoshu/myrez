using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MyRez.Database;
using MyRez.message;
using MyRez.Models;
using Xamarin.Forms;

namespace MyRez.Views
{
    public partial class EmergencyAlertsPageAdmin : ContentPage
    {
        public ObservableCollection<MockUsers> mockUsers;

        public EmergencyAlertsPageAdmin()
        {
            InitializeComponent();

        }
        public async void OnButtonClickedAsync(object sender, EventArgs e)
        {
            String category= (string)picker.SelectedItem;
            String message = (string)editor.Text;
            ObservableCollection<MockUsers> mockUsers = new ObservableCollection<MockUsers>();
            mockUsers = await GetAsync();
            SendEmergencyNotifications sendEmergencyNotifications = new SendEmergencyNotifications(category,message,mockUsers);
            DisplayAlert("Succes!","Emergency alert has been sent succesfully.","Ok");
        }
        public async Task<ObservableCollection<MockUsers>> GetAsync()
        {
            Database_API database_API = new Database_API();
            mockUsers = await database_API.GetUsersVerificationAsync();
            return mockUsers;
        }
    }
}
