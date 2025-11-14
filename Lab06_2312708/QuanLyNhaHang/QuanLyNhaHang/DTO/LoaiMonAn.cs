using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class LoaiMonAn
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string Loai { get; set; }

        public LoaiMonAn()
        {
        }

        public LoaiMonAn(int maLoai, string tenLoai, string loai)
        {
            this.MaLoai = maLoai;
            this.TenLoai = tenLoai;
            this.Loai = loai;
        }

        public LoaiMonAn(DataRow row)
        {
            this.MaLoai = Convert.ToInt32(row["MaLoai"]);
            this.TenLoai = row["TenLoai"].ToString();
            this.Loai = row["Loai"].ToString();
        }
    }
}
