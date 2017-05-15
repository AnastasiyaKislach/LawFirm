namespace LawFirm.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Testimonial_Property_Name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Testimonials", "IsApproved", c => c.Boolean(nullable: false));
            DropColumn("dbo.Testimonials", "IsApprove");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Testimonials", "IsApprove", c => c.Boolean(nullable: false));
            DropColumn("dbo.Testimonials", "IsApproved");
        }
    }
}
