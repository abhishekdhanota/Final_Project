namespace Final_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trip : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        TruckID = c.Int(nullable: false),
                        DriverID = c.Int(nullable: false),
                        DestinationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TripId)
                .ForeignKey("dbo.Destinations", t => t.DestinationId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverID, cascadeDelete: true)
                .ForeignKey("dbo.Trucks", t => t.TruckID, cascadeDelete: true)
                .Index(t => t.TruckID)
                .Index(t => t.DriverID)
                .Index(t => t.DestinationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "TruckID", "dbo.Trucks");
            DropForeignKey("dbo.Trips", "DriverID", "dbo.Drivers");
            DropForeignKey("dbo.Trips", "DestinationId", "dbo.Destinations");
            DropIndex("dbo.Trips", new[] { "DestinationId" });
            DropIndex("dbo.Trips", new[] { "DriverID" });
            DropIndex("dbo.Trips", new[] { "TruckID" });
            DropTable("dbo.Trips");
        }
    }
}
