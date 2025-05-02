using QLTHUVIEN;
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
        public string ID;
        public ThemTheLoai(string id)
        {
            InitializeComponent();
            ID = id;
            GUI();
        }
        public void GUI()
        {
            QLTV db = new QLTV();
            if (string.IsNullOrEmpty(ID))
            {
                return;
            }
            txtIDTL.ReadOnly = true;
            var theloai = db.theLoais.SingleOrDefault(t => t.IdTheLoai.ToString() == ID);
            if (theloai != null)
            {
                txtIDTL.Text = theloai.IdTheLoai.ToString();
                txtTenTL.Text = theloai.tentheLoai;

            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            QLTV db = new QLTV();
            bool isExist = db.theLoais.Any(t => t.IdTheLoai.ToString() == ID);
            if (isExist)
            {
                try
                {
                    var theloai = db.theLoais.SingleOrDefault(t => t.IdTheLoai.ToString() == ID);
                    theloai.tentheLoai = txtTenTL.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sửa thể loại: " + ex.Message);
                }

            }
            else
            {
                try
                {
                    TheLoai tl = new TheLoai()
                    {
                        IdTheLoai = Convert.ToInt32(txtIDTL.Text),
                        tentheLoai = txtTenTL.Text
                    };
                    db.theLoais.Add(tl);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thể loại thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm thể loại: " + ex.Message);
                }
            }
        }
    }
}


