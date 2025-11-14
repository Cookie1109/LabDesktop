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
    public partial class frmNhanVien : Form
    {
        private ContextMenuStrip contextMenu;

        public frmNhanVien()
        {
            InitializeComponent();
            CreateContextMenu();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadAccounts();
            cboGioiTinh.SelectedIndex = 0;
            
            // Cấu hình DataGridView
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ContextMenuStrip = contextMenu;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void CreateContextMenu()
        {
            contextMenu = new ContextMenuStrip();
            
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Xóa tài khoản");
            deleteItem.Click += DeleteAccount_Click;
            contextMenu.Items.Add(deleteItem);
            
            ToolStripMenuItem viewRolesItem = new ToolStripMenuItem("Xem danh sách vai trò");
            viewRolesItem.Click += ViewRoles_Click;
            contextMenu.Items.Add(viewRolesItem);
        }

        private void LoadRoles()
        {
            try
            {
                List<Role> roles = RoleBus.Instance.GetAllRoles();
                cboChucVu.DataSource = roles;
                cboChucVu.DisplayMember = "RoleName";
                cboChucVu.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chức vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAccounts()
        {
            try
            {
                List<Account> accounts = AccountBus.Instance.GetAllAccounts();
                
                // Tạo DataTable để hiển thị
                DataTable dt = new DataTable();
                dt.Columns.Add("MaNV", typeof(int));
                dt.Columns.Add("Tên Nhân Viên", typeof(string));
                dt.Columns.Add("Giới Tính", typeof(string));
                dt.Columns.Add("Số Điện Thoại", typeof(string));
                dt.Columns.Add("Chức Vụ", typeof(string));
                dt.Columns.Add("Tài Khoản", typeof(string));
                
                foreach (var acc in accounts)
                {
                    dt.Rows.Add(acc.MaNV, acc.TenNV, acc.GioiTinh, acc.SDT, acc.RoleName, acc.Username);
                }
                
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["MaNV"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                
                int maNV = Convert.ToInt32(row.Cells["MaNV"].Value);
                txtMaNV.Text = maNV.ToString();
                txtTenNV.Text = row.Cells["Tên Nhân Viên"].Value.ToString();
                txtSDT.Text = row.Cells["Số Điện Thoại"].Value.ToString();
                cboGioiTinh.Text = row.Cells["Giới Tính"].Value.ToString();
                
                // Load account info
                Account account = AccountBus.Instance.GetAccountByMaNV(maNV);
                if (account != null)
                {
                    txtTaiKhoan.Text = account.Username;
                    txtMatKhau.Text = account.Password;
                    cboChucVu.SelectedValue = account.RoleID;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaNV.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maNV = Convert.ToInt32(txtMaNV.Text);
                string tenNV = txtTenNV.Text.Trim();
                string gioiTinh = cboGioiTinh.Text;
                string sdt = txtSDT.Text.Trim();
                string username = txtTaiKhoan.Text.Trim();
                string password = txtMatKhau.Text.Trim();

                if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(sdt) || 
                    string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboChucVu.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int roleID = Convert.ToInt32(cboChucVu.SelectedValue);
                string roleName = cboChucVu.Text;

                // Cập nhật thông tin nhân viên
                bool nvResult = NhanVienBus.Instance.UpdateNhanVien(maNV, tenNV, gioiTinh, sdt, roleName);

                // Cập nhật thông tin tài khoản
                bool accResult = AccountBus.Instance.UpdateAccount(maNV, username, password, roleID);

                if (nvResult && accResult)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccounts();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteAccount_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int maNV = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaNV"].Value);
                string tenNV = dataGridView1.SelectedRows[0].Cells["Tên Nhân Viên"].Value.ToString();
                
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa tài khoản của nhân viên '{tenNV}'?\n" +
                    "Vai trò của nhân viên này sẽ bị đánh dấu là không hoạt động (0).",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    bool success = AccountBus.Instance.DeleteAccount(maNV);
                    if (success)
                    {
                        MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAccounts();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ViewRoles_Click(object sender, EventArgs e)
        {
            frmRole frmRole = new frmRole();
            frmRole.ShowDialog();
            LoadRoles(); // Reload roles after closing role form
        }

        private void ClearForm()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            cboGioiTinh.SelectedIndex = 0;
            if (cboChucVu.Items.Count > 0)
                cboChucVu.SelectedIndex = 0;
        }
    }
}

