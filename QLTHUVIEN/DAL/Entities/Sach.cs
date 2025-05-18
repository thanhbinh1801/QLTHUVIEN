using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTHUVIEN
{
    public class Sach
    {
        [Key]
        [Required]
        public int IdSach { get; set; }
        public string tenSach { get; set; }
        public string tacGia { get; set; }
        public string nhaXuatBan { get; set; }
        public string moTa { get; set; }
        public TinhTrangSach tinhTrang { get; set; }
        public int soLuong { get; set; }
        public string hinhAnh { get; set; }
        public int IdTheLoai { get; set; }
        [ForeignKey("IdTheLoai")]
        public virtual TheLoai theLoai { get; set; }
        public virtual ICollection<MuonSach> muonSach { get; set; }
    }
}
