using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaHang.BLL;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            LoadRoles();
            cboGioiTinh.SelectedIndex = 0;
        }

        private void LoadRoles()
        {
            try
            {
                List<Role> roles = RoleBus.Instance.GetAllRoles();
                cboRole.DataSource = roles;
                cboRole.DisplayMember = "RoleName";
                cboRole.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chức vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string tenNV = txtName.Text.Trim();
                string gioiTinh = cboGioiTinh.SelectedItem?.ToString();
                string sdt = txtSDT.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string confirmPassword = txtConfirmPassword.Text.Trim();

                // Validate input
                if (string.IsNullOrEmpty(tenNV))
                {
                    MessageBox.Show("Vui lòng nhập họ và tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(gioiTinh))
                {
                    MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboGioiTinh.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(sdt))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }

                if (cboRole.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboRole.Focus();
                    return;
                }

                int roleID = Convert.ToInt32(cboRole.SelectedValue);
                string roleName = cboRole.Text;

                // Bước 1: Tạo nhân viên mới
                int maNV = NhanVienBus.Instance.InsertNhanVien(tenNV, gioiTinh, sdt, roleName, username, password);

                if (maNV > 0)
                {
                    // Bước 2: Tạo tài khoản cho nhân viên
                    string result = AccountBus.Instance.Register(maNV, username, password, confirmPassword, roleID);

                    if (result == "SUCCESS")
                    {
                        MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không thể tạo nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
