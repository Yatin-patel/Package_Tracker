using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Package_Tracker.Models
{
    public class Users
    {
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone_Number { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }
        public string Create_User { get; set; }
        public int Update_User { get; set; }
        public string Password { get; set; }
    }
}