using System;
using System.Collections.Generic;
using MyRez.ViewModels;
using Xamarin.Forms;
using MyRez.message;
namespace MyRez.Views
{
    public partial class SignupPageAdmin : ContentPage
    {
        public SignupPageAdmin()
        {
            InitializeComponent();
        }
        
        async void SignUpAdminButton(object sender, EventArgs e)
        {
            string Name = name.Text;
            string PhoneNumber = phoneNumber.Text;
            string Major = major.Text;
            string Building = building.Text;
            string Address = address.Text;
            string Username = userName.Text;
            string Password = passWord.Text;
            string CPassword = confirmPassword.Text;
            sendmessage sendmessage = new sendmessage("abcdefg");

            Application.Current.MainPage = new NavigationPage(new Verification());
            
        }

      
    }
}
