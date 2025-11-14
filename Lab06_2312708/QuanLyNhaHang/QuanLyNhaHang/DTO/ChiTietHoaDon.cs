using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class ChiTietHoaDon
    {
        public int MaHD { get; set; }
        public int MaMon { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public ChiTietHoaDon()
        {
        }
        public ChiTietHoaDon(int maHD, int maMon, int soLuong, decimal donGia, decimal thanhTien)
        {
            this.MaHD = maHD;
            this.MaMon = maMon;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.ThanhTien = thanhTien;
        }

        public ChiTietHoaDon(DataRow row)
        {
            this.MaHD = Convert.ToInt32(row["MaHD"]);
            this.MaMon = Convert.ToInt32(row["MaMon"]);
            this.SoLuong = Convert.ToInt32(row["SoLuong"]);
            this.DonGia = Convert.ToDecimal(row["DonGia"]);
            this.ThanhTien = Convert.ToDecimal(row["ThanhTien"]);
        }
    }
}
