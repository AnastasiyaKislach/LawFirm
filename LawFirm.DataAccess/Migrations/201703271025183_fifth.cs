namespace LawFirm.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ParentCommentId", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "Level", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "LinkedCommentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "LinkedCommentId", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "Level");
            DropColumn("dbo.Comments", "ParentCommentId");
        }
    }
}
