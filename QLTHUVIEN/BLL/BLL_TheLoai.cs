using System;
using System.Linq;
using System.Collections.Generic;
using QLTHUVIEN.DAL;
using QLTHUVIEN.DTO;

namespace QLTHUVIEN.BLL
{
  public class BLL_TheLoai
  {
    private readonly DAL_TheLoai dalTheLoai;

    public BLL_TheLoai()
    {
      dalTheLoai = new DAL_TheLoai();
    }

    public List<TheLoaiDTO> GetAll()
    {
      return dalTheLoai.GetAll();
    }

    public TheLoaiDTO GetById(int id)
    {
      return dalTheLoai.GetById(id);
    }

    public List<TheLoaiDTO> SearchTheLoai(string searchText)
    {
      return dalTheLoai.SearchTheLoai(searchText);
    }

    public bool AddTheLoai(TheLoaiDTO theLoaiDTO)//
    {
      try
      {
        var theloai = new TheLoai
        {
          tentheLoai = theLoaiDTO.TenTheLoai
        };
        return dalTheLoai.AddTheLoai(theloai);
      }
      catch (Exception)
      {
        return false;
      }
    }

    public bool UpdateTheLoai(TheLoaiDTO theLoaiDTO)//
    {
      try
      {
        var theloai = dalTheLoai.GetTheLoaiEntity(theLoaiDTO.IdTheLoai);
        if (theloai == null) return false;

        theloai.tentheLoai = theLoaiDTO.TenTheLoai;
        return dalTheLoai.UpdateTheLoai(theloai);
      }
      catch (Exception)
      {
        return false;
      }
    }

    public bool DeleteTheLoai(int id)//
    {
      return dalTheLoai.DeleteTheLoai(id);
    }
  }
}