using System;
using System.Collections.Generic;
using System.Linq;
using QLTHUVIEN.DTO;

namespace QLTHUVIEN.DAL
{
  public class DAL_Sach
  {
    private readonly QLTV db;

    public DAL_Sach()
    {
      db = new QLTV();
    }

    public List<Sach> GetAllSach()
    {
      return db.Sachs.ToList();
    }

    public Sach GetSachById(int id)//
    {
      return db.Sachs.Find(id);
    }

    public List<Sach> GetSachByTheLoai(int idTheLoai)
    {
      return db.Sachs.Where(s => s.IdTheLoai == idTheLoai).ToList();
    }


    public List<SachDTO> SearchSach(string tukhoa) // admin
    {
      return db.Sachs
          .Where(s =>
              s.tenSach.ToLower().Contains(tukhoa)
              || s.tacGia.ToLower().Contains(tukhoa)
              || s.nhaXuatBan.ToLower().Contains(tukhoa)
              || s.theLoai.tentheLoai.ToLower().Contains(tukhoa)
          )
          .Select(s => new SachDTO
          {
            IdSach = s.IdSach,
            TenSach = s.tenSach,
            TacGia = s.tacGia,
            NhaXuatBan = s.nhaXuatBan,
            MoTa = s.moTa,
            TinhTrang = s.tinhTrang == TinhTrangSach.coSan ? "Có sẵn" : "Không có sẵn",
            TheLoai = s.theLoai.tentheLoai,
            SoLuong = s.soLuong,
            HinhAnhPath = s.hinhAnh,
          })
          .ToList();
    }



    public bool AddSach(Sach sach)
    {
      try
      {
        db.Sachs.Add(sach);
        db.SaveChanges();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public bool UpdateSach(Sach sach)//
    {
      try
      {
        db.SaveChanges();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public bool DeleteSach(int idSach)
    {
      try
      {
        var sach = db.Sachs.Find(idSach);
        if (sach == null) return false;

        db.Sachs.Remove(sach);
        db.SaveChanges();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public List<SachDTO> GetSachCoTheChoMuon(string tukhoa) // user
    {
        return db.Sachs
            .Where(s =>
                ( s.tenSach.ToLower().Contains(tukhoa)
                || s.tacGia.ToLower().Contains(tukhoa)
                || s.nhaXuatBan.ToLower().Contains(tukhoa)
                || s.theLoai.tentheLoai.ToLower().Contains(tukhoa) )
                && s.tinhTrang == TinhTrangSach.coSan && s.soLuong > 0
            )
            .Select(s => new SachDTO
            {
                IdSach = s.IdSach,
                TenSach = s.tenSach,
                TacGia = s.tacGia,
                NhaXuatBan = s.nhaXuatBan,
                MoTa = s.moTa,
                TinhTrang = "Có sẵn" ,
                TheLoai = s.theLoai.tentheLoai,
                SoLuong = s.soLuong,
                HinhAnhPath = s.hinhAnh,
            })
            .ToList();
        }
    }
}