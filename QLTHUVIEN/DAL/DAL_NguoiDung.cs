using System;
using System.Collections.Generic;
using System.Linq;
using QLTHUVIEN.DTO;
using QLTHUVIEN.Utils;

namespace QLTHUVIEN.DAL
{
  public class DAL_NguoiDung
  {
    private readonly QLTV db;

    public DAL_NguoiDung()
    {
      db = new QLTV();
    }

    public NguoiDung GetByUsername(string username)//
    {
      return db.nguoiDungs.FirstOrDefault(u => u.tenTK == username);
    }

    public NguoiDung GetById(int id) //
    {
      return db.nguoiDungs.FirstOrDefault(u => u.IdNguoiDung == id);
        }

    public bool CheckUsernameExists(string username)//
    {
      return db.nguoiDungs.Any(u => u.tenTK == username);
    }

    public void Add(NguoiDung nguoiDung)//
    {
      db.nguoiDungs.Add(nguoiDung);
      db.SaveChanges();
    }

    public void Update(NguoiDung nguoiDung)
    {
      db.SaveChanges();
    }

    public void Delete(int id)//
    {
      var nguoiDung = db.nguoiDungs.Find(id);
      if (nguoiDung != null)
      {
        db.nguoiDungs.Remove(nguoiDung);
        db.SaveChanges();
      }
    }
    public List<NguoiDungDTO> GetAllNguoiDung(string txtTimKiem)//
    {
        return db.nguoiDungs
            .Where(nd =>
                    nd.tenNguoiDung.Contains(txtTimKiem)
                    || nd.tenTK.Contains(txtTimKiem)
                    )
            .Select(nd => new NguoiDungDTO
            {
                IdNguoiDung = nd.IdNguoiDung,
                TenNguoiDung = nd.tenNguoiDung,
                TenTK = nd.tenTK,
                phanQuyen = nd.phanQuyen == PhanQuyenNguoiDung.nguoiMuon ? "Người mượn" : "Quản trị viên",
            }).ToList();
        }
    }
}