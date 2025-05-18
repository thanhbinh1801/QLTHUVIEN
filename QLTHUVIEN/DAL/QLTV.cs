using System;
using System.Data.Entity;
using System.Linq;

namespace QLTHUVIEN.DAL
{
    public class QLTV : DbContext
    {
        public QLTV()
            : base("name=QLTV")
        {
        }

        public virtual DbSet<Sach> Sachs { get; set; }
        public virtual DbSet<NguoiDung> nguoiDungs { get; set; }
        public virtual DbSet<MuonSach> muonSachs { get; set; }
        public virtual DbSet<TheLoai> theLoais { get; set; }
    }
}