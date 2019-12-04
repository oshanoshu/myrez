using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using MyRez.Database;
using MyRez.Models;
using Xamarin.Forms;

namespace MyRez.ViewModels
{
    public class WorkOrdersUserViewModel:BaseViewModel
    {
        private WorkOrder workOrder=new WorkOrder();
        public Command ProcessWorkOrder { get; set; }
        private Database_API database_API = new Database_API();
        private ObservableCollection<Residents> residents;
        public WorkOrdersUserViewModel()
        {
            ProcessWorkOrder = new Command(() => ProcessWorkOrdersAsync());

        }

        private async void ProcessWorkOrdersAsync()
        {
            residents = await database_API.GetResidentsAsync();
            workOrder = ProcessWorkOrderWithNameAsync(workOrder);
            database_API.postNewWorkOrderAsync(workOrder);
        }

        private WorkOrder ProcessWorkOrderWithNameAsync(WorkOrder workOrder)
        {
            string userName = Application.Current.Properties["Username"].ToString();
            int residentId = (from resident in residents where resident.Username.ToLower() == userName.ToLower() select resident.ResidentID).FirstOrDefault();
            workOrder.ResId = residentId;
            return workOrder;
        }

        public String WorkOrderItem
        {
            get { return workOrder.WorkOrderItem; }
            set {
                value = workOrder.WorkOrderItem;
                OnPropertyChanged("WorkOrderItem");
            }
        }
        public String WorkOrderMonth
        {
            get { return DateTime.Now.ToString("MMMM dd"); }
            set
            {
                value = workOrder.WorkOrderMonth;
                OnPropertyChanged("WorkOrderMonth");
            }
        }
           
    }
}
