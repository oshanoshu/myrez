using System;
using System.Collections.ObjectModel;
using System.Linq;
using MyRez.Database;
using MyRez.Models;
using Xamarin.Forms;

namespace MyRez.ViewModels
{
    public class FineAdminViewModel:BaseViewModel
    {
        private Fines fines;
        private ObservableCollection<Administrators> administrators;
        private ObservableCollection<Residents> residents;
        public Command ProcessFines { get; set; }
        private Database_API database_API = new Database_API();
        private string residentName;

        public FineAdminViewModel()
        {
            ProcessFines = new Command(() => ProcessFinesAsync());
        }

        private async void ProcessFinesAsync()
        {
            administrators = await database_API.GetAdministratorsAsync();
            fines = ProcessFinesWithNameAsync(fines);
            database_API.postNewFineAsync(fines);
        }

        private Fines ProcessFinesWithNameAsync(Fines fines)
        {
            int residentId = (from resident in residents where resident.Name==ResidentName select resident.ResidentID).FirstOrDefault();
            int adminId = (from administrator in administrators where administrator.Username == Application.Current.Properties["Username"] select administrator.AdminID).FirstOrDefault();

            fines.ResID = residentId;
            fines.AdmID = adminId;
            return fines;
        }

        public int FineAmount
        {
            get { return fines.fineAmount; }
            set
            {
                value = fines.fineAmount;
                OnPropertyChanged("WorkOrderItem");
            }
        }
        public string ResidentName
        {
            get { return residentName; }
            set
            {
                value = residentName;
                OnPropertyChanged("ResidentName");
            }
        }
        public String FineReason
        {
            get { return fines.fineReason; }
            set
            {
                value = fines.fineReason;
                OnPropertyChanged("FineReason");
            }
        }
    }
}
