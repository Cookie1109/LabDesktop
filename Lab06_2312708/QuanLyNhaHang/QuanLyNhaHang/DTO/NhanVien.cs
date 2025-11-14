using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public string ChucVu { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public NhanVien()
        {
        }
        public NhanVien(int maNV, string tenNV, string gioiTinh, DateTime ngaySinh, string diaChi, string sDT, string chucVu, string taiKhoan, string matKhau)
        {
            this.MaNV = maNV;
            this.TenNV = tenNV;
            this.GioiTinh = gioiTinh;
            this.SDT = sDT;
            this.ChucVu = chucVu;
            this.TaiKhoan = taiKhoan;
            this.MatKhau = matKhau;
        }                                           
    }
}
