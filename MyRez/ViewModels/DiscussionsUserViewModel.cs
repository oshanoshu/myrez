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
        Database_API database_API = new Database_API();

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
            ProcessDiscussion = new Command(() => PostDiscussionsAsync());
        }

        private async void PostDiscussionsAsync()
        {
            residents = await database_API.GetResidentsAsync();
            discussion = ProcessDiscussionsWithNameAsync(discussion);
            discussion.DiscussionTime = DateTime.Now.ToString("dd MMMM yyyy HH:mm");
            database_API.postNewDiscussionsAsync(discussion);
            //var item = discussions[itemIndex];
        }

        private Discussions ProcessDiscussionsWithNameAsync(Discussions discussion)
        {
            string userName = Application.Current.Properties["Username"].ToString();
            int residentId = (from resident in residents where resident.Username.ToLower() == userName.ToLower() select resident.ResidentID).FirstOrDefault();
            discussion.ResID = residentId;
            return discussion;
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
        public String DiscussionBody
        {
            get { return discussion.DiscussionBody; }
            set
            {
                if(value!=discussion.DiscussionBody)
                {
                    discussion.DiscussionBody = value;
                }
            }
        }
        public String DiscussionTitle
        {
            get { return discussion.DiscussionTitle; }
            set
            {
                if (value != discussion.DiscussionTitle)
                {
                    discussion.DiscussionTitle = value;
                }
            }
        }
        public Discussions discussion=new Models.Discussions();
        public Command DiscussionsBind { get; }

        public Command ProcessDiscussion { get; }


    }
}
