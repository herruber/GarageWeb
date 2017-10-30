using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GarageWeb.DataAccess
{
    public class GarageContext : DbContext
    {

        public DbSet<Models.Vehicle> Vehicles { get; set; }


        public GarageContext() : base()
        {

        }

    }
}