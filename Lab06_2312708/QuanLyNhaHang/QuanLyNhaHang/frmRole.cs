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
    public partial class frmRole : Form
    {
        public frmRole()
        {
            InitializeComponent();
        }

        private void frmRole_Load(object sender, EventArgs e)
        {
            LoadRoles();
        }

        private void LoadRoles()
        {
            try
            {
                List<Role> roles = RoleBus.Instance.GetAllRoles();
                
                DataTable dt = new DataTable();
                dt.Columns.Add("RoleID", typeof(int));
                dt.Columns.Add("Tên Vai Trò", typeof(string));
                
                foreach (var role in roles)
                {
                    dt.Rows.Add(role.RoleID, role.RoleName);
                }
                
                dataGridViewRoles.DataSource = dt;
                dataGridViewRoles.Columns["RoleID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách vai trò: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string roleName = txtRoleName.Text.Trim();
                
                if (string.IsNullOrEmpty(roleName))
                {
                    MessageBox.Show("Vui lòng nhập tên vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRoleName.Focus();
                    return;
                }

                bool success = RoleBus.Instance.InsertRole(roleName);
                
                if (success)
                {
                    MessageBox.Show("Thêm vai trò thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRoles();
                    txtRoleName.Clear();
                }
                else
                {
                    MessageBox.Show("Thêm vai trò thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewRoles.SelectedRows.Count > 0)
                {
                    int roleID = Convert.ToInt32(dataGridViewRoles.SelectedRows[0].Cells["RoleID"].Value);
                    string roleName = dataGridViewRoles.SelectedRows[0].Cells["Tên Vai Trò"].Value.ToString();
                    
                    DialogResult result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn xóa vai trò '{roleName}'?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        bool success = RoleBus.Instance.DeleteRole(roleID);
                        
                        if (success)
                        {
                            MessageBox.Show("Xóa vai trò thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadRoles();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Không thể xóa vai trò này!\nCó thể đang có tài khoản sử dụng vai trò này.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn vai trò cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

