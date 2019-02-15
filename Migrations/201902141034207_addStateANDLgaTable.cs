namespace NoOperation_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStateANDLgaTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LGAs",
                c => new
                    {
                        LGAId = c.Int(nullable: false, identity: true),
                        LGAName = c.String(),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LGAId)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
            AddColumn("dbo.Employees", "StateId", c => c.Int());
            AddColumn("dbo.Employees", "LGAId", c => c.Int());
            AddColumn("dbo.Employees", "CreatedDate", c => c.DateTime());
            CreateIndex("dbo.Employees", "StateId");
            CreateIndex("dbo.Employees", "LGAId");
            AddForeignKey("dbo.Employees", "StateId", "dbo.States", "StateId");
            AddForeignKey("dbo.Employees", "LGAId", "dbo.LGAs", "LGAId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "LGAId", "dbo.LGAs");
            DropForeignKey("dbo.LGAs", "StateId", "dbo.States");
            DropForeignKey("dbo.Employees", "StateId", "dbo.States");
            DropIndex("dbo.LGAs", new[] { "StateId" });
            DropIndex("dbo.Employees", new[] { "LGAId" });
            DropIndex("dbo.Employees", new[] { "StateId" });
            DropColumn("dbo.Employees", "CreatedDate");
            DropColumn("dbo.Employees", "LGAId");
            DropColumn("dbo.Employees", "StateId");
            DropTable("dbo.States");
            DropTable("dbo.LGAs");
        }
    }
}
