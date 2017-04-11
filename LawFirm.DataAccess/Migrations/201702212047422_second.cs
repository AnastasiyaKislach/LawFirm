namespace LawFirm.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "ApplicationUserId", c => c.String());
            AlterColumn("dbo.Likes", "ApplicationUserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Likes", "ApplicationUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "ApplicationUserId", c => c.Int(nullable: false));
        }
    }
}
