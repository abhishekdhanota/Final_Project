namespace Final_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class driver : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverID = c.Int(nullable: false, identity: true),
                        DriverName = c.String(),
                    })
                .PrimaryKey(t => t.DriverID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drivers");
        }
    }
}
