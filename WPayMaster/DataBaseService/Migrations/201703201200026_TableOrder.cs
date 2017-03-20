namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CheckId = c.Int(nullable: false),
                        FoodId = c.Int(nullable: true),
                        DrinkId = c.Int(nullable: true),
                        ModificatorId = c.Int(nullable: true),
                        Count = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            DropColumn("dbo.Foods", "CookTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "CookTime", c => c.Int(nullable: false));
            DropTable("dbo.Orders");
        }
    }
}
