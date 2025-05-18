using QLTHUVIEN.BLL;
using QLTHUVIEN.DTO;
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
    public partial class Themsach : Form
    {
        private readonly BLL_Sach bllSach;
        private readonly BLL_TheLoai bllTheLoai;
        private readonly ViewAdmin viewAdmin;
        private readonly string idSach;
        private string selectedImagePath;

        public Themsach(string id, ViewAdmin viewAdmin)
        {
            InitializeComponent();
            bllSach = new BLL_Sach();
            bllTheLoai = new BLL_TheLoai();
            this.viewAdmin = viewAdmin;
            this.idSach = id;

            LoadTheLoai();
            if (!string.IsNullOrEmpty(idSach))
            {
                LoadSachForEdit();
            }
        }

        private void LoadTheLoai()
        {
            var theloai = bllTheLoai.GetAll();
            cbbTheLoai.DataSource = theloai;
            cbbTheLoai.DisplayMember = "tentheLoai";
            cbbTheLoai.ValueMember = "IdTheLoai";
        }

        private void LoadSachForEdit()
        {
            var sach = bllSach.GetSachForEdit(int.Parse(idSach));
            if (sach != null)
            {
                txtTenSach.Text = sach.TenSach;
                txtTacGia.Text = sach.TacGia;
                txtNhaXb.Text = sach.NhaXuatBan;
                txtMoTa.Text = sach.MoTa;
                cbbTheLoai.SelectedValue = sach.IdTheLoai;
                txtSoLuong.Text = sach.SoLuong.ToString();
                selectedImagePath = sach.HinhAnh;
                if (!string.IsNullOrEmpty(selectedImagePath))
                {
                    string fullPath = Path.Combine(@"E:\DotNet\Image", selectedImagePath);
                    if (File.Exists(fullPath))
                    {
                        pictureBoxThemSach.ImageLocation = fullPath;
                    }
                }
            }
        }


        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(openFileDialog.FileName);
                    string destinationPath = Path.Combine(@"E:\DotNet\Image", fileName);

                    try
                    {
                        if (File.Exists(destinationPath))
                        {
                            fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;
                            destinationPath = Path.Combine(@"E:\DotNet\Image", fileName);
                        }

                        File.Copy(openFileDialog.FileName, destinationPath);
                        selectedImagePath = fileName;
                        pictureBoxThemSach.ImageLocation = destinationPath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi chọn ảnh: " + ex.Message);
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sách!");
                return;
            }

            var sachDTO = new SachCreateDTO
            {
                TenSach = txtTenSach.Text.Trim(),
                TacGia = txtTacGia.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                IdTheLoai = (int)cbbTheLoai.SelectedValue,
                NhaXuatBan = txtNhaXb.Text.Trim(),
                SoLuong = int.Parse(txtSoLuong.Text.Trim()),
                HinhAnh = selectedImagePath
            };

            bool success;
            if (string.IsNullOrEmpty(idSach))
            {
                success = bllSach.AddSach(sachDTO);
            }
            else
            {
                sachDTO.IdSach = int.Parse(idSach);
                success = bllSach.UpdateSach(sachDTO);
            }

            if (success)
            {
                MessageBox.Show(string.IsNullOrEmpty(idSach) ? "Thêm sách thành công!" : "Cập nhật sách thành công!");
                viewAdmin.LoadSach();
                this.Close();
            }
            else
            {
                MessageBox.Show(string.IsNullOrEmpty(idSach) ? "Thêm sách thất bại!" : "Cập nhật sách thất bại!");
            }
        }
    }
}
