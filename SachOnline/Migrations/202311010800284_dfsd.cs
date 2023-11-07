namespace SachOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfsd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DONDATHANG", "DiaChiGH", c => c.String());
            AddColumn("dbo.DONDATHANG", "DienThoaiGH", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DONDATHANG", "DienThoaiGH");
            DropColumn("dbo.DONDATHANG", "DiaChiGH");
        }
    }
}
