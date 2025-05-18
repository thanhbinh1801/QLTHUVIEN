using System;
using System.Collections.Generic;
using System.Linq;
using QLTHUVIEN.DAL;
using QLTHUVIEN.DTO;

namespace QLTHUVIEN.BLL
{
  public class BLL_MuonSach
  {
    private readonly DAL_MuonSach dalMuonSach;
    private readonly DAL_Sach dalSach;

    public BLL_MuonSach()
    {
      dalMuonSach = new DAL_MuonSach();
      dalSach = new DAL_Sach();
    }

    public List<MuonSach> GetMuonSachByUserId(int userId)
    {
      return dalMuonSach.GetMuonSachByUserId(userId);
    }

    public List<MuonSachDTO> GetSachDangMuon()//
    {
      return dalMuonSach.GetSachDangMuon();
    }

    public bool MuonSach(int userId, int sachId, DateTime ngayMuon, DateTime ngayTra)//
    {
      var sach = dalSach.GetSachById(sachId);
      if (sach == null || sach.tinhTrang != TinhTrangSach.coSan || sach.soLuong <= 0)
        return false;
      bool daMuonSachNay = dalMuonSach.GetMuonSachByUserId(userId)
          .Any(m => m.sach.tenSach == sach.tenSach && m.tinhTrangMuon == TinhTrangMuon.dangMuon);

      var sachDangMuon = dalMuonSach.GetMuonSachByUserId(userId)
          .Count(m => m.tinhTrangMuon == TinhTrangMuon.dangMuon);
      if (sachDangMuon >= 3 && daMuonSachNay) 
        return false;

      var muonSach = new MuonSach
      {
        IdSach = sachId,
        IdNguoiDung = userId,
        ngayMuon = ngayMuon,
        ngayTra = ngayTra,
        tinhTrangMuon = TinhTrangMuon.dangMuon
      };

      sach.soLuong--;
      if (sach.soLuong == 0)
        sach.tinhTrang = TinhTrangSach.khongCoSan;

      if (!dalSach.UpdateSach(sach))
        return false;

      return dalMuonSach.AddMuonSach(muonSach);
    }

    public bool TraSach(string tenSach)
    {
      var muonSach = dalMuonSach.GetAllMuonSach(tenSach);
      if (muonSach == null || muonSach.tinhTrangMuon != TinhTrangMuon.dangMuon)
      return false;

      if (!dalMuonSach.UpdateTinhTrangMuon(tenSach, TinhTrangMuon.daTra))
        return false;

      var sach = dalSach.GetSachById(muonSach.IdSach);
      if (sach != null)
      {
        sach.soLuong++;
        if (sach.tinhTrang == TinhTrangSach.khongCoSan)
          sach.tinhTrang = TinhTrangSach.coSan;

        return dalSach.UpdateSach(sach);
      }

      return true;
    }

    public List<MuonSachDTO> GetLichSuMuonTra(int? iduser) //
    {
      return dalMuonSach.GetLichSuMuonTra(iduser);
    }
  }
}