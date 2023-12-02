namespace SachOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsfdsfds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DONDATHANG", "Dathanhtoan", c => c.Boolean(nullable: false));
            AlterColumn("dbo.DONDATHANG", "Tinhtranggiaohang", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DONDATHANG", "Tinhtranggiaohang", c => c.Boolean());
            AlterColumn("dbo.DONDATHANG", "Dathanhtoan", c => c.Boolean());
        }
    }
}
