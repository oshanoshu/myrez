using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyRez.Models;
using MyRez.ViewModels;
using Xamarin.Forms;

namespace MyRez.Views
{
    public partial class CommentsPageUser : ContentPage
    {
        public CommentsPageUser()
        {
            InitializeComponent();
            BindingContext = new CommentsUserViewModel();
        }

       
    }
}
