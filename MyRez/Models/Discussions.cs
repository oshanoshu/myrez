using System;

namespace MyRez.Models
{
    public class Discussions
    {
        public int DiscussionID { get; set; }
        public String DiscussionTitle { get; set; }
        public String DiscussionBody { get; set; }
        public String DiscussionTime { get; set; }
        public int ResID { get; set; }
        public String ResName { get {return resName; } set {resName=value; } }
        private String resName = "name";
    }
}
