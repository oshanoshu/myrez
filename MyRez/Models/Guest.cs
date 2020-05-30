using System;

namespace MyRez.Models
{
    public class Guest
    {
        public string ResName { get; set; }

        public int GuestID { get; set; }
        public String GuestName { get; set; }
        public String CheckinTime { get; set; }
        public int ResID { get; set; }
        public bool CheckedIn { get; set; }
    }
}
