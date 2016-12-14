using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWD278_Final_Hotel_Rooms.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public int NumberID { get; set; }
        public int StateID { get; set; }
        public int ReservationStatusID { get; set; }

        [ForeignKey("NumberID")]
        public virtual Number Number { get; set; }

        [ForeignKey("StateID")]
        public virtual State State { get; set; }

        [ForeignKey("ReservationStatusID")]
        public virtual ReservationStatus ReservationStatus { get; set; }

    }
}