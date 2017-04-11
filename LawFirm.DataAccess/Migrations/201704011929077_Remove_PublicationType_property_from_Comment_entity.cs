namespace LawFirm.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_PublicationType_property_from_Comment_entity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Type", c => c.Int(nullable: false));
        }
    }
}
