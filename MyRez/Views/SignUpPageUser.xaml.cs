using System;
using System.Collections.Generic;
using MyRez.ViewModels;
using Xamarin.Forms;

namespace MyRez.Views
{
    public partial class SignUpPageUser : ContentPage
    {
        public SignUpPageUser()
        {
            InitializeComponent();
            BindingContext = new SignupPageUserViewModel();
            
        }
    }
}
