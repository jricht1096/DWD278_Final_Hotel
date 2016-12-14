using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DWD278_Final_Hotel_Rooms.Models
{
    public class RoomListViewModel
    {
       public List<Room> openRooms { get; set; }
       public List<Room> closedRooms { get; set; }
    }
}