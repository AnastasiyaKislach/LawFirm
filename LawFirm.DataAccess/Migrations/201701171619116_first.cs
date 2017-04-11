namespace LawFirm.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogItems",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Text = c.String(),
                    ImagePath = c.String(),
                    CreationTime = c.DateTime(nullable: false),
                    IdCategory = c.Int(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                    Category_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Comments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Author = c.String(),
                    Text = c.String(),
                    CreationTime = c.DateTime(nullable: false),
                    IdLinkedComment = c.Int(nullable: false),
                    IdBlogItem = c.Int(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                    BlogItem_Id = c.Int(),
                    LinkedComment_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogItems", t => t.BlogItem_Id)
                .ForeignKey("dbo.Comments", t => t.LinkedComment_Id)
                .Index(t => t.BlogItem_Id)
                .Index(t => t.LinkedComment_Id);

            CreateTable(
                "dbo.Likes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    IdUser = c.Int(nullable: false),
                    IdPublication = c.Int(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                    Publication_Id = c.Int(),
                    Comment_Id = c.Int(),
                    Article_Id = c.Int(),
                    BlogItem_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publications", t => t.Publication_Id)
                .ForeignKey("dbo.Comments", t => t.Comment_Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .ForeignKey("dbo.BlogItems", t => t.BlogItem_Id)
                .Index(t => t.Publication_Id)
                .Index(t => t.Comment_Id)
                .Index(t => t.Article_Id)
                .Index(t => t.BlogItem_Id);

            CreateTable(
                "dbo.Publications",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TypeName = c.String(),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Consultations",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Email = c.String(),
                    Phone = c.String(),
                    MessageText = c.String(),
                    CreationTime = c.DateTime(nullable: false),
                    IdPracticeArea = c.Int(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                    Practice_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Practices", t => t.Practice_Id)
                .Index(t => t.Practice_Id);

            CreateTable(
                "dbo.Practices",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Text = c.String(),
                    ImagePath = c.String(),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Settings",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Key = c.String(),
                    Value = c.String(),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Sliders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Testimonials",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Author = c.String(),
                    Email = c.String(),
                    Text = c.String(),
                    CreationTime = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Consultations", "Practice_Id", "dbo.Practices");
            DropForeignKey("dbo.Likes", "BlogItem_Id", "dbo.BlogItems");
            DropForeignKey("dbo.Comments", "LinkedComment_Id", "dbo.Comments");
            DropForeignKey("dbo.Likes", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.Likes", "Publication_Id", "dbo.Publications");
            DropForeignKey("dbo.Comments", "BlogItem_Id", "dbo.BlogItems");
            DropForeignKey("dbo.BlogItems", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Consultations", new[] { "Practice_Id" });
            DropIndex("dbo.Likes", new[] { "BlogItem_Id" });
            DropIndex("dbo.Likes", new[] { "Comment_Id" });
            DropIndex("dbo.Likes", new[] { "Publication_Id" });
            DropIndex("dbo.Comments", new[] { "LinkedComment_Id" });
            DropIndex("dbo.Comments", new[] { "BlogItem_Id" });
            DropIndex("dbo.BlogItems", new[] { "Category_Id" });
            DropTable("dbo.Testimonials");
            DropTable("dbo.Sliders");
            DropTable("dbo.Settings");
            DropTable("dbo.Practices");
            DropTable("dbo.Consultations");
            DropTable("dbo.Publications");
            DropTable("dbo.Likes");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.BlogItems");
        }
    }
}
