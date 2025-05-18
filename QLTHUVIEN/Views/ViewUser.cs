using QLTHUVIEN.Utils;
using QLTHUVIEN.BLL;
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
using QLTHUVIEN.DTO;

namespace QLTHUVIEN
{
    public partial class ViewUser : Form
    {
        public int IDNGUOIDUNG;
        private readonly BLL_Sach bllSach;
        private readonly BLL_NguoiDung bllNguoiDung;
        private readonly BLL_MuonSach bllMuonSach;

        public ViewUser(int idnguoidung)
        {
            InitializeComponent();
            IDNGUOIDUNG = idnguoidung;
            bllSach = new BLL_Sach();
            bllNguoiDung = new BLL_NguoiDung();
            bllMuonSach = new BLL_MuonSach();
            loadTenNguoiDung();
            LoadSach();
            LichSuMuonSach();
        }

        public void LoadSach()
        {
            string tukhoa = txtTimKiemSach.Text.Trim().ToLower();
            var sachList = bllSach.GetSachCoTheChoMuon(tukhoa);

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
            dgvSach.AutoGenerateColumns = false;
            dgvSach.Columns.Clear();
            dgvSach.RowTemplate.Height = 150;

            DataGridViewTextBoxColumn colIdSach = new DataGridViewTextBoxColumn();
            colIdSach.Name = "IdSach";
            colIdSach.HeaderText = "ID Sách";
            colIdSach.DataPropertyName = "IdSach";
            colIdSach.Visible = false;
            dgvSach.Columns.Add(colIdSach);

            DataGridViewTextBoxColumn colTenSach = new DataGridViewTextBoxColumn();
            colTenSach.Name = "TenSach";
            colTenSach.HeaderText = "Tên Sách";
            colTenSach.DataPropertyName = "TenSach";
            dgvSach.Columns.Add(colTenSach);

            DataGridViewTextBoxColumn colTacGia = new DataGridViewTextBoxColumn();
            colTacGia.Name = "TacGia";
            colTacGia.HeaderText = "Tác Giả";
            colTacGia.DataPropertyName = "TacGia";
            dgvSach.Columns.Add(colTacGia);

            DataGridViewTextBoxColumn colNXB = new DataGridViewTextBoxColumn();
            colNXB.Name = "NhaXuatBan";
            colNXB.HeaderText = "Nhà Xuất Bản";
            colNXB.DataPropertyName = "NhaXuatBan";
            dgvSach.Columns.Add(colNXB);

            DataGridViewTextBoxColumn colMoTa = new DataGridViewTextBoxColumn();
            colMoTa.Name = "MoTa";
            colMoTa.HeaderText = "Mô Tả";
            colMoTa.DataPropertyName = "MoTa";
            dgvSach.Columns.Add(colMoTa);

            DataGridViewTextBoxColumn colTinhTrang = new DataGridViewTextBoxColumn();
            colTinhTrang.Name = "TinhTrangText";
            colTinhTrang.HeaderText = "Tình Trạng";
            colTinhTrang.DataPropertyName = "TinhTrang";
            dgvSach.Columns.Add(colTinhTrang);

            DataGridViewTextBoxColumn colTheLoai = new DataGridViewTextBoxColumn();
            colTheLoai.Name = "TheLoai";
            colTheLoai.HeaderText = "Thể Loại";
            colTheLoai.DataPropertyName = "TheLoai";
            dgvSach.Columns.Add(colTheLoai);

            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn();
            colSoLuong.Name = "SoLuong";
            colSoLuong.HeaderText = "Số Lượng";
            colSoLuong.DataPropertyName = "SoLuong";
            dgvSach.Columns.Add(colSoLuong);

            DataGridViewTextBoxColumn colHinhAnh = new DataGridViewTextBoxColumn();
            colHinhAnh.Name = "HinhAnhPath";
            colHinhAnh.Visible = false;
            colHinhAnh.DataPropertyName = "HinhAnhPath";
            dgvSach.Columns.Add(colHinhAnh);

            DataGridViewImageColumn colHinhAnhHienThi = new DataGridViewImageColumn();
            colHinhAnhHienThi.Name = "hinhanh";
            colHinhAnhHienThi.HeaderText = "Hình Ảnh";
            colHinhAnhHienThi.DataPropertyName = "HinhAnh";
            colHinhAnhHienThi.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvSach.Columns.Add(colHinhAnhHienThi);

            dgvSach.DataSource = sachList;

            dgvSach.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            int idsach = Convert.ToInt32(dgvSach.SelectedRows[0].Cells["IdSach"].Value.ToString());
            MuonsachForm muonsachForm = new MuonsachForm(idsach, IDNGUOIDUNG);
            muonsachForm.ShowDialog();
            LoadSach();
            LichSuMuonSach();
        }
        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (bllMuonSach.TraSach(dgvLSMuonSach.SelectedRows[0].Cells["TenSach"].Value.ToString()))
            {
                MessageBox.Show("Trả sách thành công!");
                LichSuMuonSach();
            }
            else
            {
                MessageBox.Show("Trả sách thất bại!");
            }
        }

        public void loadTenNguoiDung()
        {
            var nguoidung = bllNguoiDung.LayThongTinNguoiDung( null, IDNGUOIDUNG);
            if (nguoidung != null)
            {
                lbNguoiDung.Text = nguoidung.tenNguoiDung;
                txtFullName.Text = nguoidung.tenNguoiDung;
            }
        }

        public void LichSuMuonSach()
        {
            var lichsu = bllMuonSach.GetLichSuMuonTra(IDNGUOIDUNG);
            dgvLSMuonSach.DataSource = lichsu;

            dgvLSMuonSach.Columns["TenSach"].HeaderText = "Tên sách";
            dgvLSMuonSach.Columns["NgayMuon"].HeaderText = "Ngày mượn";
            dgvLSMuonSach.Columns["NgayTra"].HeaderText = "Ngày trả";
            dgvLSMuonSach.Columns["TinhTrang"].HeaderText = "Tình trạng mượn";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadSach();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dangnhap dangnhap = new Dangnhap();
            dangnhap.ShowDialog();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            Doimatkhau doimatkhau = new Doimatkhau(IDNGUOIDUNG);
            doimatkhau.ShowDialog();
        }
    }
}
