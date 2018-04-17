namespace EventManager.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SetLengthOfInfoField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Info", c => c.String(maxLength: 1500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Info", c => c.String());
        }
    }
}
