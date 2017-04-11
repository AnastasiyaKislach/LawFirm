namespace LawFirm.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_ParentCommentId_property_to_Nullable_type : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "ParentCommentId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "ParentCommentId", c => c.Int(nullable: false));
        }
    }
}
