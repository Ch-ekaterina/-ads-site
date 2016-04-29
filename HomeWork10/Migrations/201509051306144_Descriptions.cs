namespace HomeWork10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Descriptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdvertEntities", "Desсription", c => c.String());
            DropColumn("dbo.AdvertEntities", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdvertEntities", "Description", c => c.String());
            DropColumn("dbo.AdvertEntities", "Desсription");
        }
    }
}
