namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTariffRate2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "TariffRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "TariffRate", c => c.Int(nullable: false));
        }
    }
}
