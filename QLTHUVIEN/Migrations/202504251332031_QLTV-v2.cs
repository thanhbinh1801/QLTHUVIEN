namespace QLTHUVIEN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QLTVv2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "NguoiDungs");
            DropForeignKey("dbo.Saches", "TheLoai_IdTheLoai", "dbo.TheLoais");
            DropIndex("dbo.Saches", new[] { "TheLoai_IdTheLoai" });
            RenameColumn(table: "dbo.Saches", name: "TheLoai_IdTheLoai", newName: "IdTheLoai");
            AlterColumn("dbo.Saches", "IdTheLoai", c => c.Int(nullable: false));
            CreateIndex("dbo.Saches", "IdTheLoai");
            AddForeignKey("dbo.Saches", "IdTheLoai", "dbo.TheLoais", "IdTheLoai", cascadeDelete: true);
            DropColumn("dbo.Saches", "theLoai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Saches", "theLoai", c => c.String());
            DropForeignKey("dbo.Saches", "IdTheLoai", "dbo.TheLoais");
            DropIndex("dbo.Saches", new[] { "IdTheLoai" });
            AlterColumn("dbo.Saches", "IdTheLoai", c => c.Int());
            RenameColumn(table: "dbo.Saches", name: "IdTheLoai", newName: "TheLoai_IdTheLoai");
            CreateIndex("dbo.Saches", "TheLoai_IdTheLoai");
            AddForeignKey("dbo.Saches", "TheLoai_IdTheLoai", "dbo.TheLoais", "IdTheLoai");
            RenameTable(name: "dbo.NguoiDungs", newName: "Users");
        }
    }
}
