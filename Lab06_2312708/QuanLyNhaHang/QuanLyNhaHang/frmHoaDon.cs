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
    public partial class frmHoaDon : Form
    {
        private HoaDonBus _hoaDonBus = new HoaDonBus();

        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            KhoiTaoComboBoxThangNam();
            HienThiTatCaHoaDon();
            DinhDangDgvHoaDon();

            if (rbTheoNgay != null) rbTheoNgay.Checked = true;
            CapNhatTrangThaiControls();
        }

        private void KhoiTaoComboBoxThangNam()
        {
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add($"Tháng {i}");
            }

            int namHienTai = DateTime.Now.Year;
            for (int i = namHienTai; i >= namHienTai - 10; i--)
            {
                cboNamThang.Items.Add(i);
                cboNam.Items.Add(i);
            }

            cboThang.SelectedIndex = DateTime.Now.Month - 1;
            cboNamThang.SelectedIndex = 0;
            cboNam.SelectedIndex = 0;
        }

        private void CapNhatTrangThaiControls()
        {
            if (rbTheoNgay != null && rbTheoNgay.Checked)
            {
                dtpNgay.Enabled = true;
                cboThang.Enabled = false;
                cboNamThang.Enabled = false;
                cboNam.Enabled = false;
            }
            else if (rbTheoThang != null && rbTheoThang.Checked)
            {
                dtpNgay.Enabled = false;
                cboThang.Enabled = true;
                cboNamThang.Enabled = true;
                cboNam.Enabled = false;
            }
            else if (rbTheoNam != null && rbTheoNam.Checked)
            {
                dtpNgay.Enabled = false;
                cboThang.Enabled = false;
                cboNamThang.Enabled = false;
                cboNam.Enabled = true;
            }
        }

        private void HienThiTatCaHoaDon()
        {
            try
            {
                List<HoaDon> dsHoaDon = _hoaDonBus.LayTatCa();
                dgvHoaDon.DataSource = dsHoaDon;
                DinhDangDgvHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DinhDangDgvHoaDon()
        {
            if (dgvHoaDon.Columns.Count == 0) return;

            if (dgvHoaDon.Columns.Contains("MaHD"))
            {
                dgvHoaDon.Columns["MaHD"].HeaderText = "Mã HĐ";
                dgvHoaDon.Columns["MaHD"].Width = 60;
            }

            if (dgvHoaDon.Columns.Contains("MaNV"))
            {
                dgvHoaDon.Columns["MaNV"].HeaderText = "Mã NV";
                dgvHoaDon.Columns["MaNV"].Width = 60;
            }

            if (dgvHoaDon.Columns.Contains("MaBan"))
            {
                dgvHoaDon.Columns["MaBan"].HeaderText = "Mã Bàn";
                dgvHoaDon.Columns["MaBan"].Width = 60;
            }

            if (dgvHoaDon.Columns.Contains("NgayLap"))
            {
                dgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày Lập";
                dgvHoaDon.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvHoaDon.Columns["NgayLap"].Width = 140;
            }

            if (dgvHoaDon.Columns.Contains("TongTien"))
            {
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvHoaDon.Columns.Contains("GiamGia"))
            {
                dgvHoaDon.Columns["GiamGia"].HeaderText = "Giảm Giá (%)";
                dgvHoaDon.Columns["GiamGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvHoaDon.Columns["GiamGia"].Width = 90;
            }

            if (dgvHoaDon.Columns.Contains("ThanhToan"))
            {
                dgvHoaDon.Columns["ThanhToan"].HeaderText = "Thanh Toán";
                dgvHoaDon.Columns["ThanhToan"].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns["ThanhToan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvHoaDon.Columns.Contains("DSChiTiet"))
            {
                dgvHoaDon.Columns["DSChiTiet"].Visible = false;
            }

            dgvHoaDon.ClearSelection();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            HienThiTatCaHoaDon();
        }

        private void btnHienThiDS_Click(object sender, EventArgs e)
        {
            try
            {
                List<HoaDon> dsHoaDon = new List<HoaDon>();

                if (rbTheoNgay != null && rbTheoNgay.Checked)
                {
                    DateTime ngayChon = dtpNgay.Value.Date;
                    dsHoaDon = _hoaDonBus.LayTheoNgay(ngayChon);
                    MessageBox.Show($"Hiển thị hóa đơn ngày: {ngayChon:dd/MM/yyyy}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rbTheoThang != null && rbTheoThang.Checked)
                {
                    if (cboThang.SelectedIndex >= 0 && cboNamThang.SelectedIndex >= 0)
                    {
                        int thang = cboThang.SelectedIndex + 1;
                        int nam = int.Parse(cboNamThang.SelectedItem.ToString());
                        dsHoaDon = _hoaDonBus.LayTheoThang(thang, nam);
                        MessageBox.Show($"Hiển thị hóa đơn tháng {thang}/{nam}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn tháng và năm!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (rbTheoNam != null && rbTheoNam.Checked)
                {
                    if (cboNam.SelectedIndex >= 0)
                    {
                        int nam = int.Parse(cboNam.SelectedItem.ToString());
                        dsHoaDon = _hoaDonBus.LayTheoNam(nam);
                        MessageBox.Show($"Hiển thị hóa đơn năm {nam}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn năm!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn loại lọc (Theo ngày/tháng/năm)!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvHoaDon.DataSource = dsHoaDon;
                DinhDangDgvHoaDon();

                if (dsHoaDon.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatTrangThaiControls();
        }

        private void rbTheoThang_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatTrangThaiControls();
        }

        private void rbTheoNam_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatTrangThaiControls();
        }
    }
}
