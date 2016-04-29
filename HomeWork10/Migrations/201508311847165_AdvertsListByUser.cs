namespace HomeWork10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdvertsListByUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AdvertEntities", "Discription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdvertEntities", "Discription", c => c.String());
        }
    }
}
