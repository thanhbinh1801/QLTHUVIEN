using System;
using System.Windows.Forms;
using QLTHUVIEN.BLL;

namespace QLTHUVIEN
{
    public partial class Dangki : Form
    {
        private BLL_NguoiDung bllNguoiDung;

        public Dangki()
        {
            InitializeComponent();
            bllNguoiDung = new BLL_NguoiDung();
            txtMK.PasswordChar = '*';
        }

        private void btnDKi_Click(object sender, EventArgs e)
        {
            string username = txtTenTK.Text;
            string password = txtMK.Text;
            string fullName = txtHVT.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (bllNguoiDung.DangKyTaiKhoan(username, password, fullName))
            {
                MessageBox.Show("Đăng ký thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!");
            }
        }
    }
}
