using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace GarageWeb
{
    public static class Common
    {


        public enum vType
        {
            Car,
            Mc,
            Bus,
            Truck
        }

        public struct VehicleInfo
	        {
		        public bool isvalid;
                public string persnr;
                public vType vehicletype;

	        }

        public static DateTime CurrentDate()
        {
            DateTime parsedDate;


            DateTime.TryParseExact(DateTime.Now.ToLocalTime().ToString("yy-MM-dd HH-mm-ss"), "yy-MM-dd HH-mm-ss", null, DateTimeStyles.None, out parsedDate);

            return parsedDate;

        }


        //public VehicleInfo GatherInfo(string regnr)
        //{
        //    Random rand = new Random();

        //    VehicleInfo vh = new VehicleInfo();

        //    //Generate person number
        //    vh.persnr = 9 - rand.Next(0, 4) + rand.Next(0, 7) + rand.Next(1, 12) + rand.Next(1, 29) + "-" + rand.Next(1000, 9999);

        //    switch (rand.Next(0, 3))
        //    {
        //        default:
        //            break;
        //    }


        //}


    }
}