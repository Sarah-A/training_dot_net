namespace AspDotNetCourseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "AddedToDb", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "AddedToDb", c => c.DateTime(nullable: false));
        }
    }
}
