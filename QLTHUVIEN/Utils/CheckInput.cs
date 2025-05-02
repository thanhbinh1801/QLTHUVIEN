using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTHUVIEN.Utils
{
    public class CheckInput
    {
        public bool checkHVT(string hvt)
        {
            if (hvt == "")
            {
                MessageBox.Show("Vui lòng nhập họ và tên");
                return false;
            }
            return true;
        }
        public bool checkTenTK(string tentk)
        {
            if (tentk.Length < 9)
            {
                MessageBox.Show("Tên tài khoản phải lớn hơn 9 ký tự");
                return false;
            }
            return true;
        }
        public bool checkMK(string mk)
        {
            if (mk.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải lớn hơn 6 ký tự");
                return false;
            }
            return true;
        }
    }
}
