using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab_Basic_Command
{
    public partial class LoginForm : Form
    {
        private const string CONNECTION_STRING = @"server=.; database=Lab04Desktop; integrated security=true;";
        
        public int LoggedInAccountID { get; private set; }
        public string LoggedInUsername { get; private set; }
        public string LoggedInDisplayName { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "admin123";
            
            txtUsername.Focus();
            
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (ValidateLogin(username, password))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private bool ValidateLogin(string username, string password)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = @"
                SELECT ID, Username, DisplayName, IsActive
                FROM Account
                WHERE Username = @username AND Password = @password;
            ";

            sqlCommand.Parameters.AddWithValue("@username", username);
            sqlCommand.Parameters.AddWithValue("@password", password);

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    bool isActive = (bool)reader["IsActive"];
                    
                    if (!isActive)
                    {
                        MessageBox.Show("Tài khoản đã bị khóa. Vui lòng liên hệ quản trị viên!", 
                            "Tài khoản bị khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        reader.Close();
                        return false;
                    }

                    LoggedInAccountID = (int)reader["ID"];
                    LoggedInUsername = reader["Username"].ToString();
                    LoggedInDisplayName = reader["DisplayName"].ToString();

                    reader.Close();
                    return true;
                }

                reader.Close();
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
                e.Handled = true;
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
            }
        }
    }
}
