using System;
using System.Collections.Generic;
using System.Linq;
using QLTHUVIEN.DAL;
using QLTHUVIEN.DTO;
using QLTHUVIEN.Utils;

namespace QLTHUVIEN.BLL
{
  public class BLL_NguoiDung
  {
    private readonly DAL_NguoiDung dalNguoiDung;

    public BLL_NguoiDung()
    {
      dalNguoiDung = new DAL_NguoiDung();
    }


    public bool DoiMatKhau(int idNguoiDung, string matKhauMoi)//
    {
      try
      {
        var nguoiDung = dalNguoiDung.GetById(idNguoiDung);
        nguoiDung.matKhau = HashPassword.HashPW(matKhauMoi);
        dalNguoiDung.Update(nguoiDung);
        return true;
      }
      catch
      {
        return false;
      }
    }

    public List<NguoiDungDTO> LayDanhSachNguoiDung(string txtTimKiem)//
    {
        return dalNguoiDung.GetAllNguoiDung(txtTimKiem);
    }

        public bool XoaNguoiDung(int idNguoiDung)//
    {
      try
      {
        dalNguoiDung.Delete(idNguoiDung);
        return true;
      }
      catch
      {
        return false;
      }
    }

    public bool KiemTraDangNhap(string username, string password) //
    {
      var user = dalNguoiDung.GetByUsername(username);
      if (user == null) return false;

      return HashPassword.VerifyPW(password, user.matKhau);
    }

    public bool DangKyTaiKhoan(string username, string password, string fullName)//
    {
      try
      {
        if (dalNguoiDung.CheckUsernameExists(username))
          return false;

        var hashedPassword = HashPassword.HashPW(password);
        var newUser = new NguoiDung
        {
          tenTK = username,
          matKhau = hashedPassword,
          tenNguoiDung = fullName,
          phanQuyen = PhanQuyenNguoiDung.nguoiSoHuu
        };

        dalNguoiDung.Add(newUser);
        return true;
      }
      catch
      {
        return false;
      }
    }

    public NguoiDung LayThongTinNguoiDung(string username, int iduser)//
    {
        NguoiDung nguoiDung = null;

        if (!string.IsNullOrWhiteSpace(username))
        {
            nguoiDung = dalNguoiDung.GetByUsername(username);
        }

        if (nguoiDung == null)
        {
            nguoiDung = dalNguoiDung.GetById(iduser);
        }

        return nguoiDung;
    }
   }
}