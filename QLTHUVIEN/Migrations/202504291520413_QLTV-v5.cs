namespace QLTHUVIEN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QLTVv5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MuonSaches", "tinhTrangMuon", c => c.Int(nullable: false));
            DropColumn("dbo.MuonSaches", "daTra");
            DropColumn("dbo.NguoiDungs", "email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NguoiDungs", "email", c => c.String());
            AddColumn("dbo.MuonSaches", "daTra", c => c.Boolean(nullable: false));
            DropColumn("dbo.MuonSaches", "tinhTrangMuon");
        }
    }
}
