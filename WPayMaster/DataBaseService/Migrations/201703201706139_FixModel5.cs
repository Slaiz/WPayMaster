namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModel5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ItemName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ItemName");
        }
    }
}
