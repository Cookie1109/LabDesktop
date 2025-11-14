using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Basic_Command
{
    public static class SessionManager
    {
        public static int AccountID { get; set; }
        public static string Username { get; set; }
        public static string DisplayName { get; set; }
        public static bool IsLoggedIn { get; set; }

        public static void Login(int accountID, string username, string displayName)
        {
            AccountID = accountID;
            Username = username;
            DisplayName = displayName;
            IsLoggedIn = true;
        }

        public static void Logout()
        {
            AccountID = 0;
            Username = string.Empty;
            DisplayName = string.Empty;
            IsLoggedIn = false;
        }

        public static string GetUserInfo()
        {
            if (IsLoggedIn)
            {
                return $"{DisplayName} ({Username})";
            }
            return "Chưa đăng nhập";
        }
    }
}
