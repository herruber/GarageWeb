using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageWeb.DataAccess
{
    public class Repository
    {

        GarageContext gC = new GarageContext();
        

        public IEnumerable<Models.Vehicle> GetStock()
        {
           
            var tempStock = gC.Vehicles;
            return tempStock;
        }

        public void Updatedb()
        {
            gC.SaveChanges();

        }

        public void CheckOut(string input) //Regnr or personnr
        {
            var tempVehicle = gC.Vehicles.FirstOrDefault(e => e.Regnr.ToLower().Contains(input.ToLower()));

            gC.Vehicles.Remove(tempVehicle);


        }

        public void AddVehicle(Models.Vehicle vehicle)
        {
            gC.Vehicles.Add(vehicle);
        }


    }
}