using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DWD278_Final_Hotel_Rooms.Models
{
    public class RoomContext : DbContext
    {
        public RoomContext() : base("RoomContext")
        {

        }

        public DbSet<Number> Number { get; set;}
        public DbSet<State> States { get; set; }
        public DbSet<ReservationStatus> ReservationStatus { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}