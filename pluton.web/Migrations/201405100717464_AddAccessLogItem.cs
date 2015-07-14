namespace pluton.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccessLogItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessLogItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Useragent = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Controller = c.String(),
                        Action = c.String(),
                        Username = c.String(),
                        SessionId = c.String(),
                        Ip = c.String(),
                        Browser = c.String(),
                        Url = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccessLogItems");
        }
    }
}
