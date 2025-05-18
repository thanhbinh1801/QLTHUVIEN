using System;
using System.IO;
using System.Windows.Forms;
using QLTHUVIEN.BLL;

namespace QLTHUVIEN
{
    public partial class MuonsachForm : Form
    {
        private readonly int IDSACH;
        private readonly int IDNGUOIDUNG;
        private readonly BLL_MuonSach _bllMuonSach;
        private readonly BLL_Sach _bllSach;

        public MuonsachForm(int idSach, int idNguoiDung)
        {
            InitializeComponent();
            IDSACH = idSach;
            IDNGUOIDUNG = idNguoiDung;
            _bllMuonSach = new BLL_MuonSach();
            _bllSach = new BLL_Sach();
            GUI();
        }

        public void GUI()
        {
            var sach = _bllSach.GetSachById(IDSACH);
            txtTenSach.Enabled = false;
            dtpNgayMuon.Enabled = false;
            string imagePath = Path.Combine(@"E:\DotNet\Image", sach.hinhAnh);
            if (sach != null)
            {
                txtTenSach.Text = sach.tenSach;
                pictureBox.ImageLocation = imagePath;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (dtpNgayMuon.Value > dtpNgayTra.Value)
            {
                MessageBox.Show("Ngày mượn không được lớn hơn ngày trả.");
                return;
            }
            try
            {
                bool result = _bllMuonSach.MuonSach(IDNGUOIDUNG, IDSACH, dtpNgayMuon.Value, dtpNgayTra.Value);
                if (result)
                {
                    MessageBox.Show("Mượn sách thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể mượn sách vì đã mượn hơn 3 quyển");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
