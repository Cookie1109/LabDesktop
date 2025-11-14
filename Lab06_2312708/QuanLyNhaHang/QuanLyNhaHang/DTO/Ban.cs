using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class Ban
    {
        public int MaBan { get; set; }
        public int SoTang { get; set; }
        public string TenBan { get; set; }
        public int TrangThai { get; set; } // 0: Trống, 1: Có người
        public HoaDon HoaDonHienTai { get; set; }

        public Ban()
        {
            TrangThai = 0;
            HoaDonHienTai = null;
        }

        public Ban(int maBan, int soTang, string tenBan)
        {
            this.MaBan = maBan;
            this.SoTang = soTang;
            this.TenBan = tenBan;
            this.TrangThai = 0;
            this.HoaDonHienTai = null;
        }

        public Ban(DataRow row)
        {
            this.MaBan = Convert.ToInt32(row["MaBan"]);
            this.SoTang = Convert.ToInt32(row["SoTang"]);
            this.TenBan = row["TenBan"].ToString();
            this.TrangThai = row["TrangThai"] == DBNull.Value ? 0 : Convert.ToInt32(row["TrangThai"]);
            this.HoaDonHienTai = null;
        }
    }
}
