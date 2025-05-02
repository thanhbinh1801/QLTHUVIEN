using QLTHUVIEN.Utils;
using QLTHUVIEN.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTHUVIEN
{
    public partial class ViewAdmin : Form
    {
        public ViewAdmin()
        {
            InitializeComponent();
            LoadSach();
            LoadTheLoai();
            danhSachSachDangMuon();
            lichSuMuonTra();
        }
        public void LoadSach()
        {
            dgvQuanLiSach.CellFormatting -= dgvQuanLiSach_CellFormatting_1;

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
            dgvQuanLiSach.DataSource = null;
            dgvQuanLiSach.DataSource = l1;

            dgvQuanLiSach.Columns["IdSach"].Visible = false;
            dgvQuanLiSach.Columns["tenSach"].HeaderText = "Tên Sách";
            dgvQuanLiSach.Columns["tacGia"].HeaderText = "Tác Giả";
            dgvQuanLiSach.Columns["nhaXuatBan"].HeaderText = "Nhà Xuất Bản";
            dgvQuanLiSach.Columns["moTa"].HeaderText = "Mô Tả";
            dgvQuanLiSach.Columns["tinhTrang"].HeaderText = "Tình Trạng";
            dgvQuanLiSach.Columns["tentheLoai"].HeaderText = "Thể Loại";
            dgvQuanLiSach.Columns["soLuong"].HeaderText = "Số Lượng";
            dgvQuanLiSach.Columns["image"].Visible = false;


            if(!dgvQuanLiSach.Columns.Contains("hinhanh"))
            {
                DataGridViewImageColumn dgvic = new DataGridViewImageColumn();
                dgvic.Name = "hinhanh";
                dgvic.HeaderText = "Hình Ảnh";
                dgvic.ImageLayout = DataGridViewImageCellLayout.Zoom; 
                dgvQuanLiSach.Columns.Add(dgvic);
            }
            dgvQuanLiSach.Columns["hinhanh"].DisplayIndex = dgvQuanLiSach.Columns.Count - 1;
            dgvQuanLiSach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvQuanLiSach.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvQuanLiSach.CellFormatting += dgvQuanLiSach_CellFormatting_1;
        }

        private void dgvQuanLiSach_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvQuanLiSach.Columns[e.ColumnIndex].Name == "hinhanh" && e.RowIndex >= 0)
            {
                string imagePath = Path.Combine(@"E:\DotNet\Image", dgvQuanLiSach.Rows[e.RowIndex].Cells["image"].Value.ToString());
                try
                {
                    if (File.Exists(imagePath)){
                        Image img = Image.FromFile(imagePath);
                        e.Value = img;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi tải hình ảnh: " + ex.Message);
                }
            }
        }

        public void LoadTheLoai()
        {
            QLTV db = new QLTV();
            var l1 = db.theLoais.Select(t => new
            {
                t.IdTheLoai,
                t.tentheLoai
            }).ToList();
            dgvQLTL.DataSource = l1;
        }

        private void btnTimKiemSach_Click(object sender, EventArgs e)
        {
            LoadSach();
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            Themsach themsach = new Themsach(null, this);
            themsach.ShowDialog();
        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            Themsach themsach = new Themsach(dgvQuanLiSach.SelectedRows[0].Cells["IdSach"].Value.ToString(), this);
            themsach.ShowDialog();
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            if (dgvQuanLiSach.SelectedRows.Count > 0)
            {
                string id = dgvQuanLiSach.SelectedRows[0].Cells["IdSach"].Value.ToString();
                QLTV db = new QLTV();
                var sach = db.Sachs.SingleOrDefault(s => s.IdSach.ToString() == id);
                if (sach != null)
                {
                    db.Sachs.Remove(sach);
                    db.SaveChanges();
                    LoadSach();
                }
            }
        }

        private void btnSuaTheloai_Click(object sender, EventArgs e)
        {
            ThemTheLoai themTheLoai = new ThemTheLoai(dgvQLTL.SelectedRows[0].Cells["IdTheLoai"].Value.ToString());
            themTheLoai.ShowDialog();

        }

        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            ThemTheLoai themTheLoai = new ThemTheLoai(null);
            themTheLoai.ShowDialog();

        }

        private void btnXoaTheLoai_Click(object sender, EventArgs e)
        {
            if (dgvQLTL.SelectedRows.Count > 0)
            {
                string id = dgvQLTL.SelectedRows[0].Cells["IdTheLoai"].Value.ToString();
                QLTV db = new QLTV();
                var theloai = db.theLoais.SingleOrDefault(t => t.IdTheLoai.ToString() == id);
                if (theloai != null)
                {
                    db.theLoais.Remove(theloai);
                    db.SaveChanges();
                    LoadSach();
                }
            }
        }

        public void danhSachSachDangMuon()
        {
            QLTV db = new QLTV();
            var dangmuon = db.muonSachs.Where( ms => ms.tinhTrangMuon == TinhTrangMuon.dangMuon).Select( s => new
            {
                s.sach.tenSach,
                s.nguoidung.tenNguoiDung,
                s.ngayMuon,
                s.ngayTra
            }).ToList();
            dgvDSSDDM.DataSource = dangmuon;
        }
        public void lichSuMuonTra()
        {
            QLTV db = new QLTV();
            var lichsu = db.muonSachs.Select(ls => new
            {
                ls.sach.tenSach,
                ls.nguoidung.tenNguoiDung,
                ls.ngayMuon,
                ls.ngayTra
            });
            dgvLichSuMuonTra.DataSource = lichsu.ToList();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            Doimatkhau doimatkhau = new Doimatkhau();
            doimatkhau.ShowDialog();
        }

    }
}
