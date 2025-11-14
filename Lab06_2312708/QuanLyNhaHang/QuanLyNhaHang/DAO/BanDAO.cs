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
    public class BanDAO
    {
        private static BanDAO _instance;
        public static BanDAO Instance
        {
            get { if (_instance == null) _instance = new BanDAO(); return _instance; }
        }
        private BanDAO() { }

        public List<Ban> GetAllBan()
        {
            string procName = "Ban_GetAll";
            DataTable data = DataProvider.Instance.ExcuteStoredProcedure(procName);
            List<Ban> dsBan = new List<Ban>();
            foreach (DataRow row in data.Rows)
            {
                dsBan.Add(new Ban(row));
            }
            return dsBan;
        }
        public bool IsBanExist(int maBan)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Ban WHERE MaBan = @MaBan";
                var parameters = new SqlParameter[]
                {
                new SqlParameter("@MaBan", maBan)
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
        public bool InsertBan(Ban ban)
        {
            try
            {
                string procName = "Ban_Insert";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SoTang", ban.SoTang),
                    new SqlParameter("@TenBan", ban.TenBan)
                };
                int result = DataProvider.Instance.ExecuteNonQueryStoredProcedure(procName, parameters);
                return result > 0;
            }
            catch { return false; }
        }
        public bool DeleteBan(int maBan)
        {
            try
            {
                string procName = "Ban_Delete";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaBan", maBan)
                };
                int result = DataProvider.Instance.ExecuteNonQueryStoredProcedure(procName, parameters);
                return result > 0;
            }
            catch { return false; }
        }
    }
}
