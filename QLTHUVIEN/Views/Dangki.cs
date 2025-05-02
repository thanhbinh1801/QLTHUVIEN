using QLTHUVIEN;
using QLTHUVIEN.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3
{
    public partial class Dangki : Form
    {
        CheckInput vd = new CheckInput();
        public Dangki()
        {
            InitializeComponent();
        }

        private void btnDKi_Click(object sender, EventArgs e)
        {
            if (vd.checkHVT(txtHVT.Text) && vd.checkTenTK(txtTenTK.Text) && vd.checkMK(txtMK.Text))
            {
                try
                {
                    var db = new QLTV();
                    NguoiDung nguoiDung = new NguoiDung()
                    {
                        tenNguoiDung = txtHVT.Text,
                        tenTK = txtTenTK.Text,
                        matKhau = HashPassword.HashPW(txtMK.Text),
                        phanQuyen = PhanQuyenNguoiDung.nguoiMuon
                    };
                    db.nguoiDungs.Add(nguoiDung);
                    db.SaveChanges();
                    MessageBox.Show("Đăng kí thành công");
                    this.Hide();
                    new Dangnhap().ShowDialog();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Đăng kí không thành công" + err.Message);
                }
            }
        }

    }
}
