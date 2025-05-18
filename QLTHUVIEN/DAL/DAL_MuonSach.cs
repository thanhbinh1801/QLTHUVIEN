using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using QLTHUVIEN.DTO;

namespace QLTHUVIEN.DAL
{
  public class DAL_MuonSach
  {
    private readonly QLTV db;

    public DAL_MuonSach()
    {
      db = new QLTV();
    }

    public MuonSach GetAllMuonSach(string tenSach)//
    {
            return db.muonSachs.FirstOrDefault(ms => ms.sach.tenSach == tenSach);
        }

    public List<MuonSach> GetMuonSachByUserId(int userId)//
    {
      return db.muonSachs.Where(ms => ms.IdNguoiDung == userId).ToList();
    }

    public List<MuonSachDTO> GetSachDangMuon() // nếu là user thì truyền thêm iduser
    {
            return db.muonSachs.Where(ms => ms.tinhTrangMuon == TinhTrangMuon.dangMuon)
                      .Select(s => new MuonSachDTO
                      {
                          TenSach = s.sach.tenSach,
                          TenNguoiDung = s.nguoidung.tenNguoiDung,
                          NgayMuon = s.ngayMuon,
                          NgayTra = s.ngayTra,
                          TinhTrang = "Đang mượn"
                      })
                .ToList();
    }

    public bool AddMuonSach(MuonSach muonSach)//
    {
      try
      {
        db.muonSachs.Add(muonSach);
        db.SaveChanges();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public bool UpdateTinhTrangMuon(string tenSach, TinhTrangMuon tinhTrang)//
    {
      try
      {
        var muonSach = db.muonSachs.FirstOrDefault(ms => ms.sach.tenSach == tenSach);
        if (muonSach == null) return false;

        muonSach.tinhTrangMuon = tinhTrang;
        db.SaveChanges();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public List<MuonSachDTO> GetLichSuMuonTra(int? iduser) //
    {
      return db.muonSachs.Where(u => iduser == null || u.nguoidung.IdNguoiDung == iduser.Value) // phải có value , nếu k thì sẽ bị lỗi
        .Select(ls => new MuonSachDTO
        {
          TenSach = ls.sach.tenSach,
          TenNguoiDung = ls.nguoidung.tenNguoiDung,
          NgayMuon = ls.ngayMuon,
          NgayTra = ls.ngayTra,
          TinhTrang = ls.tinhTrangMuon == TinhTrangMuon.dangMuon ? "Đang mượn" : (ls.tinhTrangMuon == TinhTrangMuon.daTra ? "Đã trả" : "Quá hạn")
        })
        .ToList();
    }
  }
}