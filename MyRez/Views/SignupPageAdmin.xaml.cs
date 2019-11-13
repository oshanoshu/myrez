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
            BindingContext = new SignupPageAdminViewModel();
        }
        
        

      
    }
}
