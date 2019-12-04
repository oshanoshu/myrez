using System;
using System.Collections.ObjectModel;
using System.Linq;
using MyRez.Database;
using MyRez.Extensions;
using MyRez.Models;
using Xamarin.Forms;

namespace MyRez.ViewModels
{
    public class FineUserViewModel:BaseViewModel
    {
        private ObservableCollection<Fines> fines;
        private ObservableCollection<Residents> residents;

        public FineUserViewModel()
        {
            dataFines();
        }
        public async void dataFines()
        {
            //isBusy = true;
            Database_API database = new Database_API();
            residents = await database.GetResidentsAsync();
            fines = await database.GetFinesAsync();
            fines = finesWithName(fines);
            OnPropertyChanged("Fines");
            //isBusy = false;
            //OnPropertyChanged("IsBusy");
            //string abc = "0";
        }

        private ObservableCollection<Fines> finesWithName(ObservableCollection<Fines> fines)
        {
            string userName = Application.Current.Properties["Username"].ToString();
            int residentId = (from res in residents where res.Username.ToLower() == userName.ToLower() select res.ResidentID).First();
            ObservableCollection<Fines> fineNow = (from fine in fines where fine.ResID == residentId select fine).ToObservableCollection();
            if (fineNow == null)
                return new ObservableCollection<Fines>();
            return fineNow;
        }
        public ObservableCollection<Fines> Fines
        {
            get { return fines; }
            set
            {
                fines = value;
                OnPropertyChanged();
            }
        }
    }
}
