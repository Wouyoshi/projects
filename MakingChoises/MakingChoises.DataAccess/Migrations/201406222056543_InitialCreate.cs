namespace MakingChoises.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Route_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Routes", t => t.Route_Id)
                .Index(t => t.Route_Id);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Text = c.String(),
                        Problem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Problems", t => t.Problem_Id)
                .Index(t => t.Problem_Id);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        NextProblem_Id = c.Int(nullable: false),
                        Option_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Problems", t => t.NextProblem_Id, cascadeDelete: true)
                .ForeignKey("dbo.Options", t => t.Option_Id)
                .Index(t => t.NextProblem_Id)
                .Index(t => t.Option_Id);
            
            CreateTable(
                "dbo.Problems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Step_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Steps", t => t.Step_Id)
                .Index(t => t.Step_Id);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        NextStep_Id = c.Int(),
                        Story_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Steps", t => t.NextStep_Id)
                .ForeignKey("dbo.Stories", t => t.Story_Id)
                .Index(t => t.NextStep_Id)
                .Index(t => t.Story_Id);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Steps", "Story_Id", "dbo.Stories");
            DropForeignKey("dbo.Problems", "Step_Id", "dbo.Steps");
            DropForeignKey("dbo.Steps", "NextStep_Id", "dbo.Steps");
            DropForeignKey("dbo.Routes", "Option_Id", "dbo.Options");
            DropForeignKey("dbo.Routes", "NextProblem_Id", "dbo.Problems");
            DropForeignKey("dbo.Options", "Problem_Id", "dbo.Problems");
            DropForeignKey("dbo.Conditions", "Route_Id", "dbo.Routes");
            DropIndex("dbo.Steps", new[] { "Story_Id" });
            DropIndex("dbo.Problems", new[] { "Step_Id" });
            DropIndex("dbo.Steps", new[] { "NextStep_Id" });
            DropIndex("dbo.Routes", new[] { "Option_Id" });
            DropIndex("dbo.Routes", new[] { "NextProblem_Id" });
            DropIndex("dbo.Options", new[] { "Problem_Id" });
            DropIndex("dbo.Conditions", new[] { "Route_Id" });
            DropTable("dbo.Stories");
            DropTable("dbo.Steps");
            DropTable("dbo.Problems");
            DropTable("dbo.Routes");
            DropTable("dbo.Options");
            DropTable("dbo.Conditions");
        }
    }
}
