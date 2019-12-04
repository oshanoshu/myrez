using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MyRez.Database;
using MyRez.Extensions;
using MyRez.Models;
using Xamarin.Forms;

namespace MyRez.ViewModels
{
    public class WorkOrdersAdminViewModel:BaseViewModel
    {
        
        private ObservableCollection<WorkOrder> workOrders;
        private ObservableCollection<Residents> residents;
        private Database_API database = new Database_API();

        private int itemIndex = -1;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy=value;
                OnPropertyChanged();
            }
        }
            public WorkOrdersAdminViewModel()
        {
            dataWorkOrders();
            DeleteWorkOrders = new Command(()=>DeleteWorkOrderAsync());
        }

        private void DeleteWorkOrderAsync()
        {
            
                //var item = workOrders[itemIndex];
        }

        private bool isBusy = true;
        
        public async void dataWorkOrders()
        {
            isBusy=true;
            workOrders = await database.GetWorkOrdersAsync();
            residents = await database.GetResidentsAsync();
            workOrders = workOrderWithName(workOrders);
            OnPropertyChanged("WorkOrders");
            isBusy = false;
            OnPropertyChanged("IsBusy");
            string abc = "0";
        }

        public ObservableCollection<WorkOrder> workOrderWithName(ObservableCollection<WorkOrder> workorders)
        {
            Dictionary<int, string> residentsList = new Dictionary<int, string>();
            foreach (var resident in residents)
            {
                residentsList.Add(resident.ResidentID, resident.Name);
            }
            foreach (var workOrder in (IEnumerable<WorkOrder>)workOrders)
            {
                workOrder.ResName = residentsList[workOrder.ResId];
            }
            return workOrders;
        }

        public ObservableCollection<WorkOrder> WorkOrders
        {
            get { return workOrders; }
            set { workOrders = value;
                OnPropertyChanged();
            }
        }
        public Command WorkOrdersBind { get; }

        public Command DeleteWorkOrders { get;  }
    }
}
