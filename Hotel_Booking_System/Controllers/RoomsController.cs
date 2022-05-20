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
using System.Net.Http;
using Newtonsoft.Json;

namespace Hotel_Booking_System.Controllers
{
    public class RoomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rooms
        HttpClient httpClient = new HttpClient();
        public ActionResult SingleRoom()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("https://localhost:44311/api/Rooms").Result;
            String message=  httpResponseMessage.Content.ReadAsStringAsync().Result;
            
            List<Room> room = JsonConvert.DeserializeObject<List<Room>>(message).Where(x=>x.Room_type=="single").ToList();
           
            return View(room);
        }
        public ActionResult DoubleRoom()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("https://localhost:44311/api/Rooms").Result;
            String message = httpResponseMessage.Content.ReadAsStringAsync().Result;

            List<Room> room = JsonConvert.DeserializeObject<List<Room>>(message).Where(x => x.Room_type == "double").ToList();
           
            return View(room);
        }
        public ActionResult SuiteRoom()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("https://localhost:44311/api/Rooms").Result;
            String message = httpResponseMessage.Content.ReadAsStringAsync().Result;

            List<Room> room = JsonConvert.DeserializeObject<List<Room>>(message).Where(x => x.Room_type == "suite").ToList();

            return View(room);
        }

        // GET: Rooms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = await db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms/Create
        [Authorize(Roles ="Administrator")]
        public ActionResult Create()
        {
            return View(new Room());
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Create([Bind(Include = "Room_Name,Room_Loca,Room_Type")] Room room)
        {
            //if(room!=null)
            //{
            //    room.Isactive = true;
            //    room.Date = DateTime.Now;
            //}
            //if (ModelState.IsValid)
            //{
            //    db.Rooms.Add(room);
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}

            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = await db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Room_Id,Room_Name,Room_Loca,Room_Type,Isactive,Date")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(room);
        }

        // GET: Rooms/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = await db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Room room = await db.Rooms.FindAsync(id);
            db.Rooms.Remove(room);
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
