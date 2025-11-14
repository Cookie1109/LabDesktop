using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class HoaDon
    {
        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public int MaNV { get; set; }
        public int MaBan { get; set; }
        public decimal TongTien { get; set; }
        public int GiamGia { get; set; }
        public decimal ThanhToan { get; set; }
        public List<ChiTietHoaDon> DSChiTiet { get; set; }

        public HoaDon()
        {
        }

        public HoaDon(int maHD, DateTime ngayLap, int maNV, int maBan, decimal tongTien, int giamGia, decimal thanhToan)
        {
            this.MaHD = maHD;
            this.NgayLap = ngayLap;
            this.MaNV = maNV;
            this.MaBan = maBan;
            this.TongTien = tongTien;
            this.GiamGia = giamGia;
            this.ThanhToan = thanhToan;
            DSChiTiet = new List<ChiTietHoaDon>();
        }

        public HoaDon(DataRow row)
        {
            this.MaHD = Convert.ToInt32(row["MaHD"]);
            this.NgayLap = Convert.ToDateTime(row["NgayLap"]);
            this.MaNV = Convert.ToInt32(row["MaNV"]);
            this.MaBan = Convert.ToInt32(row["MaBan"]);
            this.TongTien = Convert.ToDecimal(row["TongTien"]);
            this.GiamGia = Convert.ToInt32(row["GiamGia"]);
            this.ThanhToan = Convert.ToDecimal(row["ThanhToan"]);
            DSChiTiet = new List<ChiTietHoaDon>();
        }
    }
}
