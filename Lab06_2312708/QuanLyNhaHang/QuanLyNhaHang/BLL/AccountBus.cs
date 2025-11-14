using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang.BLL
{
    public class AccountBus
    {
        private static AccountBus _instance;
        public static AccountBus Instance
        {
            get { if (_instance == null) _instance = new AccountBus(); return _instance; }
        }

        private AccountBus() { }

        public List<Account> GetAllAccounts()
        {
            return AccountDAO.Instance.GetAllAccounts();
        }

        public Account Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;
                
            return AccountDAO.Instance.Login(username, password);
        }

        public string Register(int maNV, string username, string password, string confirmPassword, int roleID)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(username))
                return "Vui lòng nhập tên đăng nhập!";
                
            if (string.IsNullOrWhiteSpace(password))
                return "Vui lòng nhập mật khẩu!";
                
            if (password != confirmPassword)
                return "Mật khẩu xác nhận không khớp!";
                
            int result = AccountDAO.Instance.Register(maNV, username, password, roleID);
            
            if (result == -1)
                return "Tên đăng nhập đã tồn tại!";
            else if (result == -2)
                return "Nhân viên này đã có tài khoản!";
            else if (result > 0)
                return "SUCCESS";
            else
                return "Đăng ký thất bại!";
        }

        public bool UpdateAccount(int maNV, string username, string password, int roleID)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;
                
            int result = AccountDAO.Instance.UpdateAccount(maNV, username, password, roleID);
            return result > 0;
        }

        public bool DeleteAccount(int maNV)
        {
            return AccountDAO.Instance.DeleteAccount(maNV);
        }

        public Account GetAccountByMaNV(int maNV)
        {
            return AccountDAO.Instance.GetAccountByMaNV(maNV);
        }
    }
}
