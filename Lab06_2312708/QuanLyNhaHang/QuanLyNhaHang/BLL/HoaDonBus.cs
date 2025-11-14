using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.BLL
{
    public class HoaDonBus
    {
        public bool LuuHoaDon(HoaDon hoaDon)
        {
            return DAO.HoaDonDAO.Instance.LuuHoaDon(hoaDon);
        }

        public List<HoaDon> LayTatCa()
        {
            return DAO.HoaDonDAO.Instance.GetAllHoaDon();
        }

        public List<HoaDon> LayTheoNgay(DateTime ngay)
        {
            return DAO.HoaDonDAO.Instance.GetHoaDonByDate(ngay);
        }

        public List<HoaDon> LayTheoThang(int thang, int nam)
        {
            return DAO.HoaDonDAO.Instance.GetHoaDonByMonth(thang, nam);
        }

        public List<HoaDon> LayTheoNam(int nam)
        {
            return DAO.HoaDonDAO.Instance.GetHoaDonByYear(nam);
        }
    }
}