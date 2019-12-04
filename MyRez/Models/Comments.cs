using System;

namespace MyRez.Models
{
    public class Comments
    {
        public int CommentID { get; set; }
        public String CommentBody { get; set; }
        public String CommentTime { get; set; }
        public int ResID { get; set; }
        public int DisID { get; set; }
        public String ResName { get { return resName; } set { resName = value; } }
        private String resName = "name";
    }
}
