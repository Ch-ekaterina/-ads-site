namespace HomeWork10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Advert : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Discription = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserEntities", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertEntities", "UserId", "dbo.UserEntities");
            DropIndex("dbo.AdvertEntities", new[] { "UserId" });
            DropTable("dbo.AdvertEntities");
        }
    }
}
