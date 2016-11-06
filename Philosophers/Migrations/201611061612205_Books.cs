namespace Philosophers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Books : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        AreaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Areas", t => t.AreaID, cascadeDelete: true)
                .Index(t => t.AreaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "AreaID", "dbo.Areas");
            DropIndex("dbo.Books", new[] { "AreaID" });
            DropTable("dbo.Books");
        }
    }
}
