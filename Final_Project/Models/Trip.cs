using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Final_Project.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [ForeignKey("Truck")]
        public int TruckID { get; set; }
        public virtual Truck Truck { get; set; }


        [ForeignKey("Driver")]
        public int DriverID { get; set;}
        public virtual Driver Driver { get; set; }

        [ForeignKey("Destination")]
        public int DestinationId { get; set; }
        public virtual Destination Destination { get; set; }
    }

    public class TripDto
    {
        public int TripId { get; set; }

        public string TruckNumber { get; set; }

        public string DriverName { get; set; }

        public string DestinationName { get; set; }
    }
}