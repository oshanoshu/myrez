using System;
using System.Threading.Tasks;
using MyRez.Database;
using MyRez.Models;
using MyRez.Views;
using Xamarin.Forms;

namespace MyRez.ViewModels
{
    public class SignupPageAdminViewModel:BaseViewModel
    {
        LoginSignUp logindetails = new LoginSignUp();
        Administrators administrators  = new Administrators();
        public SignupPageAdminViewModel()
        {
            SignUpUsers = new Command(async () => await SignUpAsync());
            VerifyUsers = new Command(async () => await VerifyAsync());
        }

        private Task VerifyAsync()
        {
            throw new NotImplementedException();
        }

        private async Task SignUpAsync()
        {
            if(Validate())
            {
                logindetails.Username = administrators.Username;
                Database_API database = new Database_API();
                database.SignUpAdminUsersAsync(logindetails, administrators);
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
        public Command VerifyUsers { get; }
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
                return administrators.Name;
            }
            set
            {
                if (value != administrators.Name)
                {

                    administrators.Name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Email
        {
            get
            {
                return administrators.Email;
            }
            set
            {
                if (value != administrators.Email)
                {
                    administrators.Email = value;
                    OnPropertyChanged();
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                return administrators.PhoneNumber;
            }
            set
            {
                if (value != administrators.PhoneNumber)
                {
                    administrators.PhoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Building
        {
            get
            {
                return administrators.Building;
            }
            set
            {
                if (value != administrators.Building)
                {
                    administrators.Building = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Address
        {

            get
            {
                return administrators.Address;
            }
            set
            {
                if (value != administrators.Address)
                {

                    administrators.Address = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Major
        {
            get
            {
                return administrators.Major;
            }
            set
            {
                if (value != administrators.Major)
                {
                    administrators.Major = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Username
        {
            get
            {
                return administrators.Username;
            }
            set
            {
                if (value != administrators.Username)
                {
                    administrators.Username = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get
            {
                return logindetails.Password;
            }
            set
            {
                if (value != logindetails.Password)
                {
                    logindetails.Password = value;
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
