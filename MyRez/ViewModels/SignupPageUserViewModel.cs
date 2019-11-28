using System;
using System.Threading.Tasks;
using MyRez.Database;
using MyRez.Models;
using MyRez.Views;
using Xamarin.Forms;

namespace MyRez.ViewModels
{
    public class SignupPageUserViewModel:BaseViewModel
    {
        public SignupPageUserViewModel()
        {
            SignUpUsers = new Command(async () => await SignUpAsync());
        }
        LoginSignUp logindetails = new LoginSignUp();
        Residents residents = new Residents();
       
        private async Task SignUpAsync()
        {
            if (Validate())
            {
                logindetails.username = residents.Username;
                Database_API database = new Database_API();
                database.SignUpResidentUsersAsync(logindetails, residents);
                Application.Current.MainPage = new NavigationPage(new MenuPageAdmin());
            }
            else
            {
                Console.WriteLine("Database Error.");
            }

        }

        private bool Validate()
        {
            return true;
        }

        public Command SignUpUsers { get; }
        //public string name = String.Empty;
        //public string email = String.Empty;
        //public string phoneNumber = String.Empty;
        //public string building = String.Empty;
        //public string address = String.Empty;
        //public string major = String.Empty;
        //public string username = String.Empty;
        //public string password = String.Empty;
        public string cPassword = String.Empty;
        public string Name
        {

            get
            {
                return residents.Name;
            }
            set
            {
                if (value != residents.Name)
                {

                    residents.Name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Email
        {
            get
            {
                return residents.Email;
            }
            set
            {
                if (value != residents.Email)
                {
                    residents.Email = value;
                    OnPropertyChanged();
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                return residents.PhoneNumber;
            }
            set
            {
                if (value != residents.PhoneNumber)
                {
                    residents.PhoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Building
        {
            get
            {
                return residents.Building;
            }
            set
            {
                if (value != residents.Building)
                {
                    residents.Building = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Address
        {

            get
            {
                return residents.Address;
            }
            set
            {
                if (value != residents.Address)
                {

                    residents.Address = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Major
        {
            get
            {
                return residents.Major;
            }
            set
            {
                if (value != residents.Major)
                {
                    residents.Major = value;
                    OnPropertyChanged();
                }
            }
        }
        public int RoomNumber
        {
            get
            {
                return residents.RoomNumber;
            }
            set
            {
                if (value != residents.RoomNumber)
                {
                    residents.RoomNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        public string EmergencyContact
        {
            get
            {
                return residents.EmergencyContact;
            }
            set
            {
                if (value != residents.EmergencyContact)
                {
                    residents.EmergencyContact = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Username
        {
            get
            {
                return residents.Username;
            }
            set
            {
                if (value != residents.Username)
                {
                    residents.Username = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get
            {
                return logindetails.password;
            }
            set
            {
                if (value != logindetails.password)
                {
                    logindetails.password = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CPassword
        {
            get
            {
                return cPassword;
            }
            set
            {
                if (value != cPassword)
                {
                    cPassword = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
