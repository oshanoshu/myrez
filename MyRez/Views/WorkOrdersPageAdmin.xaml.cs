using System;
using System.Collections.Generic;
using MyRez.ViewModels;
using Xamarin.Forms;

namespace MyRez.Views
{
    public partial class WorkOrdersPageAdmin : ContentPage
    {
        public WorkOrdersPageAdmin()
        {
            InitializeComponent();
            BindingContext = new WorkOrdersAdminViewModel();
        }
    }
}
