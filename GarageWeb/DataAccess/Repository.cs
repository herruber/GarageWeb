using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageWeb.DataAccess
{
    public class Repository
    {

        GarageContext gC = new GarageContext();
        

        public IEnumerable<Models.Vehicle> RerouteSearch(string term) //Entry point for search
        {
            if (term != null && term != "")
            {
                return RegHandler(term).ToList();
            }
            else
            {
                return GetStock().ToList();
            }
        }

        public IEnumerable<Models.Vehicle> GetStock() //Used to display stock
        {

            return gC.Vehicles;
        }

        public IEnumerable<Models.Vehicle> RegHandler(string term) //Used with searchterm
        {
            IEnumerable<Models.Vehicle> tempStock = new List<Models.Vehicle>();

            if (term.Trim() != null && term.Trim() != "") //If searchterm is not empty
            {

                tempStock = gC.Vehicles.Where(e => e.Regnr.ToLower().Equals(term.ToLower())); //IF regnr or persnr was a match

            }
            else
            {
                tempStock = gC.Vehicles;
            }

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