using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MyRez.Database;
using MyRez.Models;
using Xamarin.Forms;

namespace MyRez.ViewModels
{
    public class DiscussionsUserViewModel : BaseViewModel
    {
        private ObservableCollection<Discussions> discussions;
        private ObservableCollection<Residents> residents;

        private int itemIndex = -1;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }
        public DiscussionsUserViewModel()
        {
            dataDiscussions();
            DeleteDiscussions = new Command(() => DeleteDiscussionsAsync());
        }

        private void DeleteDiscussionsAsync()
        {

            //var item = discussions[itemIndex];
        }

        private bool isBusy = true;

        public async void dataDiscussions()
        {
            isBusy = true;
            Database_API database = new Database_API();
            residents = await database.GetResidentsAsync();
            discussions = await database.GetDiscussionsAsync();
            discussions = discussionsWithName(discussions);
            OnPropertyChanged("Discussions");
            isBusy = false;
            OnPropertyChanged("IsBusy");
            //string abc = "0";
        }
        public ObservableCollection<Discussions> discussionsWithName(ObservableCollection<Discussions> discussions)
        {
            Dictionary<int, string> residentsList = new Dictionary<int, string>();
            foreach (var resident in residents)
            {
                residentsList.Add(resident.ResidentID, resident.Name);
            }
            foreach (var discussion in (IEnumerable<Discussions>)discussions)
            {
                discussion.ResName = residentsList[discussion.ResID];
            }
            return discussions;
        }
        public ObservableCollection<Discussions> Discussions
        {
            get { return discussions; }
            set
            {
                discussions = value;
                OnPropertyChanged();
            }
        }
        public Command DiscussionsBind { get; }

        public Command DeleteDiscussions { get; }


    }
}
