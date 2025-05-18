using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTHUVIEN
{
    public class TheLoai
    {
        public TheLoai()
        {
            sach = new HashSet<Sach>();
        }
        [Key]
        public int IdTheLoai { get; set; }
        public string tentheLoai { get; set; }
        public virtual ICollection<Sach> sach { get; set; }
    }
}
