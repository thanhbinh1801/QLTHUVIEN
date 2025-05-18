using System;

namespace QLTHUVIEN.DTO
{
  public class SachCreateDTO
  {
    public int? IdSach { get; set; } 
    public string TenSach { get; set; }
    public string TacGia { get; set; }
    public string NhaXuatBan { get; set; }
    public string MoTa { get; set; }
    public int IdTheLoai { get; set; }
    public int SoLuong { get; set; }
    public string HinhAnh { get; set; }
  }
}