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
    public class ReservationStatusController : Controller
    {
        private RoomContext db = new RoomContext();

       
        public ActionResult Index()
        {
            return View(db.ReservationStatus.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationStatus reservationStatus = db.ReservationStatus.Find(id);
            if (reservationStatus == null)
            {
                return HttpNotFound();
            }
            return View(reservationStatus);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description")] ReservationStatus reservationStatus)
        {
            if (ModelState.IsValid)
            {
                db.ReservationStatus.Add(reservationStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reservationStatus);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationStatus reservationStatus = db.ReservationStatus.Find(id);
            if (reservationStatus == null)
            {
                return HttpNotFound();
            }
            return View(reservationStatus);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description")] ReservationStatus reservationStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservationStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservationStatus);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationStatus reservationStatus = db.ReservationStatus.Find(id);
            if (reservationStatus == null)
            {
                return HttpNotFound();
            }
            return View(reservationStatus);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservationStatus reservationStatus = db.ReservationStatus.Find(id);
            db.ReservationStatus.Remove(reservationStatus);
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
