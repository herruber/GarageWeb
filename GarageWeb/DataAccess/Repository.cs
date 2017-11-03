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

        public static IEnumerable<Models.Vehicle> GetStock(int filtering) //Used to display stock
        {

            return OrderCollection(gC.Vehicles, filtering); //Inputs the stock and filtering mode
        }

        public static Common.SearchResult Match(IEnumerable<Models.Vehicle> vehicles)
        {
            Common.SearchResult result = new Common.SearchResult();

            if (vehicles != null && vehicles.Count() == 1) //IF exact match
            {
                result.exactMatch = true;
            }
            else
            {
                result.exactMatch = false;
            }

            result.vehicles = vehicles.ToList();
            return result;
        }

        public static Common.SearchResult RegHandler(string term, int filtering, int option) //Used with searchterm
        {
            // IEnumerable<Models.Vehicle> tempStock = new List<Models.Vehicle>();


            //           < option value = "0" > Regnr </ option >

            //< option value = "1" > Persnr </ option >

            //      < option value = "3" > Vehicle Type </ option >

            IEnumerable<Models.Vehicle> temp;

            Common.SearchResult result = new Common.SearchResult();
            Common.vType searchVtype = Common.vType.none;
            switch (term.ToLower())
            {
                case "car":
                    searchVtype = Common.vType.Car;
                    break;
                case "mc":
                    searchVtype = Common.vType.Mc;
                    break;
                case "truck":
                    searchVtype = Common.vType.Truck;
                    break;
                case "bus":
                    searchVtype = Common.vType.Bus;
                    break;
                default:
                    break;
            }

            switch (option)
            {
                case 0:                    
                    temp = gC.Vehicles.Where(e => e.Regnr.ToUpper().Equals(term.ToUpper())); //Cast result to a collection
                    if (temp != null && temp.Count() == 1)
                    {
                        result.exactMatch = true;
                    }
                    else
                    {
                        temp = gC.Vehicles.Where(e => e.Regnr.ToUpper().Contains(term.ToUpper())).ToList();
                        result.exactMatch = false;                      
                    }
                    result.vehicles = temp;
                    break;
                case 1:
                    temp = gC.Vehicles.Where(e => e.Persnr.ToUpper().Equals(term.ToUpper())); //Cast result to a collection
                    if (temp != null && temp.Count() == 1)
                    {
                        result.exactMatch = true;
                    }
                    else
                    {
                        temp = gC.Vehicles.Where(e => e.Persnr.ToUpper().Contains(term.ToUpper())).ToList();
                        result.exactMatch = false;
                    }
                    result.vehicles = temp;
                    break;
                case 2:
                    temp = gC.Vehicles.Where(e => e.VehicleType == searchVtype).ToList(); //Cast result to a collection
                    result.exactMatch = true;
                    result.vehicles = temp;
                    break;
                default:
                    break;
            }


            return result;
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

                    Models.History historyVehicle = new Models.History(tempVehicle.Regnr, tempVehicle.Persnr, tempVehicle.VehicleType, tempVehicle.ParkDate, Common.CurrentDate(), Common.CalcPrice(tempVehicle));

                    gC.History.Add(historyVehicle);

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