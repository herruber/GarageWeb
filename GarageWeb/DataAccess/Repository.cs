using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageWeb.DataAccess
{
    public class Repository
    {

        GarageContext gC = new GarageContext();
        

        public IEnumerable<Models.Vehicle> GetStock() //Used to display stock
        {

            return gC.Vehicles;
        }

        public Models.Vehicle RegHandler(string term) //Used with searchterm
        {
            // IEnumerable<Models.Vehicle> tempStock = new List<Models.Vehicle>();

            var tempStock = gC.Vehicles.FirstOrDefault(e => e.Regnr.ToLower().Equals(term.ToLower())); //IF regnr or persnr was a match

            if (tempStock == null)
            {
                return null;
            }
            else
            {
                return tempStock;
            }
         
        }

        public void Updatedb()
        {
            gC.SaveChanges();

        }

        public void CheckOut(string input) //Regnr or personnr
        {
            var tempVehicle = gC.Vehicles.FirstOrDefault(e => e.Regnr.ToLower().Contains(input.ToLower()));

            gC.Vehicles.Remove(tempVehicle);
            gC.SaveChanges();

        }

        public void AddVehicle(Models.Vehicle vehicle)
        {
            gC.Vehicles.Add(vehicle);
            gC.SaveChanges();
        }

        public void AddVehicle(Common.vType vtype, string regnr, string persnr, DateTime parkdate)
        {
            Models.Vehicle vehicle = new Models.Vehicle();
            vehicle.ParkDate = parkdate;
            vehicle.Persnr = persnr;
            vehicle.Regnr = regnr;
            vehicle.VehicleType = vtype;

            gC.Vehicles.Add(vehicle);
            gC.SaveChanges();
        }


    }
}