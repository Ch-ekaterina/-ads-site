namespace HomeWork10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WasUpdatedFieldsOnUserEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdvertEntities", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdvertEntities", "Description");
        }
    }
}
