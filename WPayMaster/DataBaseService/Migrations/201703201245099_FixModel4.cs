namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModel4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ItemPrice", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "ItemPrice");
        }
    }
}
