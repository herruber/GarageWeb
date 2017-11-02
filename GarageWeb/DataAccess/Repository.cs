using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageWeb.DataAccess
{
    public static class Repository
    {

        static GarageContext gC = new GarageContext();
        static bool[] Ordering = new bool[] {false, false, false, false };

        //Helper method to order the result
        public static IEnumerable<Models.Vehicle> OrderCollection(IEnumerable<Models.Vehicle> vehiclelist, int order)
        {
            Ordering[order] = !Ordering[order]; //Invert the bool
            //IEnumerable<Models.Vehicle> retGarage;

            switch (order)
            {
                case 1: //regnr
                    if (Ordering[order])
                    {
                        vehiclelist = vehiclelist.OrderByDescending(e => e.Regnr);

                    }
                    else
                    {
                        vehiclelist = vehiclelist.OrderBy(e => e.Regnr);
                    }

                    break;
                case 2:
                    if (Ordering[order])
                    {
                        vehiclelist = vehiclelist.OrderByDescending(e => e.Persnr);

                    }
                    else
                    {
                        vehiclelist = vehiclelist.OrderBy(e => e.Persnr);
                    }

                    break;
                case 3:
                    if (Ordering[order])
                    {
                        vehiclelist = vehiclelist.OrderByDescending(e => e.ParkDate);

                    }
                    else
                    {
                        vehiclelist = vehiclelist.OrderBy(e => e.ParkDate);
                    }

                    break;
            }


            return vehiclelist;
        }

        public static Common.SearchResult GetStock(int filtering, int option) //Used to display stock
        {
            switch (option)
            {
                case 0:
                    gC.Vehicles.fi
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }

            Common.SearchResult result = new Common.SearchResult();
            result.vehicles = OrderCollection(filtering);

            return result;
        }

        public static Models.Vehicle RegHandler(string term) //Used with searchterm
        {
            // IEnumerable<Models.Vehicle> tempStock = new List<Models.Vehicle>();

            var tempVehicle = gC.Vehicles.FirstOrDefault(e => e.Regnr.ToLower().Equals(term.ToLower())); //IF regnr or persnr was a match

            if (tempVehicle == null)
            {
                return null;
            }
            else
            {
                return tempVehicle;
            }
         
        }

        public static void Updatedb()
        {
            gC.SaveChanges();

        }

        public static bool CheckOut(IEnumerable<Models.Vehicle> input)
        {
            try
            {
                foreach (var item in input)
                {

                    gC.Vehicles.Remove(item);
                    gC.SaveChanges();

                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static IEnumerable<Models.Vehicle> GetFromRegnr(string[] regnr)
        {
            List<Models.Vehicle> retVehicles = new List<Models.Vehicle>();

            foreach (var item in regnr)
            {
                retVehicles.Add(gC.Vehicles.FirstOrDefault(e => e.Regnr == item));
            }

            return retVehicles;
        }

        public static bool CheckOut(string[] input) //Regnr
        {
            try
            {
                foreach (var item in input)
                {
                    var tempVehicle = gC.Vehicles.FirstOrDefault(e => e.Regnr.ToLower().Contains(item.ToLower()));

                    gC.Vehicles.Remove(tempVehicle);
                    gC.SaveChanges();
                    
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static void AddVehicle(Models.Vehicle vehicle)
        {
            gC.Vehicles.Add(vehicle);
            gC.SaveChanges();
        }

        public static void AddVehicle(Common.vType vtype, string regnr, string persnr, DateTime parkdate)
        {
            Models.Vehicle vehicle = new Models.Vehicle();
            vehicle.ParkDate = parkdate;
            vehicle.Persnr = persnr;
            vehicle.Regnr = regnr.ToUpper();
            vehicle.VehicleType = vtype;

            gC.Vehicles.Add(vehicle);
            gC.SaveChanges();
        }


    }
}