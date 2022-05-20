using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel_Booking_System.Models
{
    public class Room
    {
       [Key] public int Room_number { get; set; }
        public string  Room_type { get; set; }
        public string  Room_loca { get; set; }
        //public string Room_Type { get; set; }
        public bool? Room_status { get; set; }
        //public DateTime Date {0 get; set; }
         
        //public string[] types => new string[] { "Single", "Double", "Suite" };
        ////[NotMapped]
        ////public virtual List<Room> Rooms => new ApplicationDbContext().Rooms.ToList();
        //public virtual List<Room_Usage>  _Usages => new ApplicationDbContext().Room_Usage.ToList().Where(x=>x.Room_Id==Room_Id).ToList();
    }
}