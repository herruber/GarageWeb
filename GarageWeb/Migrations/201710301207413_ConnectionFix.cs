namespace GarageWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectionFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "ParkDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "ParkDate");
        }
    }
}
