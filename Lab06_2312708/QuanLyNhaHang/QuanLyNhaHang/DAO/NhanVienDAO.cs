using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO _instance;
        public static NhanVienDAO Instance
        {
            get { if (_instance == null) _instance = new NhanVienDAO(); return _instance; }
        }

        private NhanVienDAO() { }

        public List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> nhanViens = new List<NhanVien>();
            DataTable data = DataProvider.Instance.ExcuteStoredProcedure("NhanVien_GetAll");
            
            foreach (DataRow row in data.Rows)
            {
                NhanVien nv = new NhanVien
                {
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    TenNV = row["TenNV"].ToString().Trim(),
                    GioiTinh = row["GioiTinh"].ToString().Trim(),
                    SDT = row["SDT"].ToString().Trim(),
                    ChucVu = row["ChucVu"].ToString().Trim(),
                    TaiKhoan = row["TaiKhoan"].ToString().Trim(),
                    MatKhau = row["MatKhau"].ToString().Trim()
                };
                nhanViens.Add(nv);
            }
            
            return nhanViens;
        }

        public int InsertNhanVien(string tenNV, string gioiTinh, string sdt, string chucVu, string taiKhoan, string matKhau)
        {
            string query = "INSERT INTO NhanVien(TenNV, GioiTinh, SDT, ChucVu, TaiKhoan, MatKhau) " +
                          "VALUES (@TenNV, @GioiTinh, @SDT, @ChucVu, @TaiKhoan, @MatKhau); " +
                          "SELECT SCOPE_IDENTITY();";
            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TenNV", tenNV),
                new SqlParameter("@GioiTinh", gioiTinh),
                new SqlParameter("@SDT", sdt),
                new SqlParameter("@ChucVu", chucVu),
                new SqlParameter("@TaiKhoan", taiKhoan),
                new SqlParameter("@MatKhau", matKhau)
            };
            
            DataTable result = DataProvider.Instance.ExecuteQuery(query, parameters);
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0][0]);
            }
            return 0;
        }

        public bool UpdateNhanVien(int maNV, string tenNV, string gioiTinh, string sdt, string chucVu)
        {
            string query = "UPDATE NhanVien SET TenNV = @TenNV, GioiTinh = @GioiTinh, SDT = @SDT, ChucVu = @ChucVu " +
                          "WHERE MaNV = @MaNV";
            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@TenNV", tenNV),
                new SqlParameter("@GioiTinh", gioiTinh),
                new SqlParameter("@SDT", sdt),
                new SqlParameter("@ChucVu", chucVu)
            };
            
            DataTable result = DataProvider.Instance.ExecuteQuery(query, parameters);
            return true;
        }

        public NhanVien GetNhanVienByMaNV(int maNV)
        {
            string query = "SELECT * FROM NhanVien WHERE MaNV = @MaNV";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", maNV)
            };
            
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);
            
            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new NhanVien
                {
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    TenNV = row["TenNV"].ToString().Trim(),
                    GioiTinh = row["GioiTinh"].ToString().Trim(),
                    SDT = row["SDT"].ToString().Trim(),
                    ChucVu = row["ChucVu"].ToString().Trim(),
                    TaiKhoan = row["TaiKhoan"].ToString().Trim(),
                    MatKhau = row["MatKhau"].ToString().Trim()
                };
            }
            
            return null;
        }
    }
}
