using System;
using System.Collections.Generic;
using MyRez.ViewModels;
using Xamarin.Forms;

namespace MyRez.Views
{
    public partial class GuestsPageAdmin : ContentPage
    {
        public GuestsPageAdmin()
        {
            InitializeComponent();
            BindingContext = new GuestUserAdminViewModel();
        }
    }
}
