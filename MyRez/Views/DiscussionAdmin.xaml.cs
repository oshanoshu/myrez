using System;
using System.Collections.Generic;
using Android.Content.Res;
using MyRez.ViewModels;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace MyRez.Views
{
    public partial class DiscussionAdmin : ContentPage
    {
        DiscussionsAdminViewModel discussionsAdminViewModel;

        public DiscussionAdmin()
        {
            InitializeComponent();
            BindingContext = discussionsAdminViewModel = new DiscussionsAdminViewModel();
            
        }
        public async void OnButtonClickedAsync(Object sender, EventArgs e)
        { 
        
            await Navigation.PushAsync(new CommentsPageAdmin());
        }
       

    }
}
