namespace LawFirm.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BlogItems", newName: "Articles");
            DropForeignKey("dbo.Likes", "Publication_Id", "dbo.Publications");
            DropIndex("dbo.Likes", new[] { "Publication_Id" });
            RenameColumn(table: "dbo.Comments", name: "BlogItem_Id", newName: "Article_Id");
            RenameColumn(table: "dbo.Likes", name: "BlogItem_Id", newName: "Article_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_BlogItem_Id", newName: "IX_Article_Id");
            RenameIndex(table: "dbo.Likes", name: "IX_BlogItem_Id", newName: "IX_Article_Id");
            AddColumn("dbo.Comments", "IdUser", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "IdArticle", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Likes", "IdArticle", c => c.Int(nullable: false));
            AddColumn("dbo.Likes", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Testimonials", "IsApprove", c => c.Boolean(nullable: false));
            DropColumn("dbo.Comments", "Author");
            DropColumn("dbo.Comments", "IdBlogItem");
            DropColumn("dbo.Likes", "IdPublication");
            DropColumn("dbo.Likes", "Publication_Id");
            DropTable("dbo.Publications");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Likes", "Publication_Id", c => c.Int());
            AddColumn("dbo.Likes", "IdPublication", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "IdBlogItem", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "Author", c => c.String());
            DropColumn("dbo.Testimonials", "IsApprove");
            DropColumn("dbo.Likes", "Type");
            DropColumn("dbo.Likes", "IdArticle");
            DropColumn("dbo.Comments", "Type");
            DropColumn("dbo.Comments", "IdArticle");
            DropColumn("dbo.Comments", "IdUser");
            RenameIndex(table: "dbo.Likes", name: "IX_Article_Id", newName: "IX_BlogItem_Id");
            RenameIndex(table: "dbo.Comments", name: "IX_Article_Id", newName: "IX_BlogItem_Id");
            RenameColumn(table: "dbo.Likes", name: "Article_Id", newName: "BlogItem_Id");
            RenameColumn(table: "dbo.Comments", name: "Article_Id", newName: "BlogItem_Id");
            CreateIndex("dbo.Likes", "Publication_Id");
            AddForeignKey("dbo.Likes", "Publication_Id", "dbo.Publications", "Id");
            RenameTable(name: "dbo.Articles", newName: "BlogItems");
        }
    }
}
