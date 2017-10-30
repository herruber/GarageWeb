using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace GarageWeb.Models
{
    public class Vehicle
    {


        [Key]
        public string Regnr { get; set; }
        public string Persnr {get; set; }
        public DateTime ParkDate {get; set;}
        
        public enum vType
	        {
	         Car,
            Motorcycle,
            Bus,
            Truck
	        };

        public vType VehicleType { get; set; }

    }
}