using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MyRez.Database;
using MyRez.Models;
using Xamarin.Forms;

namespace MyRez.ViewModels
{
    public class CommentsAdminViewModel:BaseViewModel
    {
        private ObservableCollection<Comments> comments;
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
        public CommentsAdminViewModel()
        {
            dataComments();
            DeleteComments = new Command(() => DeleteCommentsAsync());
        }

        private void DeleteCommentsAsync()
        {

            //var item = comments[itemIndex];
        }

        private bool isBusy = true;

        public async void dataComments()
        {
            isBusy = true;
            Database_API database = new Database_API();
            residents = await database.GetResidentsAsync();
            residents = await database.GetResidentsAsync();
            comments = await database.GetCommentsAsync();
            //Discussions discussionNow = (from discussion in discussions where discussion.DiscussionTitle == discussionTitle select discussion).First();
            //ObservableCollection<Comments> commentsNow = (from comment in comments where comment.DisID == discussionNow.DiscussionID select comment).ToObservableCollection();
            comments = commentsWithName(comments);
            OnPropertyChanged("Comments");
            isBusy = false;
            OnPropertyChanged("IsBusy");
            //string abc = "0";
        }
        public ObservableCollection<Comments> commentsWithName(ObservableCollection<Comments> comments)
        {
            Dictionary<int, string> residentsList = new Dictionary<int, string>();
            foreach (var resident in residents)
            {
                residentsList.Add(resident.ResidentID, resident.Name);
            }
            foreach (var comment in (IEnumerable<Comments>)comments)
            {
                comment.ResName = residentsList[comment.ResID];
            }
            return comments;
        }
        public ObservableCollection<Comments> Comments
        {
            get { return comments; }
            set
            {
                comments = value;
                OnPropertyChanged();
            }
        }
        public Command CommentsBind { get; }

        public Command DeleteComments { get; }



    }
}
