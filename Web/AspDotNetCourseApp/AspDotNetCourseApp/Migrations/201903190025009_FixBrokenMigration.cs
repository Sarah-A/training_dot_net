namespace AspDotNetCourseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixBrokenMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Birthdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
        }
    }
}
