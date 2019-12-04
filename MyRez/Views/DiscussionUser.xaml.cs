using System;
using System.Collections.Generic;
using MyRez.ViewModels;
using Xamarin.Forms;

namespace MyRez.Views
{
    public partial class DiscussionUser : ContentPage
    {
        DiscussionsUserViewModel discussionsUserViewModel;
        public DiscussionUser()
        {
            InitializeComponent();
            BindingContext = discussionsUserViewModel = new DiscussionsUserViewModel();

        }
        public async void OnButtonClicked(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CommentsPageUser());

        }
    }
}
