using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel_Booking_System.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Hotel_Booking_System.Controllers
{
    public class Room_UsageController : Controller
    { HttpClient client = new HttpClient();
        private ApplicationDbContext db = new ApplicationDbContext();
        HttpClient httpClient = new HttpClient();
        // GET: Room_Usage
        public async Task<ActionResult> Index()
        {

            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("https://localhost:44311/api/GuestBooking").Result;
            String message = httpResponseMessage.Content.ReadAsStringAsync().Result;

            List<Room_Usage> room = JsonConvert.DeserializeObject<List<Room_Usage>>(message).ToList();

            return View(room);
            
        }

        // GET: Room_Usage/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Usage room_Usage = await db.Room_Usage.FindAsync(id);
            if (room_Usage == null)
            {
                return HttpNotFound();
            }
            return View(room_Usage);
        }

        // GET: Room_Usage/Create
        [Route("~/Room_Usage/Create/{id}")]
        public ActionResult Create(int? id)
        {
            ViewBag.roomnum = id;
            return View(new Room_Usage());
        }

        // POST: Room_Usage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,Phone,Country,City,Resroom_number,Booking_Name")] Room_Usage room_Usage)

        {
            ViewBag.Data = room_Usage.Resroom_number;
            string Data = JsonConvert.SerializeObject(room_Usage);
            StringContent message = new StringContent(Data, Encoding.UTF8, "application/json");
            HttpResponseMessage Respons = client.PostAsync("https://localhost:44311/api/GuestBooking", message).Result;
                
            if(Respons.IsSuccessStatusCode)
            {
                ViewBag.Data = "added";

            }
            else
            {
                ViewBag.Data = "error";
            }

            return RedirectToAction("Index");
        }

        // GET: Room_Usage/Edit/5
        public async Task<ActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Usage room_Usage = await db.Room_Usage.FindAsync(Id);
            if (room_Usage == null)
            {
                return HttpNotFound();
            }
            return View(room_Usage);
        }

        // POST: Room_Usage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Room_Id,Gest_ID,Isactive,Date")] Room_Usage room_Usage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room_Usage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(room_Usage);
        }





        
        [HttpPost]
     
        //public JsonResult Rooms(string Type)
        //{
        //    if (!string.IsNullOrEmpty(Type))
        //    {
        //        List<Room> rooms = db.Rooms.ToList().Where(x => x.Room_Type == Type).ToList();
        //        return Json(new { Rooms= rooms });
        //    }
        //    return null;
        //}






        // GET: Room_Usage/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Usage room_Usage = await db.Room_Usage.FindAsync(id);
            if (room_Usage == null)
            {
                return HttpNotFound();
            }
            return View(room_Usage);
        }

        // POST: Room_Usage/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Room_Usage room_Usage = await db.Room_Usage.FindAsync(id);
            db.Room_Usage.Remove(room_Usage);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
