namespace Philosophers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Philosophers", "FirstName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Philosophers", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Philosophers", "Area", c => c.String(nullable: false));
            AlterColumn("dbo.Philosophers", "Nationality", c => c.String(nullable: false));
            AlterColumn("dbo.Philosophers", "Description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Philosophers", "Description", c => c.String());
            AlterColumn("dbo.Philosophers", "Nationality", c => c.String());
            AlterColumn("dbo.Philosophers", "Area", c => c.String());
            AlterColumn("dbo.Philosophers", "LastName", c => c.String());
            AlterColumn("dbo.Philosophers", "FirstName", c => c.String());
        }
    }
}
