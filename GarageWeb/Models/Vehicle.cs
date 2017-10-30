using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data;
using System.Globalization;

namespace GarageWeb.Models
{
    public class Vehicle
    {


        [Key]
        public string Regnr { get; set; }
        public string Persnr {get; set; }

        public DateTime ParkDate { get; set; }


        public Common.vType VehicleType { get; set; }

        public Vehicle(string regnr, string persnr, Common.vType vehicletype)
        {
            ParkDate = Common.CurrentDate();
            
            Regnr = regnr;
            Persnr = persnr;
            VehicleType = vehicletype;
        }

        public Vehicle()
        {

        }
    }
}