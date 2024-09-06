namespace BanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Table_Category", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Table_News", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Table_Post", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Table_Product", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Table_Product", "IsActive");
            DropColumn("dbo.Table_Post", "IsActive");
            DropColumn("dbo.Table_News", "IsActive");
            DropColumn("dbo.Table_Category", "IsActive");
        }
    }
}
