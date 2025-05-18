using QLTHUVIEN;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace QLTHUVIEN
{
    public class MuonSach
    {
        [Key]
        [Required]
        public int IdMuonSach { get; set; }
        public int IdSach { get; set; }
        public int IdNguoiDung { get; set; }
        public DateTime ngayMuon { get; set; }
        public DateTime ngayTra { get; set; }
        public TinhTrangMuon tinhTrangMuon { get; set; }

        [ForeignKey("IdSach")]
        public virtual Sach sach { get; set; }

        [ForeignKey("IdNguoiDung")]
        public virtual NguoiDung nguoidung { get; set; }
    }
}