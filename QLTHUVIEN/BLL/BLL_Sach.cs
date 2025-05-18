using System;
using System.Collections.Generic;
using System.Linq;
using QLTHUVIEN.DAL;
using QLTHUVIEN.DTO;

namespace QLTHUVIEN.BLL
{
    public class BLL_Sach
    {
        private readonly DAL_Sach dalSach;

        public BLL_Sach()
        {
            dalSach = new DAL_Sach();
        }

        public List<Sach> GetAllSach()
        {
            return dalSach.GetAllSach();
        }

        public List<SachDTO> SearchSach(string tukhoa)
        {
            return dalSach.SearchSach(tukhoa);
        }

        public List<Sach> GetSachByTheLoai(int idTheLoai)
        {
            if (idTheLoai == 0) 
                return GetAllSach();

            return dalSach.GetSachByTheLoai(idTheLoai);
        }

        public bool AddSach(SachCreateDTO sachDTO) //
        {
            if (string.IsNullOrEmpty(sachDTO.TenSach))
                return false;

            try
            {
                var sach = new Sach
                {
                    tenSach = sachDTO.TenSach,
                    tacGia = sachDTO.TacGia,
                    nhaXuatBan = sachDTO.NhaXuatBan,
                    moTa = sachDTO.MoTa,
                    IdTheLoai = sachDTO.IdTheLoai,
                    soLuong = sachDTO.SoLuong,
                    hinhAnh = sachDTO.HinhAnh,
                    tinhTrang = TinhTrangSach.coSan
                };

                return dalSach.AddSach(sach);
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateSach(SachCreateDTO sachDTO) //
        {
            if (!sachDTO.IdSach.HasValue)
                return false;

            try
            {
                var sach = dalSach.GetSachById(sachDTO.IdSach.Value);
                if (sach == null) return false;

                sach.tenSach = sachDTO.TenSach;
                sach.tacGia = sachDTO.TacGia;
                sach.nhaXuatBan = sachDTO.NhaXuatBan;
                sach.moTa = sachDTO.MoTa;
                sach.IdTheLoai = sachDTO.IdTheLoai;
                sach.soLuong = sachDTO.SoLuong;
                sach.hinhAnh = sachDTO.HinhAnh;

                return dalSach.UpdateSach(sach);
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSach(int idSach)
        {
            return dalSach.DeleteSach(idSach);
        }

        public List<SachDTO> GetSachCoTheChoMuon(string txtTimKiem)
        {
            return dalSach.GetSachCoTheChoMuon(txtTimKiem);
        }

        public Sach GetSachById(int id)//
        {
            return dalSach.GetSachById(id);
        }

        public SachCreateDTO GetSachForEdit(int idSach) //
        {
            var sach = dalSach.GetSachById(idSach);
            if (sach == null) return null;

            return new SachCreateDTO
            {
                IdSach = sach.IdSach,
                TenSach = sach.tenSach,
                TacGia = sach.tacGia,
                NhaXuatBan = sach.nhaXuatBan,
                MoTa = sach.moTa,
                IdTheLoai = sach.IdTheLoai,
                SoLuong = sach.soLuong,
                HinhAnh = sach.hinhAnh
            };
        }
    }
}