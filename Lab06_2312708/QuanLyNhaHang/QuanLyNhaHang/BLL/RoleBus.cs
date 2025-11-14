using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.BLL
{
    public class RoleBus
    {
        private static RoleBus _instance;
        public static RoleBus Instance
        {
            get { if (_instance == null) _instance = new RoleBus(); return _instance; }
        }

        private RoleBus() { }

        public List<Role> GetAllRoles()
        {
            return RoleDAO.Instance.GetAllRoles();
        }

        public bool InsertRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return false;
                
            int result = RoleDAO.Instance.InsertRole(roleName);
            return result > 0;
        }

        public bool DeleteRole(int roleID)
        {
            return RoleDAO.Instance.DeleteRole(roleID);
        }
    }
}
