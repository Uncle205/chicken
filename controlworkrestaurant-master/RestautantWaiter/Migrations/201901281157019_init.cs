namespace RestautantWaiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemCarts",
                c => new
                    {
                        Item_Id = c.Int(nullable: false),
                        Cart_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.Cart_Id })
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.Cart_Id, cascadeDelete: true)
                .Index(t => t.Item_Id)
                .Index(t => t.Cart_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemCarts", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.ItemCarts", "Item_Id", "dbo.Items");
            DropIndex("dbo.ItemCarts", new[] { "Cart_Id" });
            DropIndex("dbo.ItemCarts", new[] { "Item_Id" });
            DropTable("dbo.ItemCarts");
            DropTable("dbo.Users");
            DropTable("dbo.Tables");
            DropTable("dbo.Items");
            DropTable("dbo.Carts");
        }
    }
}
