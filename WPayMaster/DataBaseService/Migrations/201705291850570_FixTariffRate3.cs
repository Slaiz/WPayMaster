namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTariffRate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "TariffRate", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "TariffRate");
        }
    }
}
