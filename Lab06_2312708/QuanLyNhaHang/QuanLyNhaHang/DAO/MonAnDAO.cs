using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.DAO
{
    public class MonAnDAO
    {
        private static MonAnDAO _instance;
        public static MonAnDAO Instance
        {
            get { if (_instance == null) _instance = new MonAnDAO(); return _instance; }
        }
        private MonAnDAO() { }

        public List<MonAn> GetAllMonAn()
        {
            string procName = "MonAn_GetAll";
            DataTable data = DataProvider.Instance.ExcuteStoredProcedure(procName);
            List<MonAn> dsMonAn = new List<MonAn>();
            foreach (DataRow row in data.Rows)
            {
                dsMonAn.Add(new MonAn(row));
            }
            return dsMonAn;
        }

        public List<MonAn> GetMonAnByLoai(int maLoai)
        {
            string procName = "MonAn_GetByLoai";
            SqlParameter[] parameters =
            {
                new SqlParameter("@MaLoai", maLoai)
            };
            DataTable data = DataProvider.Instance.ExcuteStoredProcedure(procName, parameters);
            List<MonAn> dsMonAn = new List<MonAn>();
            foreach (DataRow row in data.Rows)
            {
                dsMonAn.Add(new MonAn(row));
            } 
            return dsMonAn;
        }

        public MonAn GetMonAnById(int maMon)
        {
            try
            {
                string query = "SELECT * FROM MonAn WHERE MaMon = @MaMon";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaMon", maMon)
                };
                DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);
                if (data.Rows.Count > 0)
                {
                    return new MonAn(data.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi GetMonAnById: " + ex.Message);
                return null;
            }
        }

        public bool IsMonAnExist(string tenMon)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM MonAn WHERE TenMon = @TenMon";
                var parameters = new SqlParameter[]
                {
                new SqlParameter("@TenMon", tenMon)
                };
                DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);
                if (data.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(data.Rows[0][0]);
                    return count > 0;
                }
                return false;
            }
            catch { return false; }
        }

        public bool InsertMonAn(MonAn monAn)
        {
            try
            {
                string procName = "MonAn_Insert";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@TenMon", monAn.TenMon),
                    new SqlParameter("@MaLoai", monAn.MaLoai),
                    new SqlParameter("@DonGia", monAn.DonGia),
                    new SqlParameter("@DonViTinh", monAn.DonViTinh),
                    new SqlParameter("@GhiChu", monAn.GhiChu)
                };
                int result = DataProvider.Instance.ExecuteNonQueryStoredProcedure(procName, parameters);
                return IsMonAnExist(monAn.TenMon);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Insert: " + ex.Message);
                System.Windows.Forms.MessageBox.Show($"Lỗi: " + ex.Message, "Debug", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return false;
            }
        }

        public bool UpdateMonAn(MonAn monAn)
        {
            try
            {
                string procName = "MonAn_Update";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaMon", monAn.MaMon),
                    new SqlParameter("@TenMon", monAn.TenMon),
                    new SqlParameter("@DonGia", monAn.DonGia),
                    new SqlParameter("@DonViTinh", monAn.DonViTinh),
                    new SqlParameter("@GhiChu", monAn.GhiChu)
                };
                int result = DataProvider.Instance.ExecuteNonQueryStoredProcedure(procName, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Update: " + ex.Message);
                System.Windows.Forms.MessageBox.Show($"Lỗi: " + ex.Message, "Debug", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return false;
            }
        }

        public bool DeleteMonAn(int maMon, int maLoai)
        {
            try
            {
                string procName = "MonAn_Delete";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaMon", maMon),
                    new SqlParameter("@MaLoai", maLoai)
                };
                int result = DataProvider.Instance.ExecuteNonQueryStoredProcedure(procName, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Delete: " + ex.Message);
                System.Windows.Forms.MessageBox.Show($"Lỗi: " + ex.Message, "Debug", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return false;
            }
        }
    }
}
