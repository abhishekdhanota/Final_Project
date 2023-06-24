using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Final_Project.Models
{
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }
    }
    public class DestinationDto
    {
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }
    }
}