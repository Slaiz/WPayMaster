namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModel6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Sum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Sum");
        }
    }
}
