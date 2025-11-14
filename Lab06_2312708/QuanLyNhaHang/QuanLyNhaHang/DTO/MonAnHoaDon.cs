using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    // Class để hiển thị món ăn trong hóa đơn (dgvHoaDon)
    public class MonAnHoaDon
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien 
        { 
            get { return DonGia * SoLuong; }
        }

        public MonAnHoaDon()
        {
        }

        public MonAnHoaDon(int maMon, string tenMon, decimal donGia, int soLuong)
        {
            this.MaMon = maMon;
            this.TenMon = tenMon;
            this.DonGia = donGia;
            this.SoLuong = soLuong;
        }

        // Constructor từ MonAn
        public MonAnHoaDon(MonAn monAn, int soLuong = 1)
        {
            this.MaMon = monAn.MaMon;
            this.TenMon = monAn.TenMon;
            this.DonGia = monAn.DonGia;
            this.SoLuong = soLuong;
        }
    }
}
