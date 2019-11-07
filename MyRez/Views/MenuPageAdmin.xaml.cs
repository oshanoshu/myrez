using System;
using System.Collections.Generic;
using MyRez.Models;
using Xamarin.Forms;

namespace MyRez.Views
{
    public partial class MenuPageAdmin : MasterDetailPage
    {
        public List<MainMenuItem> MainMenuItems { get; set; }

        public MenuPageAdmin()
        {
            // Set the binding context to this code behind.
            BindingContext = this;

            // Build the Menu
            MainMenuItems = new List<MainMenuItem>()
        {
            new MainMenuItem() { Title = "Discussions", Icon = "menu_inbox.png", TargetType = typeof(DiscussionPageAdmin) },
            new MainMenuItem() { Title = "Work Orders", Icon = "menu_stock.png", TargetType = typeof(WorkOrdersPageAdmin) },
            new MainMenuItem() { Title = "Emergency Alerts", Icon = "menu_stock.png", TargetType = typeof(EmergencyAlertsPageAdmin) },
            new MainMenuItem() { Title = "Log Out", Icon = "menu_stock.png"}

        };

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(new DiscussionPageAdmin());

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
                    Detail = new NavigationPage(new WorkOrdersPageAdmin());
                }
                else if (item.Title.Equals("Work Orders"))
                {
                    Detail = new NavigationPage(new EmergencyAlertsPageAdmin());
                }
                else if (item.Title.Equals("Emergency Alerts"))
                {
                    Detail = new NavigationPage(new EmergencyAlertsPageAdmin());
                }
                else if (item.Title.Equals("Log Out"))
                {
                    Application.Current.Properties["IsLoggedIn"] = false;
                    Application.Current.SavePropertiesAsync();
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                    
                }

                MenuListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
