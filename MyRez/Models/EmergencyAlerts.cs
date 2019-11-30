using System;

namespace MyRez.Models
{
    public class EmergencyAlerts
    {
        public int EmergencyID { get; set; }
        public String EmergencyCategory { get; set; }
        public String EmergencyMessage { get; set; }
        public int AdmID { get; set; }
    }
}
