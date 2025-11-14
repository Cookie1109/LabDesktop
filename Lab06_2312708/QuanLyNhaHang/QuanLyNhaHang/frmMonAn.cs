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
    public partial class frmMonAn : Form
    {
        private readonly MonAnBus monAnBus = new MonAnBus();

        private int _maLoaiDuocChon;
        private string _tenLoaiDuocChon;

        public frmMonAn()
        {
            InitializeComponent();
        }

        private void dgvDSMonAn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void frmMonAn_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        public frmMonAn(int maLoai, string tenLoai)
        {
            InitializeComponent();

            _maLoaiDuocChon = maLoai;
            _tenLoaiDuocChon = tenLoai;

            this.Text = "Danh Sách Món Ăn: " + _tenLoaiDuocChon;
            dgvDSMonAn.DataError += dgvDSMonAn_DataError;
        }

        private void frmMonAn_Load(object sender, EventArgs e)
        {
            if (_maLoaiDuocChon > 0)
            {
                HienThiDanhSach();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Lỗi không xác định loại món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void HienThiDanhSach()
        {
            int maLoai = _maLoaiDuocChon;

                var danhsach = monAnBus.LayTheoLoai(maLoai);
            try
            {
                dgvDSMonAn.DataSource = danhsach;
                if (dgvDSMonAn.Columns.Count > 5)
                {
                    dgvDSMonAn.Columns[0].HeaderText = "Mã món ăn";
                    dgvDSMonAn.Columns[1].HeaderText = "Tên món ăn";
                    dgvDSMonAn.Columns[2].Visible = false;
                    dgvDSMonAn.Columns[3].HeaderText = "Đơn giá";
                    dgvDSMonAn.Columns[4].HeaderText = "Đơn vị tính";
                    dgvDSMonAn.Columns[5].HeaderText = "Ghi chú";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LamMoi()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtDonGia.Text = "";
            txtDonVi.Text = "";
            txtGhiChu.Text = "";

            dgvDSMonAn.ClearSelection();

            btnCapNhat.Enabled = false;
            btnThem.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MonAn monAn = new MonAn();
            monAn.TenMon = txtTenMon.Text.Trim();
            monAn.MaLoai = _maLoaiDuocChon;
            monAn.DonGia = decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia) ? donGia : 0;
            monAn.DonViTinh = txtDonVi.Text.Trim();
            monAn.GhiChu = txtGhiChu.Text.Trim();
            if (string.IsNullOrEmpty(monAn.TenMon) || donGia<=0 || string.IsNullOrEmpty(monAn.DonViTinh))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    if (monAnBus.Them(monAn))
                    {
                        MessageBox.Show("Thêm món ăn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiDanhSach();
                        LamMoi();
                    }
                    else
                    {
                        MessageBox.Show("Thêm món ăn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm loại món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDSMonAn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hitTest = dgvDSMonAn.HitTest(e.X, e.Y);

                if (hitTest.RowIndex >= 0 && hitTest.Type == DataGridViewHitTestType.Cell)
                {
                    dgvDSMonAn.ClearSelection();

                    dgvDSMonAn.Rows[hitTest.RowIndex].Selected = true;

                    cmsXoaMonAn.Show(dgvDSMonAn, e.Location);
                }
                else if (hitTest.Type == DataGridViewHitTestType.ColumnHeader)
                {

                }
                else
                {

                }
            }
        }

        private void xóaMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow currentRow = dgvDSMonAn.CurrentRow;

                int maLoai = _maLoaiDuocChon;
                int maMon;
                if (!int.TryParse(currentRow.Cells[0].Value.ToString(), out maMon))
                {
                    MessageBox.Show("Mã món ăn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string tenMon = currentRow.Cells[1].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa '{tenMon}'?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dgvDSMonAn.ClearSelection();

                    monAnBus.Xoa(maMon,maLoai);
                    HienThiDanhSach();
                    LamMoi();
                    MessageBox.Show("Xóa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDSMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow currentRow = dgvDSMonAn.Rows[e.RowIndex];
                txtMaMon.Text = currentRow.Cells[0].Value.ToString() ?? "";
                txtTenMon.Text = currentRow.Cells[1].Value.ToString() ?? "";
                txtDonGia.Text = currentRow.Cells[3].Value.ToString() ?? "";
                txtDonVi.Text = currentRow.Cells[4].Value.ToString() ?? "";
                txtGhiChu.Text = currentRow.Cells[5].Value.ToString() ?? "";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnCapNhat.Enabled = true;
            btnThem.Enabled = false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenMon.Text) || string.IsNullOrEmpty(txtDonGia.Text) || string.IsNullOrEmpty(txtDonVi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin loại món ăn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int maMon = int.Parse(txtMaMon.Text);
            string tenMon = txtTenMon.Text.Trim();
            decimal donGia = decimal.Parse(txtDonGia.Text.Trim());
            int maLoai = _maLoaiDuocChon;
            string donVi = txtDonVi.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();
            MonAn monAn = new MonAn(maMon, tenMon, maLoai, donGia, donVi, ghiChu);

            try
            {
                if (monAnBus.CapNhat(monAn))
                {
                    MessageBox.Show("Cập nhật món ăn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDanhSach();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Cập nhật món ăn thất bại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
    }
}
