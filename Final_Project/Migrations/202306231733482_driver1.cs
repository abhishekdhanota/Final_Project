namespace Final_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class driver1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TruckDrivers", "Truck_TruckID", "dbo.Trucks");
            DropForeignKey("dbo.TruckDrivers", "Driver_DriverID", "dbo.Drivers");
            DropIndex("dbo.TruckDrivers", new[] { "Truck_TruckID" });
            DropIndex("dbo.TruckDrivers", new[] { "Driver_DriverID" });
            DropTable("dbo.TruckDrivers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TruckDrivers",
                c => new
                    {
                        Truck_TruckID = c.Int(nullable: false),
                        Driver_DriverID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Truck_TruckID, t.Driver_DriverID });
            
            CreateIndex("dbo.TruckDrivers", "Driver_DriverID");
            CreateIndex("dbo.TruckDrivers", "Truck_TruckID");
            AddForeignKey("dbo.TruckDrivers", "Driver_DriverID", "dbo.Drivers", "DriverID", cascadeDelete: true);
            AddForeignKey("dbo.TruckDrivers", "Truck_TruckID", "dbo.Trucks", "TruckID", cascadeDelete: true);
        }
    }
}
