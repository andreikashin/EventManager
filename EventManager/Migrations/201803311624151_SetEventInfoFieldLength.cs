namespace EventManager.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SetEventInfoFieldLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Info", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Info", c => c.String());
        }
    }
}
