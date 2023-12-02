namespace SachOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sfdsfds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        IDFeedback = c.Int(nullable: false, identity: true),
                        MaKH = c.Int(),
                        Feedback = c.String(maxLength: 255),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDFeedback)
                .ForeignKey("dbo.KHACHHANG", t => t.MaKH)
                .Index(t => t.MaKH);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedback", "MaKH", "dbo.KHACHHANG");
            DropIndex("dbo.Feedback", new[] { "MaKH" });
            DropTable("dbo.Feedback");
        }
    }
}
