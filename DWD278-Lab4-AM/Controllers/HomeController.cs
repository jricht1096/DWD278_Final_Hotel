using DWD278_Final_Hotel_Rooms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;


namespace DWD278_Final_Hotel_Rooms.Controllers
{
    public class HomeController : Controller
    {
        private RoomContext db = new RoomContext();
        public ActionResult Index()
        {
            var openRooms = db.Rooms
                .Include(t => t.Number)
                .Include(t => t.State)
                .Include(t => t.ReservationStatus)
                .Where(x => x.ReservationStatusID == 1)
                .ToList();

            var closedRooms = db.Rooms
               .Include(t => t.Number)
               .Include(t => t.State)
               .Include(t => t.ReservationStatus)
               .Where(x => x.ReservationStatusID == 2)
               .ToList();

           var viewModel = new RoomListViewModel
            {
                openRooms = openRooms,
                   closedRooms = closedRooms
               };
                return View(viewModel);
        }

        
    }
}