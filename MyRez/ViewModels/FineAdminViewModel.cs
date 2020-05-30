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
        private Fines fines=new Fines();
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
            residents = await database_API.GetResidentsAsync();
            fines = ProcessFinesWithNameAsync(fines);
            database_API.postNewFineAsync(fines);
        }

        private Fines ProcessFinesWithNameAsync(Fines fines)
        {
            int residentId = (from resident in residents where resident.Name==residentName select resident.ResidentID).FirstOrDefault();
            int adminId = (from administrator in administrators where administrator.Username == Application.Current.Properties["Username"] select administrator.AdminID).FirstOrDefault();

            fines.ResID = residentId;
            fines.AdmID = 1;
            return fines;
        }

        public int FineAmount
        {
            get { return fines.fineAmount; }
            set
            {
                if (value != fines.fineAmount)
                {
                    fines.fineAmount = value;
                    OnPropertyChanged("FineAmount");
                }
            }
        }
        public string ResidentName
        {
            get { return residentName; }
            set
            {
                if (value != residentName)
                {
                    residentName = value;
                    OnPropertyChanged("ResidentName");
                }
            }
        }
        public String FineReason
        {
            get { return fines.fineReason; }
            set
            {
                if (value != fines.fineReason)
                {
                    fines.fineReason = value;
                    OnPropertyChanged("FineReason");
                }
            }
        }
    }
}
