namespace BanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editpot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Table_Post", "CreatedBy", c => c.String());
            AddColumn("dbo.Table_Post", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Table_Post", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Table_Post", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Table_Post", "ModifiedBy");
            DropColumn("dbo.Table_Post", "ModifiedDate");
            DropColumn("dbo.Table_Post", "CreatedDate");
            DropColumn("dbo.Table_Post", "CreatedBy");
        }
    }
}
