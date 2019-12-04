using System;
using System.Collections.Generic;
using MyRez.Models;
using Xamarin.Forms;

namespace MyRez.Views
{
    public partial class MenuPageUser : MasterDetailPage
    {
        public List<MainMenuItem> MainMenuItems { get; set; }

        public MenuPageUser()
        {
            // Set the binding context to this code behind.
            BindingContext = this;

            // Build the Menu
            MainMenuItems = new List<MainMenuItem>()
        {
            new MainMenuItem() { Title = "Discussions",Icon="discussion.png", TargetType = typeof(DiscussionUser) },
            new MainMenuItem() { Title = "Work Orders",Icon="workorder.png", TargetType = typeof(WorkOrderPageUser) },
            new MainMenuItem() { Title = "Fines",Icon="fines.png", TargetType = typeof(FinePageUser) },
            new MainMenuItem() { Title = "Guests", Icon="guests.png", TargetType = typeof(GuestsPageUser) },
            new MainMenuItem() { Title = "Log Out", Icon="logout.png"}

        };

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(new DiscussionUser());

            InitializeComponent();
        }
        // When a MenuItem is selected.
        public void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMenuItem;
            if (item != null)
            {
                if (item.Title.Equals("Discussions"))
                {
                    Detail = new NavigationPage(new DiscussionUser());
                }
                else if (item.Title.Equals("Work Orders"))
                {
                    Detail = new NavigationPage(new WorkOrderPageUser());
                }
                else if (item.Title.Equals("Fines"))
                {
                    Detail = new NavigationPage(new FinePageUser());
                }
                else if (item.Title.Equals("Guests"))
                {
                    Detail = new NavigationPage(new GuestsPageUser());
                }
                else if (item.Title.Equals("Log Out"))
                {
                    Application.Current.Properties["IsLoggedIn"] = false;
                    Application.Current.Properties["Username"] = null;
                    Application.Current.Properties["Role"] = null;
                    Application.Current.SavePropertiesAsync();
                    Application.Current.MainPage = new NavigationPage(new LoginPage());

                }

                MenuListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
