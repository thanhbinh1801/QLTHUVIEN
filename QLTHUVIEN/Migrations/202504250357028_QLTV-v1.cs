namespace QLTHUVIEN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QLTVv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MuonSaches",
                c => new
                    {
                        IdMuonSach = c.Int(nullable: false, identity: true),
                        IdSach = c.Int(nullable: false),
                        IdNguoiDung = c.Int(nullable: false),
                        ngayMuon = c.DateTime(nullable: false),
                        ngayTra = c.DateTime(nullable: false),
                        daTra = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdMuonSach)
                .ForeignKey("dbo.Saches", t => t.IdSach, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdNguoiDung, cascadeDelete: true)
                .Index(t => t.IdSach)
                .Index(t => t.IdNguoiDung);
            
            CreateTable(
                "dbo.Saches",
                c => new
                    {
                        IdSach = c.Int(nullable: false, identity: true),
                        tenSach = c.String(),
                        tacGia = c.String(),
                        nhaXuatBan = c.String(),
                        theLoai = c.String(),
                        moTa = c.String(),
                        tinhTrang = c.Int(nullable: false),
                        soLuong = c.Int(nullable: false),
                        hinhAnh = c.String(),
                        TheLoai_IdTheLoai = c.Int(),
                    })
                .PrimaryKey(t => t.IdSach)
                .ForeignKey("dbo.TheLoais", t => t.TheLoai_IdTheLoai)
                .Index(t => t.TheLoai_IdTheLoai);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdNguoiDung = c.Int(nullable: false, identity: true),
                        tenNguoiDung = c.String(),
                        email = c.String(),
                        matKhau = c.String(),
                        phanQuyen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdNguoiDung);
            
            CreateTable(
                "dbo.TheLoais",
                c => new
                    {
                        IdTheLoai = c.Int(nullable: false, identity: true),
                        tentheLoai = c.String(),
                    })
                .PrimaryKey(t => t.IdTheLoai);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Saches", "TheLoai_IdTheLoai", "dbo.TheLoais");
            DropForeignKey("dbo.MuonSaches", "IdNguoiDung", "dbo.Users");
            DropForeignKey("dbo.MuonSaches", "IdSach", "dbo.Saches");
            DropIndex("dbo.Saches", new[] { "TheLoai_IdTheLoai" });
            DropIndex("dbo.MuonSaches", new[] { "IdNguoiDung" });
            DropIndex("dbo.MuonSaches", new[] { "IdSach" });
            DropTable("dbo.TheLoais");
            DropTable("dbo.Users");
            DropTable("dbo.Saches");
            DropTable("dbo.MuonSaches");
        }
    }
}
