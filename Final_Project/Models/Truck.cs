using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models
{
    public class Truck
    {
        [Key]
        public int TruckID { get; set; }
        public string TruckNumber { get; set; }
    }
    public class TruckDto
    {
        public int TruckID { get; set; }
        public string TruckNumber { get; set; }
    }
}
