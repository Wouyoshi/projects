namespace MakingChoises.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Routes", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Routes", "Genre_Id");
            AddForeignKey("dbo.Routes", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routes", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Routes", new[] { "Genre_Id" });
            DropColumn("dbo.Routes", "Genre_Id");
            DropTable("dbo.Genres");
        }
    }
}
