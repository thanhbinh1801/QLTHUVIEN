using QLTHUVIEN.BLL;
using QLTHUVIEN.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTHUVIEN
{
    public partial class Doimatkhau : Form
    {
        private readonly BLL_NguoiDung bllNguoiDung;
        private int IDNGUOIDUNG;
        public Doimatkhau(int iduser)
        {
            InitializeComponent();
            bllNguoiDung = new BLL_NguoiDung();
            IDNGUOIDUNG = iduser;
            txtNhapMKMoi.PasswordChar = '*';
            txtNhapMKMoi.PasswordChar = '*';
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            if( txtNhapMKMoi.Text == txtNhapMKMoi.Text)
            {
                if(bllNguoiDung.DoiMatKhau(IDNGUOIDUNG, txtNhapMKMoi.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu mới không khớp!");
            }
        }
    }
}
