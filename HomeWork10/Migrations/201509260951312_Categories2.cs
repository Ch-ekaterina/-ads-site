namespace HomeWork10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categories2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.СategoryViewModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        AdvertEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdvertEntities", t => t.AdvertEntity_Id)
                .Index(t => t.AdvertEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.СategoryViewModel", "AdvertEntity_Id", "dbo.AdvertEntities");
            DropIndex("dbo.СategoryViewModel", new[] { "AdvertEntity_Id" });
            DropTable("dbo.СategoryViewModel");
        }
    }
}
