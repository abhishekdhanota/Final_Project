namespace Final_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class truckdrivers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TruckDrivers",
                c => new
                    {
                        Truck_TruckID = c.Int(nullable: false),
                        Driver_DriverID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Truck_TruckID, t.Driver_DriverID })
                .ForeignKey("dbo.Trucks", t => t.Truck_TruckID, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.Driver_DriverID, cascadeDelete: true)
                .Index(t => t.Truck_TruckID)
                .Index(t => t.Driver_DriverID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TruckDrivers", "Driver_DriverID", "dbo.Drivers");
            DropForeignKey("dbo.TruckDrivers", "Truck_TruckID", "dbo.Trucks");
            DropIndex("dbo.TruckDrivers", new[] { "Driver_DriverID" });
            DropIndex("dbo.TruckDrivers", new[] { "Truck_TruckID" });
            DropTable("dbo.TruckDrivers");
        }
    }
}
