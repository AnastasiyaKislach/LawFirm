namespace LawFirm.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Publication_Type : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Likes", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Likes", "Type", c => c.Int(nullable: false));
        }
    }
}
