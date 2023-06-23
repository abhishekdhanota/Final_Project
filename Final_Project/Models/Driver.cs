using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Final_Project.Models
{
    public class Driver
    {

        [Key]
        public int DriverID { get; set; }
        public string DriverName { get; set; }
   
    }
    public class DriverDto
    {
        public int DriverID { get; set; }
        public string DriverName { get; set; }
    }
}