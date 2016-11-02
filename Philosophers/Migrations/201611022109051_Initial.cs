namespace Philosophers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Philosophers",
                c => new
                    {
                        PhilosopherID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateOfDeath = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Area = c.String(),
                        Nationality = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PhilosopherID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Philosophers");
        }
    }
}
