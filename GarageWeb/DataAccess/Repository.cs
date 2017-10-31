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

            var tempStock = gC.Vehicles.Where(e => e.Regnr.ToLower().Equals(term.ToLower())); //IF regnr or persnr was a match

            if (tempStock.Count() == 0)
            {
                return null;
            }
            else
            {
                return tempStock.ElementAt(0);
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


        }

        public void AddVehicle(Models.Vehicle vehicle)
        {
            gC.Vehicles.Add(vehicle);
        }


    }
}