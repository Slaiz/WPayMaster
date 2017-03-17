namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "WorkingTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "WorkingTime");
        }
    }
}
