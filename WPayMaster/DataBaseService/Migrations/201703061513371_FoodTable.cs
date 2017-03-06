namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "IdUser");
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        FoodName = c.String(),
                        FoodType = c.String(),
                        FoodPrice = c.Int(nullable: false),
                        CookTime = c.Int(nullable: false),
                        FoodWeight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId);
            
            AddColumn("dbo.Users", "UserId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Users", "UserName", c => c.String());
            AddColumn("dbo.Users", "Surname", c => c.String());
            AddColumn("dbo.Users", "PassportNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Salary", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "WorkingTime", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "UserId");
            DropColumn("dbo.Users", "NameUser");
            DropColumn("dbo.Users", "SurnameUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "SurnameUser", c => c.String());
            AddColumn("dbo.Users", "NameUser", c => c.String());
            AddColumn("dbo.Users", "IdUser", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Users");
            DropColumn("dbo.Users", "WorkingTime");
            DropColumn("dbo.Users", "Salary");
            DropColumn("dbo.Users", "PassportNumber");
            DropColumn("dbo.Users", "Surname");
            DropColumn("dbo.Users", "UserName");
            DropColumn("dbo.Users", "UserId");
            DropTable("dbo.Foods");
            AddPrimaryKey("dbo.Users", "IdUser");
        }
    }
}
