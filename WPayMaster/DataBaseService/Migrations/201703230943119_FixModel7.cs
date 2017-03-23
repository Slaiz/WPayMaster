namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModel7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CashierName", c => c.String());
            AlterColumn("dbo.Users", "WorkingTime", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "WorkingTime", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.Orders", "CashierName");
        }
    }
}
