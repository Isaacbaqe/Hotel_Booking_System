using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hotel_Booking_System.Startup))]
namespace Hotel_Booking_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
