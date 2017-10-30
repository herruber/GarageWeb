namespace GarageWeb.Migrations
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
  

    internal sealed class Configuration : DbMigrationsConfiguration<GarageWeb.DataAccess.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GarageWeb.DataAccess.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //DataTable dt = new DataTable();
            //dt.Columns[0].DataType = System.Type.GetType("System.String");
            //dt.Columns[1].DataType = System.Type.GetType("System.String");
            //dt.Columns[2].DataType = System.Type.GetType("System.DateTime");
            //dt.Columns[3].DataType = System.Type.GetType("System.Enum");

            context.Vehicles.AddOrUpdate(
                e => e.Regnr,
                new Models.Vehicle { Regnr = "abc-123", Persnr = "xx xx xx xxxx", ParkDate = Common.CurrentDate(), VehicleType = Common.vType.Bus }

                );
           
        }
    }
}
