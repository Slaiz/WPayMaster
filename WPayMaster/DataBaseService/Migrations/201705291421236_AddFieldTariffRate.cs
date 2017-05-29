namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldTariffRate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "TariffRate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "TariffRate");
        }
    }
}
