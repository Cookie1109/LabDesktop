using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class MonAn
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public int MaLoai { get; set; }
        public decimal DonGia { get; set; }
        public string DonViTinh { get; set; }
        public string GhiChu { get; set; }

        public MonAn()
        {
        }

        public MonAn(int maMon, string tenMon, int maLoai, decimal donGia, string donViTinh, string ghiChu)
        {
            this.MaMon = maMon;
            this.TenMon = tenMon;
            this.MaLoai = maLoai;
            this.DonGia = donGia;
            this.DonViTinh = donViTinh;
            this.GhiChu = ghiChu;
        }

        public MonAn(DataRow row)
        {
            this.MaMon = Convert.ToInt32(row["MaMon"]);
            this.TenMon = row["TenMon"].ToString();
            this.MaLoai = Convert.ToInt32(row["MaLoai"]);
            this.DonGia = Convert.ToDecimal(row["DonGia"]);
            this.DonViTinh = row["DonViTinh"].ToString();
            this.GhiChu = row["GhiChu"] != DBNull.Value ? row["GhiChu"].ToString() : string.Empty;
        }
    }
}
