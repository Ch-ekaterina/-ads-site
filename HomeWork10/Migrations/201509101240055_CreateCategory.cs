namespace HomeWork10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.СategoryEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleCategory = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AdvertEntities", "CategoryId", c => c.Int());
            CreateIndex("dbo.AdvertEntities", "CategoryId");
            AddForeignKey("dbo.AdvertEntities", "CategoryId", "dbo.СategoryEntity", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertEntities", "CategoryId", "dbo.СategoryEntity");
            DropIndex("dbo.AdvertEntities", new[] { "CategoryId" });
            DropColumn("dbo.AdvertEntities", "CategoryId");
            DropTable("dbo.СategoryEntity");
        }
    }
}
