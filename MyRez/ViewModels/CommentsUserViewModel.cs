using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MyRez.Database;
using MyRez.Extensions;
using MyRez.Models;
using Xamarin.Forms;

namespace MyRez.ViewModels
{
    public class CommentsUserViewModel:BaseViewModel
    {
        private ObservableCollection<Comments> comments;
        private Comments comment = new Comments();
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
        public CommentsUserViewModel()
        {
            dataComments();
            ProcessComment = new Command(() => PostCommentsAsync());
            DeleteComments = new Command(() => DeleteCommentsAsync());
        }

        private async void PostCommentsAsync()
        {
            residents = await database_API.GetResidentsAsync();
            comment = ProcessCommentsWithNameAsync(comment);
            comment.CommentTime = DateTime.Now.ToString("dd MMMM yyyy HH:mm");
            database_API.postNewCommentsAsync(comment);
        }

        private Comments ProcessCommentsWithNameAsync(Comments comment)
        {
            string userName = Application.Current.Properties["Username"].ToString();
            int residentId = (from resident in residents where resident.Username.ToLower() == userName.ToLower() select resident.ResidentID).FirstOrDefault();
            comment.ResID = residentId;
            comment.DisID = 1;
            return comment;
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
            //ObservableCollection <Comments> commentsNow = (from comment in comments where comment.DisID == discussionNow.DiscussionID select comment).ToObservableCollection();
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
        public String Comment
        {
            get { return comment.CommentBody; }
            set
            {
                comment.CommentBody = value;
                OnPropertyChanged();
            }
        }

        public Command ProcessComment { get; }

        public Command DeleteComments { get; }


    
    }
}
