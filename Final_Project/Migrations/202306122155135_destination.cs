namespace Final_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class destination : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Destinations", "DestinationName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Destinations", "DestinationName", c => c.Int(nullable: false));
        }
    }
}
