namespace QLTHUVIEN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QLTVv4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NguoiDungs", "tenTK", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NguoiDungs", "tenTK");
        }
    }
}
