using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel_Booking_System.Models
{
    public class Guest
    {
        [Key]public int Guest_Id { get; set; }
        public int Guest_Names { get; set; }
        public int Guest_Phone { get; set; }
        public int Guest_Address { get; set; }
        public int Guest_Username { get; set; }
        public int Guest_Password { get; set; }
        public bool Isactive { get; set; }
        public DateTime Date { get; set; }
        //[NotMapped]
        //public virtual List<Guest> Guests => new ApplicationDbContext().Guests.ToList();
        public virtual List<Room_Usage>  _Usages => new ApplicationDbContext().Room_Usage.ToList().Where(x=>x.Gest_ID==Guest_Id).ToList();
    }
}