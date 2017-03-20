namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModel3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ItemId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ItemType", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "ItemWeight", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "FoodId");
            DropColumn("dbo.Orders", "DrinkId");
            DropColumn("dbo.Orders", "ModificatorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ModificatorId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "DrinkId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "FoodId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "ItemWeight");
            DropColumn("dbo.Orders", "ItemType");
            DropColumn("dbo.Orders", "ItemId");
        }
    }
}
