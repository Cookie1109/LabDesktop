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
    public class RoleDAO
    {
        private static RoleDAO _instance;
        public static RoleDAO Instance
        {
            get { if (_instance == null) _instance = new RoleDAO(); return _instance; }
        }

        private RoleDAO() { }

        public List<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();
            DataTable data = DataProvider.Instance.ExcuteStoredProcedure("Role_GetAll");
            
            foreach (DataRow row in data.Rows)
            {
                Role role = new Role
                {
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    RoleName = row["RoleName"].ToString().Trim()
                };
                roles.Add(role);
            }
            
            return roles;
        }

        public int InsertRole(string roleName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@RoleName", roleName)
            };
            
            return DataProvider.Instance.ExecuteScalarStoredProcedure("Role_Insert", parameters);
        }

        public bool DeleteRole(int roleID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@RoleID", roleID)
            };
            
            DataTable result = DataProvider.Instance.ExcuteStoredProcedure("Role_Delete", parameters);
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["Success"]) == 1;
            }
            return false;
        }
    }
}
