﻿using System;
namespace MyRez.Models
{
    public class Residents : Users
    {
        public int ResidentID { get; set; }
        public String EmergencyContact { get; set; }
        public int RoomNumber { get; set; }
    }
}
