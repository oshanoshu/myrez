using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyRez.Database;
using MyRez.Models;

namespace MyRez.ViewModels
{
    public class GuestUserAdminViewModel:BaseViewModel
    {
        private ObservableCollection<Guest> guests;
        private ObservableCollection<Residents> residents;
        private Database_API database = new Database_API();
        public GuestUserAdminViewModel()
        {
            dataGuests();
        }

        private async void dataGuests()
        {
            guests = await database.GetGuestAsync();
            residents = await database.GetResidentsAsync();
            guests = guestsWithName(guests);
            OnPropertyChanged("Guests");
         
        }

        private ObservableCollection<Guest> guestsWithName(ObservableCollection<Guest> guests)
        {
            Dictionary<int, string> residentsList = new Dictionary<int, string>();
            foreach (var resident in residents)
            {
                residentsList.Add(resident.ResidentID, resident.Name);
            }
            foreach (var guest in (IEnumerable<Guest>)guests)
            {
                guest.ResName = residentsList[guest.ResID];
            }
            return guests;
        }
        public ObservableCollection<Guest> Guests
        {
            get { return guests; }
            set
            {
                value = guests;
            }
        }
    }
}
