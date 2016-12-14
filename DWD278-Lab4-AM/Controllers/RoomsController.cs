using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DWD278_Final_Hotel_Rooms.Models;

namespace DWD278_Final_Hotel_Rooms.Controllers
{
    public class RoomsController : Controller
    {
        private RoomContext db = new RoomContext();

        
        public ActionResult Index()
        {
            var rooms = db.Rooms.Include(t => t.Number).Include(t => t.State).Include(t => t.ReservationStatus);
            return View(rooms.ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

       
        public ActionResult Create()
        {
            ViewBag.NumberID = new SelectList(db.Number, "ID", "Description");
            ViewBag.StateID = new SelectList(db.States, "ID", "Description");
            ViewBag.ReservationStatusID = new SelectList(db.ReservationStatus, "ID", "Description");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Size,Description,NumberID,StateID,ReservationStatusID")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NumberID = new SelectList(db.Number, "ID", "Description", room.NumberID);
            ViewBag.StateID = new SelectList(db.States, "ID", "Description", room.StateID);
            ViewBag.ReservationStatusID = new SelectList(db.ReservationStatus, "ID", "Description", room.ReservationStatusID);
            return View(room);
        }

      
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.NumberID = new SelectList(db.Number, "ID", "Description", room.NumberID);
            ViewBag.StateID = new SelectList(db.States, "ID", "Description", room.StateID);
            ViewBag.ReservationStatusID = new SelectList(db.ReservationStatus, "ID", "Description", room.ReservationStatusID);
            return View(room);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Size,Description,NumberID,StateID,ReservationStatusID")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NumberID = new SelectList(db.Number, "ID", "Description", room.NumberID);
            ViewBag.StateID = new SelectList(db.States, "ID", "Description", room.StateID);
            ViewBag.ReservationStatusID = new SelectList(db.ReservationStatus, "ID", "Description", room.ReservationStatusID);
            return View(room);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
            db.SaveChanges();
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
