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
    public class NumbersController : Controller
    {
        private RoomContext db = new RoomContext();

       
        public ActionResult Index()
        {
            return View(db.Number.ToList());
        }

       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Number number = db.Number.Find(id);
            if (number == null)
            {
                return HttpNotFound();
            }
            return View(number);
        }

   
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description")] Number number)
        {
            if (ModelState.IsValid)
            {
                db.Number.Add(number);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(number);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Number number = db.Number.Find(id);
            if (number == null)
            {
                return HttpNotFound();
            }
            return View(number);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description")] Number number)
        {
            if (ModelState.IsValid)
            {
                db.Entry(number).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(number);
        }

   
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Number number = db.Number.Find(id);
            if (number == null)
            {
                return HttpNotFound();
            }
            return View(number);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Number number = db.Number.Find(id);
            db.Number.Remove(number);
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
