namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificatorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        DrinkId = c.Int(nullable: false, identity: true),
                        DrinkName = c.String(nullable: false, maxLength: 50),
                        DrinkType = c.String(nullable: false, maxLength: 50),
                        DrinkPrice = c.Int(nullable: false),
                        Volume = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DrinkId);
            
            CreateTable(
                "dbo.Modificators",
                c => new
                    {
                        ModificatorId = c.Int(nullable: false, identity: true),
                        ModificatorName = c.String(nullable: false, maxLength: 50),
                        ModificatorType = c.String(nullable: false, maxLength: 50),
                        ModificatorPrice = c.Int(nullable: false),
                        ModificatorWeight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModificatorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Modificators");
            DropTable("dbo.Drinks");
        }
    }
}
