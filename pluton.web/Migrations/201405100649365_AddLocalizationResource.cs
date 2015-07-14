namespace pluton.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocalizationResource : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocalizationResources",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Culture = c.String(),
                        Value = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LocalizationResources");
        }
    }
}
