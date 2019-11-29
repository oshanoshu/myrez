using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyRez.Database;
using MyRez.Models;
using Xamarin.Forms;

namespace MyRez.ViewModels
{
    public class WorkOrdersViewModel:BaseViewModel
    {
        
            private ObservableCollection<WorkOrder> workOrders;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy=value;
                OnPropertyChanged();
            }
        }
            public WorkOrdersViewModel()
        {
            dataWorkOrders();
        }
        private bool isBusy = true;
        public async void dataWorkOrders()
        {
            isBusy=true;
            Database_API database = new Database_API();
            workOrders = await database.GetWorkOrdersAsync();
            OnPropertyChanged("WorkOrders");
            isBusy = false;
            OnPropertyChanged("IsBusy");
            string abc = "0";
        }

        public ObservableCollection<WorkOrder> WorkOrders
        {
            get { return workOrders; }
            set { workOrders = value;
                OnPropertyChanged();
            }
        }
        public Command WorkOrdersBind { get; }


    }
}
