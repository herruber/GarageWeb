namespace GarageWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Regnr = c.String(nullable: false, maxLength: 128),
                        Persnr = c.String(),
                        ParkDate = c.DateTime(nullable: false),
                        VehicleType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Regnr);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}
