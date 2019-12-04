using System;
using System.Collections.Generic;
using MyRez.ViewModels;
using Xamarin.Forms;

namespace MyRez.Views
{
    public partial class FinePageAdmin : ContentPage
    {
        public FinePageAdmin()
        {
            InitializeComponent();
            BindingContext = new FineAdminViewModel();

         }
    }
}
