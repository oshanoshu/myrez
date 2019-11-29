using System;

namespace MyRez.Models
{
    public class Fines
    {
        public int FineID { get; set; }
        public String fineReason { get; set; }
        public int fineAmount { get; set; }
        public int AdmID { get; set; }
        public int ResID { get; set; }
        
    }
}
