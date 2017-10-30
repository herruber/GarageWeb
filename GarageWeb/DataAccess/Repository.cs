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
    }
}