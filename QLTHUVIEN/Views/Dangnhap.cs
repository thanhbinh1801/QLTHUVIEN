using System;
using System.Windows.Forms;
using QLTHUVIEN.BLL;

namespace QLTHUVIEN
{
    public partial class Dangnhap : Form
    {
        private BLL_NguoiDung bllNguoiDung;

        public Dangnhap()
        {
            InitializeComponent();
            bllNguoiDung = new BLL_NguoiDung();
            txtMK.PasswordChar = '*';
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            string username = txtTenTK.Text;
            string password = txtMK.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (bllNguoiDung.KiemTraDangNhap(username, password))
            {
                var user = bllNguoiDung.LayThongTinNguoiDung(username, 0);
                if (user.phanQuyen == PhanQuyenNguoiDung.nguoiSoHuu)
                {
                    ViewAdmin viewAdmin = new ViewAdmin(user.IdNguoiDung);
                    this.Hide();
                    viewAdmin.ShowDialog();
                }
                else
                {
                    ViewUser viewUser = new ViewUser(user.IdNguoiDung);
                    this.Hide();
                    viewUser.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }

        private void llbDangKi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangki dangki = new Dangki();
            this.Hide();
            dangki.ShowDialog();
            this.Show();
        }

    }
}
