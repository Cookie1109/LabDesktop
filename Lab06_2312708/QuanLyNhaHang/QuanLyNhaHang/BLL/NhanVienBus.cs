using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.BLL
{
    public class NhanVienBus
    {
        private static NhanVienBus _instance;
        public static NhanVienBus Instance
        {
            get { if (_instance == null) _instance = new NhanVienBus(); return _instance; }
        }

        private NhanVienBus() { }

        public List<NhanVien> GetAllNhanVien()
        {
            return NhanVienDAO.Instance.GetAllNhanVien();
        }

        public int InsertNhanVien(string tenNV, string gioiTinh, string sdt, string chucVu, string taiKhoan, string matKhau)
        {
            return NhanVienDAO.Instance.InsertNhanVien(tenNV, gioiTinh, sdt, chucVu, taiKhoan, matKhau);
        }

        public bool UpdateNhanVien(int maNV, string tenNV, string gioiTinh, string sdt, string chucVu)
        {
            return NhanVienDAO.Instance.UpdateNhanVien(maNV, tenNV, gioiTinh, sdt, chucVu);
        }

        public NhanVien GetNhanVienByMaNV(int maNV)
        {
            return NhanVienDAO.Instance.GetNhanVienByMaNV(maNV);
        }
    }
}
