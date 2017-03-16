namespace DataBaseService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        HistoryId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Post = c.String(nullable: false, maxLength: 50),
                        ActionName = c.String(nullable: false, maxLength: 10),
                        DateAction = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HistoryId);
            
            AlterColumn("dbo.Users", "WorkingTime", c => c.Time(nullable: true, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "WorkingTime", c => c.Int(nullable: true));
            DropTable("dbo.Histories");
        }
    }
}
