using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTHUVIEN
{
    public class NguoiDung
    {
        public NguoiDung()
        {
            muonSach = new HashSet<MuonSach>();
        }
        [Key]
        public int IdNguoiDung { get; set; }
        public string tenNguoiDung { get; set; }
        public string tenTK { get; set; }
        public string matKhau { get; set; }
        public PhanQuyenNguoiDung phanQuyen { get; set; }
        public virtual ICollection<MuonSach> muonSach { get; set; }
    }
}
