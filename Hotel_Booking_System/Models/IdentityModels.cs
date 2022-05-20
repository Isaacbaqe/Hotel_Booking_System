using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hotel_Booking_System.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string Guest_Names { get; set; }
        public string Guest_Address { get; set; }  
        public bool Isactive { get; set; }
        public DateTime Date { get; set; }
        //[NotMapped]
        //public virtual List<Guest> Guests => new ApplicationDbContext().Guests.ToList();
        //public virtual List<Room_Usage> _Usages => new ApplicationDbContext().Room_Usage.ToList().Where(x => x.Gest_ID == Id).ToList();
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<Hotel_Booking_System.Models.Guest> Guests { get; set; }

        public System.Data.Entity.DbSet<Hotel_Booking_System.Models.Room> Rooms { get; set; }

        public System.Data.Entity.DbSet<Hotel_Booking_System.Models.Room_Usage> Room_Usage { get; set; }
    }
}