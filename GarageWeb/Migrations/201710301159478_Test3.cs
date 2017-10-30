namespace GarageWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "ParkDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "ParkDate", c => c.DateTime(nullable: false));
        }
    }
}
