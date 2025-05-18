using QLTHUVIEN;
using QLTHUVIEN.BLL;
using QLTHUVIEN.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTHUVIEN.Views
{
    public partial class ThemTheLoai : Form
    {
        public string IDTHELOAI;
        BLL_TheLoai bll = new BLL_TheLoai();

        public ThemTheLoai(string idtheloai)
        {
            InitializeComponent();
            IDTHELOAI = idtheloai;
            LoadData();
        }

        public void LoadData()
        {
            if (string.IsNullOrEmpty(IDTHELOAI))
            {
                return;
            }

            txtIDTL.ReadOnly = true;
            var theloai = bll.GetById(int.Parse(IDTHELOAI));
            if (theloai != null)
            {
                txtIDTL.Text = theloai.IdTheLoai.ToString();
                txtTenTL.Text = theloai.TenTheLoai;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TheLoaiDTO tl = new TheLoaiDTO();
            tl.TenTheLoai = txtTenTL.Text;

            bool ok;
            if (!string.IsNullOrEmpty(IDTHELOAI))
            {
                tl.IdTheLoai = int.Parse(IDTHELOAI);
                ok = bll.UpdateTheLoai(tl);
                if (ok)
                {
                    MessageBox.Show("Sửa thể loại thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else MessageBox.Show("Sửa thể loại thất bại!");
            }
            else
            {
                if (!string.IsNullOrEmpty(txtIDTL.Text))
                {
                    tl.IdTheLoai = int.Parse(txtIDTL.Text);
                }
                ok = bll.AddTheLoai(tl);
                if (ok)
                {
                    MessageBox.Show("Thêm thể loại thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else MessageBox.Show("Thêm thể loại thất bại!");
            }
        }
    }
}


