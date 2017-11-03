using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Diagnostics;

namespace GarageWeb
{
    public static class Common
    {
        public static int ParkSpace = 3;
        public static double PricePerMin = 5;

        public static int PrevCase = 0; //Keeps track of the previous filtering method

        public enum searchMode
        {
            Regnr,
            Persnr,
            ParkDate,
            VehicleType
        }

        public enum vType
        {
            
            Car,
            Mc,
            Bus,
            Truck,
            none
        }

        public struct VehicleInfo
	        {
		        public bool isvalid;
                public string persnr;
                public vType vehicletype;
                public string regnr;
                public DateTime parkdate;

	        }

        public struct SearchResult
        {
            public bool exactMatch;
            public IEnumerable<Models.Vehicle> vehicles;
        }

        public static DateTime CurrentDate()
        {
            DateTime parsedDate;


            DateTime.TryParseExact(DateTime.Now.ToLocalTime().ToString("yy-MM-dd HH-mm-ss"), "yy-MM-dd HH-mm-ss", null, DateTimeStyles.None, out parsedDate);

            return parsedDate;

        }


        public static VehicleInfo GatherInfo(string _regnr)
        {
            Random rand = new Random();

            VehicleInfo vh = new VehicleInfo();

            //Generate person number
            
            string year = (DateTime.Now.Year - rand.Next(18, 120)).ToString();
            string month = CalcDayMonth(rand.Next(1, 12));
            string day = CalcDayMonth(rand.Next(1, 31));
            string last4 = rand.Next(0,9) +"" + rand.Next(0, 9) + "" + rand.Next(0, 9) + "" + rand.Next(0, 9);



            vh.persnr = year + month + day + "-" + last4;

            vh.isvalid = true;

            switch (rand.Next(0, 4))
            {
                case 0:
                    vh.vehicletype = vType.Car;
                    break;
                case 1:
                    vh.vehicletype = vType.Bus;
                    break;
                case 2:
                    vh.vehicletype = vType.Truck;
                    break;
                case 3:
                    vh.vehicletype = vType.Mc;
                    break;
                default:
                    vh.isvalid = false;
                    break;
            }
            
            vh.regnr = _regnr;
            vh.parkdate = CurrentDate();

            return vh;

        }

        public static void Timer(int ms)
        {

            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (sw.ElapsedMilliseconds < ms)
            {


            }
        }

        public static string CalcDayMonth(int month)
        {
            string ret = "";
            if (month < 10)
            {
                ret = 0 + "" + month;
            }
            else
            {
                ret = month.ToString();
            }

            return ret;
        }

        public static int FreeLots(int count)
        {
            return ParkSpace - count;
        }

        public static double CalcPrice(Models.Vehicle vehicle)
        {
            return DateTime.Now.Subtract(vehicle.ParkDate).TotalMinutes * PricePerMin;
        }



    }
}