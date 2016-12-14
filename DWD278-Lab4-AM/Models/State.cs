using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DWD278_Final_Hotel_Rooms.Models
{
    public class State
    {
        public int ID { get; set; }

        [DisplayName("State")]
        public string Description { get; set; }
    }
}