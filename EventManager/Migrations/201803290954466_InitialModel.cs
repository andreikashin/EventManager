namespace EventManager.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        //ParticipantId = c.Int(nullable: false),
                        LegalName = c.String(),
                        RegistryNumber = c.Int(nullable: false),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Participants", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCompany = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        //LocationId = c.Int(nullable: false),
                        Name = c.String(),
                        DateTime = c.DateTimeOffset(nullable: false, precision: 7),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Participations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        //ParticipantId = c.Int(nullable: false),
                        //EventId = c.Int(nullable: false),
                        GuestCount = c.Int(nullable: false),
                        PaymentType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Participants", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        //ParticipantId = c.Int(nullable: false),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        PersonalCode = c.Int(nullable: false),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Participants", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.People", "ParticipantId", "dbo.Participants");
            //DropForeignKey("dbo.Participations", "ParticipantId", "dbo.Participants");
            //DropForeignKey("dbo.Participations", "EventId", "dbo.Events");
            //DropForeignKey("dbo.Events", "LocationId", "dbo.Locations");
            //DropForeignKey("dbo.Companies", "ParticipantId", "dbo.Participants");
            //DropIndex("dbo.People", new[] { "ParticipantId" });
            //DropIndex("dbo.Participations", new[] { "EventId" });
            //DropIndex("dbo.Participations", new[] { "ParticipantId" });
            //DropIndex("dbo.Events", new[] { "LocationId" });
            //DropIndex("dbo.Companies", new[] { "ParticipantId" });
            DropTable("dbo.People");
            DropTable("dbo.Participations");
            DropTable("dbo.Locations");
            DropTable("dbo.Events");
            DropTable("dbo.Participants");
            DropTable("dbo.Companies");
        }
    }
}
