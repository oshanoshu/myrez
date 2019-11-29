using System;

namespace MyRez.Models
{
    public class Comments
    {
        public int CommentID { get; set; }
        public String CommentBody { get; set; }
        public String CommentTime { get; set; }
        public int resid { get; set; }
        public int disid { get; set; }
    }
}
