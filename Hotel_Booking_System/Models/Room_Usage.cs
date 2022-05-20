using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel_Booking_System.Models
{
    public class Room_Usage
    {
       
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Resroom_number { get; set; }
        public string Booking_Name { get; set; }


    }
}