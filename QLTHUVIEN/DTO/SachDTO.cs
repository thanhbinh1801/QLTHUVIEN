using System;
using System.Drawing;

namespace QLTHUVIEN.DTO
{
  public class SachDTO
  {
    public int IdSach { get; set; }
    public string TenSach { get; set; }
    public string TacGia { get; set; }
    public string NhaXuatBan { get; set; }
    public string MoTa { get; set; }
    public string TinhTrang { get; set; }
    public string TheLoai { get; set; }
    public int SoLuong { get; set; }
    public string HinhAnhPath { get; set; }
    public Image HinhAnh { get; set; }
  }
}