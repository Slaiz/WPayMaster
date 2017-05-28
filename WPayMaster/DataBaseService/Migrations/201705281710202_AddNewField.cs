namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drinks", "Recipe", c => c.String(maxLength: 100));
            AddColumn("dbo.Orders", "CheckDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Sex", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Sex");
            DropColumn("dbo.Orders", "CheckDate");
            DropColumn("dbo.Drinks", "Recipe");
        }
    }
}
