using QLTHUVIEN;
using QLTHUVIEN.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3
{
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            var db = new QLTV();
            var user = db.nguoiDungs.Where( p => p.tenTK == txtTenTK.Text).FirstOrDefault();
            if(user == null)
            {
                MessageBox.Show("Tài khoản không tồn tại!");
                return;
            }
            if( HashPassword.VerifyPW(txtMK.Text, user.matKhau))
            {
                this.Hide();
                if(user.phanQuyen == PhanQuyenNguoiDung.nguoiSoHuu)
                {
                    new ViewAdmin().ShowDialog();
                } else
                {
                    new ViewUser(user.IdNguoiDung).ShowDialog();
                }
            }
        }

        private void llbDangKi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Dangki().ShowDialog();
        }

        private void llbQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Doimatkhau().ShowDialog();
        }
    }
}
