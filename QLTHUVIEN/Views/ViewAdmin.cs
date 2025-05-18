using QLTHUVIEN.Utils;
using QLTHUVIEN.Views;
using QLTHUVIEN.BLL;
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
using QLTHUVIEN.DTO;

namespace QLTHUVIEN
{
    public partial class ViewAdmin : Form
    {
        private readonly BLL_Sach bllSach;
        private readonly BLL_TheLoai bllTheLoai;
        private readonly BLL_MuonSach bllMuonSach;
        private readonly BLL_NguoiDung bllNguoiDung;
        private int IDNGUOIDUNG;

        public ViewAdmin(int iduser)
        {
            InitializeComponent();
            bllSach = new BLL_Sach();
            bllTheLoai = new BLL_TheLoai();
            bllMuonSach = new BLL_MuonSach();
            bllNguoiDung = new BLL_NguoiDung();
            IDNGUOIDUNG = iduser;
            LoadSach();
            LoadTheLoai();
            LoadSachDangMuon();
            LoadLichSuMuonTra();
            LoadNguoiDung();
        }
        public void LoadSach()
        {
            string tukhoa = txtTimKiemSach.Text.Trim().ToLower();
            var sachList = bllSach.SearchSach(tukhoa);

            foreach (var sach in sachList)
            {
                if (!string.IsNullOrEmpty(sach.HinhAnhPath))
                {
                    string imagePath = Path.Combine(@"E:\DotNet\Image", sach.HinhAnhPath);
                    if (File.Exists(imagePath))
                    {
                        try
                        {
                            sach.HinhAnh = Image.FromFile(imagePath);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi khi tải hình ảnh: " + ex.Message);
                            sach.HinhAnh = null;
                        }
                    }
                }
            }
            ConfigureDataGridView(sachList);
        }
        private void ConfigureDataGridView(List<SachDTO> sachList)
        {
            dgvQuanLiSach.AutoGenerateColumns = false;
            dgvQuanLiSach.Columns.Clear();
            dgvQuanLiSach.RowTemplate.Height = 150;

            DataGridViewTextBoxColumn colIdSach = new DataGridViewTextBoxColumn();
            colIdSach.Name = "IdSach";
            colIdSach.HeaderText = "ID Sách";
            colIdSach.DataPropertyName = "IdSach";
            colIdSach.Visible = false;
            dgvQuanLiSach.Columns.Add(colIdSach);

            DataGridViewTextBoxColumn colTenSach = new DataGridViewTextBoxColumn();
            colTenSach.Name = "TenSach";
            colTenSach.HeaderText = "Tên Sách";
            colTenSach.DataPropertyName = "TenSach";
            dgvQuanLiSach.Columns.Add(colTenSach);

            DataGridViewTextBoxColumn colTacGia = new DataGridViewTextBoxColumn();
            colTacGia.Name = "TacGia";
            colTacGia.HeaderText = "Tác Giả";
            colTacGia.DataPropertyName = "TacGia";
            dgvQuanLiSach.Columns.Add(colTacGia);

            DataGridViewTextBoxColumn colNXB = new DataGridViewTextBoxColumn();
            colNXB.Name = "NhaXuatBan";
            colNXB.HeaderText = "Nhà Xuất Bản";
            colNXB.DataPropertyName = "NhaXuatBan";
            dgvQuanLiSach.Columns.Add(colNXB);

            DataGridViewTextBoxColumn colMoTa = new DataGridViewTextBoxColumn();
            colMoTa.Name = "MoTa";
            colMoTa.HeaderText = "Mô Tả";
            colMoTa.DataPropertyName = "MoTa";
            dgvQuanLiSach.Columns.Add(colMoTa);

            DataGridViewTextBoxColumn colTinhTrang = new DataGridViewTextBoxColumn();
            colTinhTrang.Name = "TinhTrang";
            colTinhTrang.HeaderText = "Tình Trạng";
            colTinhTrang.DataPropertyName = "TinhTrang";
            dgvQuanLiSach.Columns.Add(colTinhTrang);

            DataGridViewTextBoxColumn colTheLoai = new DataGridViewTextBoxColumn();
            colTheLoai.Name = "TheLoai";
            colTheLoai.HeaderText = "Thể Loại";
            colTheLoai.DataPropertyName = "TheLoai";
            dgvQuanLiSach.Columns.Add(colTheLoai);

            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn();
            colSoLuong.Name = "SoLuong";
            colSoLuong.HeaderText = "Số Lượng";
            colSoLuong.DataPropertyName = "SoLuong";
            dgvQuanLiSach.Columns.Add(colSoLuong);

            DataGridViewTextBoxColumn colHinhAnh = new DataGridViewTextBoxColumn();
            colHinhAnh.Name = "HinhAnhPath";
            colHinhAnh.Visible = false;
            colHinhAnh.DataPropertyName = "HinhAnhPath";
            dgvQuanLiSach.Columns.Add(colHinhAnh);

            DataGridViewImageColumn colHinhAnhHienThi = new DataGridViewImageColumn();
            colHinhAnhHienThi.Name = "hinhanh";
            colHinhAnhHienThi.HeaderText = "Hình Ảnh";
            colHinhAnhHienThi.DataPropertyName = "HinhAnh";
            colHinhAnhHienThi.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvQuanLiSach.Columns.Add(colHinhAnhHienThi);

            dgvQuanLiSach.DataSource = sachList;

            dgvQuanLiSach.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        public void LoadTheLoai()
        {
            string searchText = txtTimKiemSach.Text;
            var theloai = bllTheLoai.SearchTheLoai(searchText);
            dgvQLTL.DataSource = theloai;
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
                int id = Convert.ToInt32(dgvQuanLiSach.SelectedRows[0].Cells["IdSach"].Value);
                if (bllSach.DeleteSach(id))
                {
                    LoadSach();
                    MessageBox.Show("Xóa sách thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa sách thất bại!");
                }
            }
        }
        private void btnTimKiemTheLoai_Click(object sender, EventArgs e)
        {
            LoadTheLoai();
        }

