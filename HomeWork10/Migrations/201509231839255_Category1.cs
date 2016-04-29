namespace HomeWork10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Category1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.СategoryEntity", "Category", c => c.String());
            DropColumn("dbo.СategoryEntity", "TitleCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.СategoryEntity", "TitleCategory", c => c.String());
            DropColumn("dbo.СategoryEntity", "Category");
        }
    }
}
