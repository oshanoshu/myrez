using System;
using System.Collections.Generic;
using MyRez.ViewModels;
using Xamarin.Forms;

namespace MyRez.Views
{
    public partial class WorkOrderPageUser : ContentPage
    {
        public WorkOrderPageUser()
        {
            InitializeComponent();
            BindingContext = new WorkOrdersUserViewModel();
        }
    }
}
