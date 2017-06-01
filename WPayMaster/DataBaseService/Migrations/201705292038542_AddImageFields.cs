namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drinks", "Image", c => c.Binary());
            AddColumn("dbo.Foods", "Image", c => c.Binary());
            AddColumn("dbo.Modificators", "Image", c => c.Binary());
            AddColumn("dbo.Users", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Image");
            DropColumn("dbo.Modificators", "Image");
            DropColumn("dbo.Foods", "Image");
            DropColumn("dbo.Drinks", "Image");
        }
    }
}
