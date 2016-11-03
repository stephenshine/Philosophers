namespace Philosophers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nationalities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        NationalityID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.NationalityID);
            
            AddColumn("dbo.Philosophers", "NationalityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Philosophers", "NationalityID");
            AddForeignKey("dbo.Philosophers", "NationalityID", "dbo.Nationalities", "NationalityID", cascadeDelete: true);
            DropColumn("dbo.Philosophers", "Nationality");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Philosophers", "Nationality", c => c.String(nullable: false));
            DropForeignKey("dbo.Philosophers", "NationalityID", "dbo.Nationalities");
            DropIndex("dbo.Philosophers", new[] { "NationalityID" });
            DropColumn("dbo.Philosophers", "NationalityID");
            DropTable("dbo.Nationalities");
        }
    }
}
