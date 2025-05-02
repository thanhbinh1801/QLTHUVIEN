using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTHUVIEN
{
    public partial class MuonsachForm : Form
    {
        private int IDSACH;
        private int IDNGUOIDUNG;
        private ViewUser viewUser;
        public MuonsachForm(int idsach, int idnguoidung)
        {
            InitializeComponent();
            IDSACH = idsach;
            IDNGUOIDUNG = idnguoidung;
            GUI();
        }
        public void GUI()
        {
            QLTV db = new QLTV();
            var sach = db.Sachs.SingleOrDefault(s => s.IdSach == IDSACH);
            string imagePath = Path.Combine(@"E:\DotNet\Image", sach.hinhAnh);
            if (sach != null)
            {
                txtTenSach.Text = sach.tenSach;
                pictureBox.ImageLocation = imagePath;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                QLTV db = new QLTV();
                MuonSach muonSach = new MuonSach()
                {
                    IdSach = IDSACH,
                    IdNguoiDung = IDNGUOIDUNG,
                    ngayMuon = dtpNgayMuon.Value,
                    ngayTra = dtpNgayTra.Value,
                    tinhTrangMuon = TinhTrangMuon.dangMuon
                };
                db.muonSachs.Add(muonSach);
                db.SaveChanges();
                MessageBox.Show("Mượn sách thành công");
                this.Close();

            }
            catch(Exception ex)
            {
                //MessageBox.Show("Lỗi: " + ex.Message);
                MessageBox.Show("Lỗi: " + ex.InnerException?.InnerException?.Message ?? ex.Message);

            }
        }
    }
}
