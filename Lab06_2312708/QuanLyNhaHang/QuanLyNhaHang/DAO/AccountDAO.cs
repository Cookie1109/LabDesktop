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
    public class AccountDAO
    {
        private static AccountDAO _instance;
        public static AccountDAO Instance
        {
            get { if (_instance == null) _instance = new AccountDAO(); return _instance; }
        }

        private AccountDAO() { }

        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            DataTable data = DataProvider.Instance.ExcuteStoredProcedure("Account_GetAll");
            
            foreach (DataRow row in data.Rows)
            {
                Account account = new Account
                {
                    AccountID = Convert.ToInt32(row["AccountID"]),
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    Username = row["Username"].ToString().Trim(),
                    Password = row["Password"].ToString().Trim(),
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    RoleName = row["RoleName"].ToString().Trim(),
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    TenNV = row["TenNV"].ToString().Trim(),
                    GioiTinh = row["GioiTinh"].ToString().Trim(),
                    SDT = row["SDT"].ToString().Trim()
                };
                accounts.Add(account);
            }
            
            return accounts;
        }

        public Account Login(string username, string password)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            
            DataTable data = DataProvider.Instance.ExcuteStoredProcedure("Account_Login", parameters);
            
            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new Account
                {
                    AccountID = Convert.ToInt32(row["AccountID"]),
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    Username = row["Username"].ToString().Trim(),
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    RoleName = row["RoleName"].ToString().Trim(),
                    TenNV = row["TenNV"].ToString().Trim()
                };
            }
            
            return null;
        }

        public int Register(int maNV, string username, string password, int roleID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password),
                new SqlParameter("@RoleID", roleID)
            };
            
            DataTable result = DataProvider.Instance.ExcuteStoredProcedure("Account_Register", parameters);
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["Result"]);
            }
            return 0;
        }

        public int UpdateAccount(int maNV, string username, string password, int roleID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password),
                new SqlParameter("@RoleID", roleID)
            };
            
            DataTable result = DataProvider.Instance.ExcuteStoredProcedure("Account_Update", parameters);
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["Result"]);
            }
            return 0;
        }

        public bool DeleteAccount(int maNV)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", maNV)
            };
            
            DataTable result = DataProvider.Instance.ExcuteStoredProcedure("Account_Delete", parameters);
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["Result"]) == 1;
            }
            return false;
        }

        public Account GetAccountByMaNV(int maNV)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", maNV)
            };
            
            DataTable data = DataProvider.Instance.ExcuteStoredProcedure("Account_GetByMaNV", parameters);
            
            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new Account
                {
                    AccountID = Convert.ToInt32(row["AccountID"]),
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    Username = row["Username"].ToString().Trim(),
                    Password = row["Password"].ToString().Trim(),
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    RoleName = row["RoleName"].ToString().Trim(),
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                };
            }
            
            return null;
        }
    }
}
