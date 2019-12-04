using System;
using System.Collections.Generic;
using MyRez.ViewModels;
using Xamarin.Forms;

namespace MyRez.Views
{
    public partial class CommentsPageAdmin : ContentPage
    {
        public CommentsPageAdmin()
        {
            InitializeComponent();
            BindingContext = new CommentsAdminViewModel();
        }
    }
}
