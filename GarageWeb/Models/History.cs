using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace GarageWeb.Models
{
    public class History
    {
        [Key]
        public int id { get; set; }

        public string Regnr { get; set; }
        public string Persnr { get; set; }

        public DateTime ParkDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public double Price { get; set; }


        public Common.vType VehicleType { get; set; }

        public History(string regnr, string persnr, Common.vType vehicletype, DateTime parkDate, DateTime checkOutDate, double price)
        {
            ParkDate = parkDate;
            Regnr = regnr;
            Persnr = persnr;
            VehicleType = vehicletype;
            CheckOutDate = checkOutDate;
            Price = price;

        }

        public History()
        {

        }

    }
}