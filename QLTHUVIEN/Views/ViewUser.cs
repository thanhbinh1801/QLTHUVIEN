using QLTHUVIEN.Utils;
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
    public partial class ViewUser : Form
    {
        public int IDNGUOIDUNG;
        QLTV db = new QLTV();
        public ViewUser(int idnguoidung)
        {
            InitializeComponent();
            IDNGUOIDUNG = idnguoidung;
            loadTenNguoiDung();
            LoadSach();
            LichSuMuonSach();
        }

        public void LoadSach()
        {
            dgvSach.CellFormatting -= dgvSach_CellFormatting;

            QLTV db = new QLTV();

            string tukhoa = txtTimKiemSach.Text.Trim().ToLower();
            var l1 = db.Sachs.Where(s => string.IsNullOrEmpty(tukhoa) || s.tenSach.ToLower().Contains(tukhoa))
                .Select(s => new
                {
                    s.IdSach,
                    s.tenSach,
                    s.tacGia,
                    s.nhaXuatBan,
                    s.moTa,
                    tinhTrang = s.tinhTrang.ToString(),
                    s.theLoai.tentheLoai,
                    s.soLuong,
                    image = s.hinhAnh
                }).ToList();
            dgvSach.DataSource = null;
            dgvSach.DataSource = l1;

            dgvSach.Columns["IdSach"].Visible = false;
            dgvSach.Columns["tenSach"].HeaderText = "Tên Sách";
            dgvSach.Columns["tacGia"].HeaderText = "Tác Giả";
            dgvSach.Columns["nhaXuatBan"].HeaderText = "Nhà Xuất Bản";
            dgvSach.Columns["moTa"].HeaderText = "Mô Tả";
            dgvSach.Columns["tinhTrang"].HeaderText = "Tình Trạng";
            dgvSach.Columns["tentheLoai"].HeaderText = "Thể Loại";
            dgvSach.Columns["soLuong"].HeaderText = "Số Lượng";
            dgvSach.Columns["image"].Visible = false;


            if (!dgvSach.Columns.Contains("hinhanh"))
            {
                DataGridViewImageColumn dgvic = new DataGridViewImageColumn();
                dgvic.Name = "hinhanh";
                dgvic.HeaderText = "Hình Ảnh";
                dgvic.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvSach.Columns.Add(dgvic);
            }
            dgvSach.Columns["hinhanh"].DisplayIndex = dgvSach.Columns.Count - 1;
            dgvSach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSach.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvSach.CellFormatting += dgvSach_CellFormatting;
        }

        private void dgvSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSach.Columns[e.ColumnIndex].Name == "hinhanh" && e.RowIndex >= 0)
            {
                if (e.Value != null && e.Value is Image)
                    return;
                try
                {
                    string imagePath = Path.Combine(@"E:\DotNet\Image", dgvSach.Rows[e.RowIndex].Cells["image"].Value.ToString());
                    if (File.Exists(imagePath))
                    {
                        using (Image img = Image.FromFile(imagePath))
                        {
                            e.Value = new Bitmap(img); 
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi tải hình ảnh: " + ex.Message);
                }
            }
        }


        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            int idsach = Convert.ToInt32(dgvSach.SelectedRows[0].Cells["IdSach"].Value.ToString());
            MuonsachForm muonsachForm = new MuonsachForm(idsach, IDNGUOIDUNG);
            muonsachForm.ShowDialog();
        }

        public void loadTenNguoiDung()
        {
            var nguoidung = db.nguoiDungs.SingleOrDefault(n => n.IdNguoiDung == IDNGUOIDUNG);
            lbNguoiDung.Text = nguoidung.tenNguoiDung;
            txtFullName.Text = nguoidung.tenNguoiDung;
        }

        public void LichSuMuonSach()
        {
            var l1 = db.muonSachs.Where(s => s.IdNguoiDung == IDNGUOIDUNG).Select(s => new
            {
                s.IdMuonSach,
                s.sach.tenSach,
                s.ngayMuon,
                s.ngayTra,
                s.tinhTrangMuon
            }).ToList();
            dgvLSMuonSach.DataSource = l1;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadSach();
        }
    }
}
