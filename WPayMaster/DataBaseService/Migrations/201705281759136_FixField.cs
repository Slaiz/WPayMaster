namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foods", "Recipe", c => c.String(maxLength: 100));
            DropColumn("dbo.Drinks", "Recipe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drinks", "Recipe", c => c.String(maxLength: 100));
            DropColumn("dbo.Foods", "Recipe");
        }
    }
}
