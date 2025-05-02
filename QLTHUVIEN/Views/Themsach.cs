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
        private string ID;
        private ViewAdmin viewAdmin = new ViewAdmin();
        public Themsach(string id, ViewAdmin va)
        {
            InitializeComponent();
            LoadTheLoai();
            ID = id;
            viewAdmin = va;
            GUI();
        }

        public void LoadTheLoai()
        {
            QLTV db = new QLTV();
            List<TheLoai> theloai = new List<TheLoai>();
            theloai.AddRange(db.theLoais);
            cbbTheLoai.DataSource = theloai;
            cbbTheLoai.DisplayMember = "tentheLoai";
            cbbTheLoai.ValueMember = "IdTheLoai";
        }

        public void GUI()
        {
            QLTV db = new QLTV();
            if (string.IsNullOrEmpty(ID)){
                return;
            }
            var sach = db.Sachs.SingleOrDefault( s => s.IdSach.ToString() == ID);
            string imagePath = Path.Combine(@"E:\DotNet\Image", sach.hinhAnh);
            if (sach != null)
            {
                txtTenSach.Text = sach.tenSach;
                txtTacGia.Text = sach.tacGia;
                txtNhaXb.Text = sach.nhaXuatBan;
                txtMoTa.Text = sach.moTa;
                pictureBoxThemSach.ImageLocation = imagePath;
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Chọn ảnh|*.jpg;*.png";
            if( ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxThemSach.ImageLocation = ofd.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            QLTV db = new QLTV();
            var isExist = db.Sachs.Any(s => s.IdSach.ToString() == ID);
            if (isExist)
            {
                try
                {
                    var sach = db.Sachs.SingleOrDefault(s => s.IdSach.ToString() == ID);
                    sach.tenSach = txtTenSach.Text;
                    sach.tacGia = txtTacGia.Text;
                    sach.nhaXuatBan = txtNhaXb.Text;
                    sach.moTa = txtMoTa.Text;
                    sach.IdTheLoai = cbbTheLoai.SelectedIndex + 1;
                    sach.hinhAnh = Path.GetFileName(pictureBoxThemSach.ImageLocation);
                    db.SaveChanges();
                    MessageBox.Show("Sửa sách thành công");
                    this.Close();
                    viewAdmin.LoadSach();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi sửa sách: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    Sach sach = new Sach();
                    sach.tenSach = txtTenSach.Text;
                    sach.tacGia = txtTacGia.Text;
                    sach.nhaXuatBan = txtNhaXb.Text;
                    sach.moTa = txtMoTa.Text;
                    sach.tinhTrang = TinhTrangSach.coSan;
                    sach.soLuong = 1;
                    sach.IdTheLoai = cbbTheLoai.SelectedIndex + 1;
                    sach.hinhAnh = Path.GetFileName(pictureBoxThemSach.ImageLocation); 
                    db.Sachs.Add(sach);
                    db.SaveChanges();
                    MessageBox.Show("Thêm sách thành công");    
                    this.Close();
                    viewAdmin.LoadSach();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm sách: " + ex.InnerException?.InnerException?.Message);
                }
            }
        }
    }
}
