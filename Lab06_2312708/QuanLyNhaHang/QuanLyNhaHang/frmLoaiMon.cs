using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;
using QuanLyNhaHang.BLL;

namespace QuanLyNhaHang
{
    public partial class frmLoaiMon : Form
    {
        private readonly LoaiMonAnBus loaiMonAnBus = new LoaiMonAnBus();
        private readonly MonAnBus monAnBus = new MonAnBus();


        public frmLoaiMon()
        {
            InitializeComponent();
            dgvDSLoai.DataError += dgvDSLoai_DataError;
        }

        private void dgvDSLoai_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void frmLoaiMon_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
            LamMoi();

        }

        private void HienThiDanhSach()
        {
            try
            {
                var danhsach = loaiMonAnBus.LayTatCa();

                dgvDSLoai.DataSource = danhsach;
                if (dgvDSLoai.Columns.Count>3)
                {
                    dgvDSLoai.Columns[0].HeaderText = "Mã loại";
                    dgvDSLoai.Columns[1].HeaderText = "Tên loại món ăn";
                    dgvDSLoai.Columns[2].HeaderText = "Loại";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách loại món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LamMoi()
        {
            txtMaNhom.Text = "";
            txtTenNhom.Text = "";
            cboLoai.SelectedIndex = -1;
            dgvDSLoai.ClearSelection();
            btnCapNhat.Enabled = false;
            btnThem.Enabled = true;
        }

        
        private void btnThem_Click(object sender, EventArgs e)
        {
            LoaiMonAn loaiMonAn = new LoaiMonAn();
            loaiMonAn.TenLoai = txtTenNhom.Text.Trim();
            loaiMonAn.Loai = cboLoai.SelectedItem?.ToString() ?? "";
            if (string.IsNullOrEmpty(loaiMonAn.TenLoai) || string.IsNullOrEmpty(loaiMonAn.Loai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin loại món ăn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    bool isSuccess = loaiMonAnBus.Them(loaiMonAn);
                    if (isSuccess)
                    {
                        MessageBox.Show("Thêm loại món ăn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiDanhSach();
                    }
                    else
                    {
                        MessageBox.Show("Thêm loại món ăn thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm loại món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LamMoi();
            }
            
        }

        private void dgvDSLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCapNhat.Enabled = true;
            try
            {
                DataGridViewRow row = dgvDSLoai.Rows[e.RowIndex];
                txtMaNhom.Text = row.Cells[0].Value?.ToString().Trim() ?? "";
                txtTenNhom.Text = row.Cells[1].Value?.ToString().Trim() ?? "";
                string loai = row.Cells[2].Value?.ToString().Trim() ?? "";
                if (loai.Equals("Đồ ăn"))
                {
                    cboLoai.SelectedIndex = 0;
                }
                else if (loai.Equals("Đồ uống"))
                {
                    cboLoai.SelectedIndex = 1;
                }
                else
                {
                    cboLoai.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi dữ liệu loại món ăn vui lòng xóa dòng đó: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnThem.Enabled = false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNhom.Text) || string.IsNullOrEmpty(cboLoai.SelectedItem?.ToString()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin loại món ăn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int maNhom = int.Parse(txtMaNhom.Text);
            string tenNhom = txtTenNhom.Text.Trim();
            string loai = cboLoai.SelectedItem?.ToString().Trim();
            LoaiMonAn loaiMonAn = new LoaiMonAn(maNhom, tenNhom, loai);

            try
            {
                bool isSuccess = loaiMonAnBus.CapNhat(loaiMonAn);
                if (isSuccess)
                {
                    MessageBox.Show("Cập nhật loại món ăn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSach();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Cập nhật loại món ăn thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật loại món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void frmLoaiMon_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void dgvDSLoai_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hitTest = dgvDSLoai.HitTest(e.X, e.Y);

                if (hitTest.RowIndex >= 0 && hitTest.Type == DataGridViewHitTestType.Cell)
                {
                    dgvDSLoai.ClearSelection();

                    dgvDSLoai.Rows[hitTest.RowIndex].Selected = true;

                    cmsXoaLoai.Show(dgvDSLoai, e.Location);
                }
                else if (hitTest.Type == DataGridViewHitTestType.ColumnHeader)
                {

                }
                else
                {

                }
            }
        }

        private void xóaLoạiMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow currentRow = dgvDSLoai.CurrentRow;
                string tenLoai = currentRow.Cells[1].Value.ToString();
                int maLoai = int.Parse(currentRow.Cells[0].Value.ToString());
                List<MonAn> dsMonAn = monAnBus.LayTheoLoai(maLoai);

                
                if (!int.TryParse(currentRow.Cells[0].Value.ToString(), out maLoai))
                {
                    MessageBox.Show("Mã Loại món ăn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (dsMonAn.Count > 0)
                {
                    MessageBox.Show($"Không thể xóa Loại món ăn '{tenLoai}' vì vẫn còn món ăn thuộc loại này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa '{tenLoai}'?",
                        "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        dgvDSLoai.ClearSelection();

                        loaiMonAnBus.Xoa(maLoai);
                        HienThiDanhSach();
                        LamMoi();
                        MessageBox.Show("Xóa Loại món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa Loại món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void HienThiFormMonAn(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow currentRow = dgvDSLoai.Rows[e.RowIndex];

                    int maLoai;
                    if (int.TryParse(currentRow.Cells[0].Value.ToString(), out maLoai))
                    {
                        string tenLoai = currentRow.Cells[1].Value.ToString();
                        frmMonAn formMonAn = new frmMonAn(maLoai,tenLoai);
                        formMonAn.Show();
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy Mã Loại món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở danh sách món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void xemDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDSLoai.CurrentRow != null)
            {
                // Lấy chỉ số dòng hiện tại
                int rowIndex = dgvDSLoai.CurrentRow.Index;

                // Tạo một đối tượng DataGridViewCellEventArgs giả để gọi hàm
                DataGridViewCellEventArgs cellArgs = new DataGridViewCellEventArgs(0, rowIndex);

                HienThiFormMonAn(cellArgs);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvDSLoai_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            HienThiFormMonAn(e);
        }


    }
}
