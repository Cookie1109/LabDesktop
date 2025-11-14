using QuanLyNhaHang.DTO;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    public class LoaiMonAnDAO
    {
        private static LoaiMonAnDAO _instance;
        public static LoaiMonAnDAO Instance
        {
            get { if (_instance == null) _instance = new LoaiMonAnDAO(); return _instance; }
        }
        private LoaiMonAnDAO() { }

        public List<LoaiMonAn> GetAllLoaiMonAn()
        {
            string procName = "LoaiMonAn_GetAll";
            DataTable data = DataProvider.Instance.ExcuteStoredProcedure(procName);
            List<LoaiMonAn> dsLoai = new List<LoaiMonAn>();
            foreach (DataRow row in data.Rows)
            {
                dsLoai.Add(new LoaiMonAn(row));
            }
            return dsLoai;
        }

        public bool IsLoaiMonAnExist(string tenLoai)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM LoaiMonAn WHERE TenLoai = @TenLoai";
                var parameters = new SqlParameter[]
                {
                new SqlParameter("@TenLoai", tenLoai)
                };
                DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);
                if (data.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(data.Rows[0][0]);
                    return count > 0;
                }
                return false;
            }
            catch {return false;}
        }

        public bool InsertLoaiMonAn(LoaiMonAn loai)
        {
            try
            {
                string procName = "LoaiMonAn_Insert";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@TenLoai", loai.TenLoai),
                    new SqlParameter("@Loai", loai.Loai)
                };
                int result = DataProvider.Instance.ExecuteNonQueryStoredProcedure(procName, parameters);
                return IsLoaiMonAnExist(loai.TenLoai);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi Insert: " + ex.Message);
                System.Windows.Forms.MessageBox.Show($"Lỗi: " + ex.Message, "Debug", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return false;
            }
        }

        public bool UpdateLoaiMonAn(LoaiMonAn loai)
        {
            try
            {
                string procName = "LoaiMonAn_Update";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaLoai", loai.MaLoai),
                    new SqlParameter("@TenLoai", loai.TenLoai.Trim()),
                    new SqlParameter("@Loai", loai.Loai.Trim())
                };
                int result = DataProvider.Instance.ExecuteNonQueryStoredProcedure(procName, parameters);
                return result>0;
            }
            catch 
            {
                return false;
            }
        }

        public bool DeleteLoaiMonAn(int maLoai)
        {
            try
            {
                string procName = "LoaiMonAn_Delete";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaLoai", maLoai)
                };
                int result = DataProvider.Instance.ExecuteNonQueryStoredProcedure(procName, parameters);
                return result>0;
            }
            catch 
            {
                return false;
            }
        }
    }
}
