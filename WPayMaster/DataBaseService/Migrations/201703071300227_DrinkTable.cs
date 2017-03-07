namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrinkTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "FoodName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Foods", "FoodType", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: true, maxLength: 50));
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: true, maxLength: 50));
            AlterColumn("dbo.Users", "Post", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Post", c => c.String());
            AlterColumn("dbo.Users", "Surname", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Foods", "FoodType", c => c.String());
            AlterColumn("dbo.Foods", "FoodName", c => c.String());
        }
    }
}
