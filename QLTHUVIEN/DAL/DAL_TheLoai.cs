using System;
using System.Collections.Generic;
using System.Linq;
using QLTHUVIEN.DTO;

namespace QLTHUVIEN.DAL
{
  public class DAL_TheLoai
  {
    private readonly QLTV db;

    public DAL_TheLoai()
    {
      db = new QLTV();
    }

    public List<TheLoaiDTO> GetAll()
    {
      return db.theLoais
          .Select(t => new TheLoaiDTO
          {
            IdTheLoai = t.IdTheLoai,
            TenTheLoai = t.tentheLoai
          })
          .ToList();
    }

    public TheLoaiDTO GetById(int id)
    {
      var theloai = db.theLoais.Find(id);
      if (theloai == null) return null;

      return new TheLoaiDTO
      {
        IdTheLoai = theloai.IdTheLoai,
        TenTheLoai = theloai.tentheLoai
      };
    }

    public List<TheLoaiDTO> SearchTheLoai(string searchText)
    {
      searchText = searchText?.Trim().ToLower() ?? string.Empty;
      return db.theLoais
          .Where(t => string.IsNullOrEmpty(searchText) || t.tentheLoai.ToLower().Contains(searchText))
          .Select(t => new TheLoaiDTO
          {
            IdTheLoai = t.IdTheLoai,
            TenTheLoai = t.tentheLoai
          })
          .ToList();
    }

    public bool AddTheLoai(TheLoai theloai)//
    {
      try
      {
        db.theLoais.Add(theloai);
        db.SaveChanges();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public bool UpdateTheLoai(TheLoai theloai)
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

    public bool DeleteTheLoai(int id)//
    {
      try
      {
        var theloai = db.theLoais.Find(id);
        if (theloai == null) return false;

        db.theLoais.Remove(theloai);
        db.SaveChanges();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public TheLoai GetTheLoaiEntity(int id)//
    {
      return db.theLoais.Find(id);
    }
  }
}