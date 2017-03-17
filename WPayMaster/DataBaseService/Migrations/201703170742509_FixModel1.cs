namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Histories", "ActionName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Users", "WorkingTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "WorkingTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Histories", "ActionName", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
