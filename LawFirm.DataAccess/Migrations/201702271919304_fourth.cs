namespace LawFirm.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Likes", "PublicationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Likes", "PublicationId", c => c.Int(nullable: false));
        }
    }
}
