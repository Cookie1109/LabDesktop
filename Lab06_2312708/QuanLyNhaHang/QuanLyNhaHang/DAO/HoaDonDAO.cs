using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO _instance;
        public static HoaDonDAO Instance
        {
            get { if (_instance == null) _instance = new HoaDonDAO(); return _instance; }
        }
        private HoaDonDAO() { }

        public bool LuuHoaDon(HoaDon hoaDon)
        {
            try
            {
                string procName = "HoaDonThanhToan_INSERT";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaNV", hoaDon.MaNV),
                    new SqlParameter("@NgayLap", hoaDon.NgayLap),
                    new SqlParameter("@TongTien", hoaDon.TongTien),
                    new SqlParameter("@GiamGia", hoaDon.GiamGia),
                    new SqlParameter("@ThanhToan", hoaDon.ThanhToan),
                    new SqlParameter("@MaBan", hoaDon.MaBan)
                };
                
                int maHD = DataProvider.Instance.ExecuteScalarStoredProcedure(procName, parameters);
                
                if (maHD > 0)
                {
                    foreach (var chiTiet in hoaDon.DSChiTiet)
                    {
                        string chiTietProcName = "ChiTietHoaDon_INSERT";
                        SqlParameter[] chiTietParams =
                        {
                            new SqlParameter("@MaHD", maHD),
                            new SqlParameter("@MaMon", chiTiet.MaMon),
                            new SqlParameter("@SoLuong", chiTiet.SoLuong),
                            new SqlParameter("@DonGia", chiTiet.DonGia),
                            new SqlParameter("@ThanhTien", chiTiet.ThanhTien)
                        };
                        DataProvider.Instance.ExecuteNonQueryStoredProcedure(chiTietProcName, chiTietParams);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi lưu hóa đơn: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                throw new Exception($"Lỗi khi lưu hóa đơn: {ex.Message}", ex);
            }
        }

        public List<HoaDon> GetAllHoaDon()
        {
            try
            {
                string procName = "HoaDonThanhToan_GetAll";
                DataTable data = DataProvider.Instance.ExcuteStoredProcedure(procName);
                List<HoaDon> dsHoaDon = new List<HoaDon>();
                foreach (DataRow row in data.Rows)
                {
                    dsHoaDon.Add(new HoaDon(row));
                }
                return dsHoaDon;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetAllHoaDon: {ex.Message}");
                return new List<HoaDon>();
            }
        }

        public List<HoaDon> GetHoaDonByDate(DateTime ngay)
        {
            try
            {
                string procName = "HoaDonThanhToan_GetByDate";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Ngay", ngay.Date)
                };
                DataTable data = DataProvider.Instance.ExcuteStoredProcedure(procName, parameters);
                List<HoaDon> dsHoaDon = new List<HoaDon>();
                foreach (DataRow row in data.Rows)
                {
                    dsHoaDon.Add(new HoaDon(row));
                }
                return dsHoaDon;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetHoaDonByDate: {ex.Message}");
                return new List<HoaDon>();
            }
        }

        public List<HoaDon> GetHoaDonByMonth(int thang, int nam)
        {
            try
            {
                string procName = "HoaDonThanhToan_GetByMonth";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Thang", thang),
                    new SqlParameter("@Nam", nam)
                };
                DataTable data = DataProvider.Instance.ExcuteStoredProcedure(procName, parameters);
                List<HoaDon> dsHoaDon = new List<HoaDon>();
                foreach (DataRow row in data.Rows)
                {
                    dsHoaDon.Add(new HoaDon(row));
                }
                return dsHoaDon;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetHoaDonByMonth: {ex.Message}");
                return new List<HoaDon>();
            }
        }

        public List<HoaDon> GetHoaDonByYear(int nam)
        {
            try
            {
                string procName = "HoaDonThanhToan_GetByYear";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Nam", nam)
                };
                DataTable data = DataProvider.Instance.ExcuteStoredProcedure(procName, parameters);
                List<HoaDon> dsHoaDon = new List<HoaDon>();
                foreach (DataRow row in data.Rows)
                {
                    dsHoaDon.Add(new HoaDon(row));
                }
                return dsHoaDon;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetHoaDonByYear: {ex.Message}");
                return new List<HoaDon>();
            }
        }
    }
}