        private void btnSuaTheloai_Click(object sender, EventArgs e)
        {
            ThemTheLoai themTheLoai = new ThemTheLoai(dgvQLTL.SelectedRows[0].Cells["IdTheLoai"].Value.ToString());
            if (themTheLoai.ShowDialog() == DialogResult.OK)
            {
                LoadTheLoai();
            }
        }

        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            ThemTheLoai themTheLoai = new ThemTheLoai(null);
            if (themTheLoai.ShowDialog() == DialogResult.OK)
            {
                LoadTheLoai();
            }
        }

        private void btnXoaTheLoai_Click(object sender, EventArgs e)
        {
            if (dgvQLTL.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvQLTL.SelectedRows[0].Cells["IdTheLoai"].Value);
                if (bllTheLoai.DeleteTheLoai(id))
                {
                    LoadTheLoai();
                    MessageBox.Show("Xóa thể loại thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa thể loại thất bại!");
                }
            }
        }

        public void LoadSachDangMuon()
        {
            var dangmuon = bllMuonSach.GetSachDangMuon();
            dgvDSSDDM.DataSource = dangmuon;
        }

        public void LoadLichSuMuonTra()
        {
            var lichsu = bllMuonSach.GetLichSuMuonTra(null);
            dgvLichSuMuonTra.DataSource = lichsu;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            Doimatkhau doimatkhau = new Doimatkhau(IDNGUOIDUNG);
            doimatkhau.ShowDialog();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dangnhap dangnhap = new Dangnhap();
            dangnhap.ShowDialog();
        }

        public void LoadNguoiDung()
        {
            string txtTimKiem = txtTimKiemUser.Text.Trim().ToLower();
            var nguoidung = bllNguoiDung.LayDanhSachNguoiDung(txtTimKiem);
            dgvTaiKhoan.DataSource = nguoidung;
        }
        private void btnTimKiemUser_Click(object sender, EventArgs e)
        {
            LoadNguoiDung();
        }

        private void btnXoaUser_Click(object sender, EventArgs e)
        {
            if(dgvTaiKhoan.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvTaiKhoan.SelectedRows[0].Cells["IdNguoiDung"].Value);
                if (bllNguoiDung.XoaNguoiDung(id))
                {
                    LoadNguoiDung();
                    MessageBox.Show("Xóa người dùng thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa người dùng thất bại!");
                }
            }
        }
    }
}
