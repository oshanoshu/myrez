using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MyRez.Database;
using MyRez.Models;
using Xamarin.Forms;

namespace MyRez.ViewModels
{
    public class GuestUserViewModel:BaseViewModel
    {
        public ObservableCollection<Guest> guests;
        private ObservableCollection<Residents> residents;
        private Database_API database = new Database_API();
        public GuestUserViewModel()
        {
            dataGuests();
            GuestCheck = new Command(()=>GuestCheckAsync());
        }

        private void GuestCheckAsync()
        {

            Guest.GuestName = GuestName;

            if (!String.IsNullOrEmpty(Guest.GuestName))
            {
                int residentId = (from res in residents where res.Username == (string)Application.Current.Properties["Username"] select res.ResidentID).First();
                Guest.CheckedIn = true;
                checkinTime = DateTime.Now.ToString("dd MMMM yyyy HH:mm");
                OnPropertyChanged("CheckinTime");
                Guest.CheckinTime = checkinTime;
                Guest.ResID = residentId;
                database.postNewGuestAsync(Guest);

            }
        }

        private bool isBusy = true;
        private bool isGuest = true;
        private Guest guestNow;
        private string guestName;
        private string checkinTime;

        public async void dataGuests()
        {
            isBusy = true;
            
            residents = await database.GetResidentsAsync();
            guests = await database.GetGuestAsync();
            guestNow = guestsWithName(guests);
            OnPropertyChanged("Guest");
            checkinTime = guestNow.CheckinTime;
            OnPropertyChanged("CheckinTime");
            guestName = guestNow.GuestName;
            OnPropertyChanged("GuestName");
            isBusy = false;
            OnPropertyChanged("IsBusy");
            //string abc = "0";
        }

        private Guest guestsWithName(ObservableCollection<Guest> guests)
        {
            int residentId = (from res in residents where res.Username == (string)Application.Current.Properties["Username"] select res.ResidentID).First();
            Guest guestNow = (from guest in guests where guest.ResID == residentId & guest.CheckedIn==true select guest).FirstOrDefault();
            if (guestNow == null)
            {
                isGuest = false;
                OnPropertyChanged("IsGuest");
                return new Guest();
            }
            else
            {
                isGuest = true;
                OnPropertyChanged("IsGuest");
                return guestNow;
            }
        }

        
        public Guest Guest
        {
            get { return guestNow; }
            set
            {
                guestNow = value;
                OnPropertyChanged();
            }
        }
        public String GuestName
        {
            get { return guestName; }
            set
            {
                guestName = value;
                OnPropertyChanged();
            }
        }
        public String CheckinTime
        {
            get { return checkinTime; }
            set
            {
                checkinTime = value;
                OnPropertyChanged();
            }
        }
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public bool IsGuest
        {
            get { return isGuest; }
            set
            {
                isGuest = value;
                OnPropertyChanged();
            }
        }
        public Command GuestCheck { get; }
    }
}
