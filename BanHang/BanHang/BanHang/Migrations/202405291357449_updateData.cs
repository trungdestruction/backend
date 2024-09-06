namespace BanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Table_Category", "Alias", c => c.String());
            AddColumn("dbo.Table_News", "Alias", c => c.String());
            AddColumn("dbo.Table_Post", "Alias", c => c.String());
            AddColumn("dbo.Table_Product", "Alias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Table_Product", "Alias");
            DropColumn("dbo.Table_Post", "Alias");
            DropColumn("dbo.Table_News", "Alias");
            DropColumn("dbo.Table_Category", "Alias");
        }
    }
}
