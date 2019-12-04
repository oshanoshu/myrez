using System;
using System.Collections.Generic;
using MyRez.ViewModels;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MyRez.Views
{
    public partial class GuestsPageUser : ContentPage
    {
        GuestUserViewModel guestUserViewModel;
        public String myBinding;
        public GuestsPageUser()
        {
            InitializeComponent();
            BindingContext = guestUserViewModel = new GuestUserViewModel();
            Run();
        }

        private void Run()
        {
            if (FullName.Text == null)
            {
                FullName.IsVisible = false;
                grid.IsVisible = true;
                button.Text = "Check Out";
            }
            else
            {
                FullName.IsVisible = true;
                grid.IsVisible = false;
                button.Text = "Check In";
            }
        }

        public void OnButtonClicked(Object sender, EventArgs e)
        {
            if(button.Text=="Check Out")
            {
                FullName.IsVisible = true;
                grid.IsVisible = false;
                button.Text = "Check In";
                
            }
            else
            {
                FullName.IsVisible = false;
                grid.IsVisible = true;
                button.Text = "Check Out";
            }
        }
    }

}