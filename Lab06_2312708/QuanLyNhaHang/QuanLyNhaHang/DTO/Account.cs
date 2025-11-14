using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class Account
    {
        public int AccountID { get; set; }
        public int MaNV { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        
        // Thông tin nhân viên
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }

        public Account()
        {
        }

        public Account(int accountID, int maNV, string username, string password, int roleID, string roleName, bool isActive, DateTime createdDate)
        {
            this.AccountID = accountID;
            this.MaNV = maNV;
            this.Username = username;
            this.Password = password;
            this.RoleID = roleID;
            this.RoleName = roleName;
            this.IsActive = isActive;
            this.CreatedDate = createdDate;
        }
    }
}
