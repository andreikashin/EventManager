namespace EventManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDurationToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "DurationInHours", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "DurationInHours");
        }
    }
}
