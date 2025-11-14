using QuanLyNhaHang.BLL;
using QuanLyNhaHang.DTO;
using QuanLyNhaHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class MainForm : Form
    {
        private BanBus _banBus = new BanBus();
        private LoaiMonAnBus _loaiMonAnBus = new LoaiMonAnBus();
        private MonAnBus _monAnBus = new MonAnBus();
        private HoaDonBus _hoaDonBus = new HoaDonBus();
        private List<MonAn> _dsMonAnGocTheoLoai;
        private List<Ban> _dsBan;
        private Ban _banDangChon;
        private BindingList<MonAnHoaDon> _dsMonAnTrongHoaDon;
        private Button _btnBanDaChon;

        private System.Windows.Forms.Timer _searchTimer;
        public MainForm()
        {
            InitializeComponent();

            _searchTimer = new System.Windows.Forms.Timer();
            _searchTimer.Interval = 300;
            _searchTimer.Tick += SearchTimer_Tick;
            
            _dsMonAnTrongHoaDon = new BindingList<MonAnHoaDon>();
            
            TaiVaTaoGiaoDienBan();
            cboLoaiMon.SelectedIndexChanged += cboLoaiMon_SelectedIndexChanged;
            cboLoaiMon.SelectedIndex = -1;
            dgvMonAn.DataSourceChanged += dgvMonAn_DataSourceChanged;
            LoadLoaiMonAnVaoComboBox();

            KhoiTaoDgvHoaDon();
            dgvMonAn.DataSource = null;
            if (cboLoaiMon != null) cboLoaiMon.Enabled = false;
            if (txtTimKiem != null) txtTimKiem.Enabled = false;
        }

        private void btnDSLoaiMon_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLoaiMon frm = new frmLoaiMon();
            frm.FormClosed += (s, args) => this.Show();
            frm.ShowDialog();
        }

        private void btnDSBill_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHoaDon frm = new frmHoaDon();
            frm.FormClosed += (s, args) => this.Show();
            frm.ShowDialog();
        }

        private void btnDSNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhanVien frm = new frmNhanVien();
            frm.FormClosed += (s, args) => this.Show();
            frm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadLoaiMonAnVaoComboBox()
        {
            List<LoaiMonAn> dsLoai = _loaiMonAnBus.LayTatCa();

            LoaiMonAn tatCa = new LoaiMonAn(0, "Tất cả", "ALL");

            dsLoai.Insert(0, tatCa);

            cboLoaiMon.DataSource = null;

            cboLoaiMon.DataSource = dsLoai;

            cboLoaiMon.DisplayMember = "TenLoai";

            cboLoaiMon.ValueMember = "MaLoai";

            cboLoaiMon.SelectedIndex = 0;
        }

        public void TaiVaTaoGiaoDienBan()
        {
            tcTang.TabPages.Clear();
            _btnBanDaChon = null;
            _dsBan = _banBus.LayTatCa();

            if (!_dsBan.Any())
            {
                ThemTabTangMoi();
                return;
            }

            var dsTang = _dsBan.GroupBy(b => b.SoTang).OrderBy(g => g.Key);

            foreach (var nhomTang in dsTang)
            {
                int soTang = nhomTang.Key;

                TabPage newTang = TaoTabTang(soTang);

                FlowLayoutPanel flpBan = newTang.Controls.OfType<Panel>().FirstOrDefault()
                                            ?.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();

                if (flpBan != null)
                {
                    foreach (var ban in nhomTang)
                    {
                        ThemBanVaoGiaoDien(flpBan, ban);
                    }
                }
            }

            if (tcTang.TabPages.Count > 0)
            {
                tcTang.SelectedTab = tcTang.TabPages[0];
            }
        }

        private TabPage TaoTabTang(int soTang)
        {
            TabPage newTang = new TabPage();
            newTang.Text = $"Tầng {soTang}";
            newTang.Name = $"tabTang_{soTang}";

            Panel pnlContainer = new Panel { Dock = DockStyle.Fill };

            Button btnThemBan = new Button
            {
                Text = "Thêm Bàn",
                Name = $"btnThemBan_Tang_{soTang}",
                Dock = DockStyle.Top,
                Height = 30
            };
            btnThemBan.Click += BtnThemBan_Tang_Click;

            FlowLayoutPanel flpBan = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                Name = $"flpTang_{soTang}",
                AutoScroll = true,
                Padding = new Padding(5)
            };

            pnlContainer.Controls.Add(flpBan);
            pnlContainer.Controls.Add(btnThemBan);
            newTang.Controls.Add(pnlContainer);
            tcTang.TabPages.Add(newTang);

            return newTang;
        }

        private void ThemBanVaoGiaoDien(FlowLayoutPanel flpTarget, Ban ban)
        {
            Button btnBan = new Button
            {
                Text = ban.TenBan,
                Name = $"btnBan_{ban.MaBan}",
                Tag = ban.MaBan,
                Width = 80,
                Height = 80,
                BackColor = Color.LightGreen,
                ContextMenuStrip = cmsXoaBan,
                FlatStyle = FlatStyle.Flat
            };
            btnBan.FlatAppearance.BorderSize = 0;
            btnBan.FlatAppearance.BorderColor = Color.Blue;
            btnBan.Click += BtnBan_Click;

            flpTarget.Controls.Add(btnBan);
        }


        private void btnThemTang_Click(object sender, EventArgs e)
        {
            int maxSoTangHienTai = 0;

            if (tcTang.TabPages.Count > 0)
            {
                var validTabs = tcTang.TabPages.Cast<TabPage>()
                                        .Where(t => t.Name.StartsWith("tabTang_"));

                if (validTabs.Any())
                {
                    maxSoTangHienTai = validTabs.Max(t => Convert.ToInt32(t.Name.Replace("tabTang_", "")));
                }
            }

            if (maxSoTangHienTai > 0)
            {
                bool tangLonNhatCoBan = _dsBan.Any(b => b.SoTang == maxSoTangHienTai);

                if (!tangLonNhatCoBan)
                {
                    MessageBox.Show(
                        $"Không thể tạo Tầng mới. Tầng {maxSoTangHienTai} hiện đang rỗng. Vui lòng thêm Bàn vào Tầng {maxSoTangHienTai} trước.",
                        "Lỗi Tạo Tầng",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop
                    );

                    TabPage tabHienTai = tcTang.TabPages.Cast<TabPage>()
                                        .FirstOrDefault(t => t.Name == $"tabTang_{maxSoTangHienTai}");
                    if (tabHienTai != null)
                    {
                        tcTang.SelectedTab = tabHienTai;
                    }
                    return;
                }
            }

            int soTangMoi = maxSoTangHienTai + 1;

            TabPage newTang = TaoTabTang(soTangMoi);
            tcTang.SelectedTab = newTang;
        }

        private void ThemTabTangMoi()
        {
            int soTangMoi = tcTang.TabPages.Count + 1;
            TabPage newTang = TaoTabTang(soTangMoi);
            tcTang.SelectedTab = newTang;
        }

        private void BtnThemBan_Tang_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            FlowLayoutPanel flp = btn.Parent.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();

            if (flp != null)
            {
                ThemBanMoi(flp);
            }
        }

        private void ThemBanMoi(FlowLayoutPanel flpTarget)
        {
            TabPage currentTab = flpTarget.Parent.Parent as TabPage;
            int soTang = Convert.ToInt32(currentTab.Name.Replace("tabTang_", ""));

            int soBanHienTai = flpTarget.Controls.OfType<Button>().Count() + 1;
            string tenBanMoi = $"Bàn {soBanHienTai}";

            Ban banMoi = new Ban(0, soTang, tenBanMoi);

            if (_banBus.Them(banMoi))
            {
                MessageBox.Show($"Đã thêm {tenBanMoi} vào Tầng {soTang} thành công!", "Thành công");

                TaiVaTaoGiaoDienBan();

                TabPage tabVuaThem = tcTang.TabPages.Cast<TabPage>().FirstOrDefault(t => t.Name == $"tabTang_{soTang}");
                if (tabVuaThem != null)
                {
                    tcTang.SelectedTab = tabVuaThem;
                }
            }
            else
            {
                MessageBox.Show("Thêm bàn mới thất bại!", "Lỗi");
            }
        }

        private void BtnBan_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is int maBan)
            {
                var ban = _dsBan.FirstOrDefault(b => b.MaBan == maBan);
                if (ban != null)
                {
                    if (_btnBanDaChon != null && _btnBanDaChon != btn)
                    {
                        int prevMaBan = 0;
                        if (_btnBanDaChon.Tag is int pm) prevMaBan = pm;
                        var banPrev = _dsBan.FirstOrDefault(b => b.MaBan == prevMaBan);
                        if (banPrev != null)
                        {
                            _btnBanDaChon.BackColor = banPrev.TrangThai == 1 ? Color.LightCoral : Color.LightGreen;
                            _btnBanDaChon.FlatAppearance.BorderSize = 0;
                        }
                    }

                    if (dgvMonAn != null) TaiMonAnTheoLoaiHienTai();
                    if (cboLoaiMon != null) cboLoaiMon.Enabled = true;
                    if (txtTimKiem != null) txtTimKiem.Enabled = true;

                    _banDangChon = ban;

                    btn.FlatAppearance.BorderSize = 3;
                    btn.FlatAppearance.BorderColor = Color.DodgerBlue;
                    _btnBanDaChon = btn;

                    _dsMonAnTrongHoaDon.Clear();
                    if (ban.HoaDonHienTai != null && ban.HoaDonHienTai.DSChiTiet != null)
                    {
                        foreach (var chiTiet in ban.HoaDonHienTai.DSChiTiet)
                        {
                            var monAn = _monAnBus.LayTheoMa(chiTiet.MaMon);
                            if (monAn != null)
                            {
                                _dsMonAnTrongHoaDon.Add(new MonAnHoaDon(monAn, chiTiet.SoLuong));
                            }
                        }
                        btn.BackColor = Color.LightCoral;
                        
                        if (txtGiamGia != null)
                        {
                            txtGiamGia.Text = ban.HoaDonHienTai.GiamGia.ToString();
                        }
                    }
                    else
                    {
                        _dsMonAnTrongHoaDon.Clear();
                        btn.BackColor = Color.LightGreen;
                        
                        if (txtGiamGia != null)
                        {
                            txtGiamGia.Text = "0";
                        }
                    }

                    TinhToanHoaDon();
                }
            }
        }

        private void xóaBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            ContextMenuStrip cms = tsmi.Owner as ContextMenuStrip;
            Button btnBan = cms.SourceControl as Button;

            if (btnBan != null && btnBan.Tag is int maBan)
            {
                DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa {btnBan.Text} không?", "Xác nhận xóa Bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    if (_banBus.Xoa(maBan))
                    {
                        MessageBox.Show($"Đã xóa {btnBan.Text}", "Thành công");

                        TaiVaTaoGiaoDienBan();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Bàn thất bại! Vui lòng kiểm tra kết nối DB.", "Lỗi");
                    }
                }
            }
        }

        private void btnXoaTang_Click(object sender, EventArgs e)
        {
            if (_dsBan == null || !_dsBan.Any())
            {
                MessageBox.Show("Không có Tầng nào để xóa. Vui lòng thêm Bàn vào ít nhất một Tầng trước.", "Thông báo");
                return;
            }
            int soTangLonNhat = _dsBan.Max(b => b.SoTang);

            TabPage tabXoa = tcTang.TabPages.Cast<TabPage>()
                                .FirstOrDefault(t => t.Name == $"tabTang_{soTangLonNhat}");

            string tenTab = tabXoa != null ? tabXoa.Text : $"Tầng {soTangLonNhat}";

            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa {tenTab} (Tầng cao nhất) và tất cả các Bàn trong đó không?",
                "Xác nhận xóa Tầng Cao Nhất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dr == DialogResult.Yes)
            {
                var dsBanCanXoa = _dsBan.Where(b => b.SoTang == soTangLonNhat).ToList();
                bool hasError = false;

                foreach (var ban in dsBanCanXoa)
                {
                    if (!_banBus.Xoa(ban.MaBan))
                    {
                        hasError = true;
                    }
                }

                if (!hasError)
                {
                    MessageBox.Show($"Đã xóa thành công {tenTab} và {dsBanCanXoa.Count} Bàn liên quan.", "Thành công");

                    TaiVaTaoGiaoDienBan();

                    if (_dsBan.Any())
                    {
                        int soTangSauXoa = _dsBan.Max(b => b.SoTang);
                        TabPage tabChon = tcTang.TabPages.Cast<TabPage>()
                                            .FirstOrDefault(t => t.Name == $"tabTang_{soTangSauXoa}");
                        if (tabChon != null)
                        {
                            tcTang.SelectedTab = tabChon;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Xóa Tầng gặp lỗi: Xóa Tầng khỏi DB thất bại. Vui lòng kiểm tra kết nối DB.", "Lỗi DB");
                }
            }
        }

        private void DinhDangCotMonAn()
        {
            if (dgvMonAn.Columns.Count == 0) return;

            if (dgvMonAn.Columns.Contains("MaMon")) dgvMonAn.Columns["MaMon"].HeaderText = "Mã Món";
            if (dgvMonAn.Columns.Contains("TenMon")) dgvMonAn.Columns["TenMon"].HeaderText = "Tên Món";
            if (dgvMonAn.Columns.Contains("DonGia")) 
            {
                dgvMonAn.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgvMonAn.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dgvMonAn.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvMonAn.Columns.Contains("MaLoai")) dgvMonAn.Columns["MaLoai"].Visible = false;
            if (dgvMonAn.Columns.Contains("DonViTinh")) dgvMonAn.Columns["DonViTinh"].Visible = false;
            if (dgvMonAn.Columns.Contains("GhiChu")) dgvMonAn.Columns["GhiChu"].Visible = false;

            dgvMonAn.ClearSelection();
        }

        private void KhoiTaoDgvHoaDon()
        {
            if (dgvHoaDon == null) return;

            dgvHoaDon.DataSource = _dsMonAnTrongHoaDon;
            
            DataGridViewButtonColumn btnTang = new DataGridViewButtonColumn();
            btnTang.Name = "btnTang";
            btnTang.HeaderText = "Thêm";
            btnTang.Text = "+";
            btnTang.UseColumnTextForButtonValue = true;
            btnTang.Width = 15;
            btnTang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHoaDon.Columns.Insert(0, btnTang);
            
            DataGridViewButtonColumn btnGiam = new DataGridViewButtonColumn();
            btnGiam.Name = "btnGiam";
            btnGiam.HeaderText = "Giảm";
            btnGiam.Text = "-";
            btnGiam.UseColumnTextForButtonValue = true;
            btnGiam.Width = 15;
            btnGiam.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHoaDon.Columns.Insert(1, btnGiam);

            DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
            btnXoa.Name = "btnXoa";
            btnXoa.HeaderText = "Xóa";
            btnXoa.Text = "x";
            btnXoa.UseColumnTextForButtonValue = true;
            btnXoa.Width = 15;
            btnXoa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHoaDon.Columns.Insert(2, btnXoa);

            var colMaMon = dgvHoaDon.Columns["MaMon"];
            if (colMaMon != null) colMaMon.Visible = false;

            var colTenMon = dgvHoaDon.Columns["TenMon"];
            if (colTenMon != null)
            {
                colTenMon.HeaderText = "Tên Món";
                colTenMon.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colTenMon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            var colDonGia = dgvHoaDon.Columns["DonGia"];
            if (colDonGia != null)
            {
                colDonGia.HeaderText = "Đơn Giá";
                colDonGia.DefaultCellStyle.Format = "N0";
                colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            var colSoLuong = dgvHoaDon.Columns["SoLuong"];
            if (colSoLuong != null)
            {
                colSoLuong.HeaderText = "SL";
                colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            var colThanhTien = dgvHoaDon.Columns["ThanhTien"];
            if (colThanhTien != null)
            {
                colThanhTien.HeaderText = "Thành Tiền";
                colThanhTien.DefaultCellStyle.Format = "N0";
                colThanhTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.ReadOnly = true;
        }

        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            string normalizedString = text.Normalize(System.Text.NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            ThucHienTimKiem();
        }

        private void ThucHienTimKiem()
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                TaiMonAnTheoLoaiHienTai();
                lblSoMonDaChon.Text = "Đã chọn: 0 món";
                return;
            }

            if (_dsMonAnGocTheoLoai == null) return;

            string keywordNormalized = RemoveDiacritics(keyword).ToLower();

            var ketQuaLoc = _dsMonAnGocTheoLoai.Where(m =>
            {
                bool matchTenMon = m.TenMon.ToLower().Contains(keyword.ToLower()) ||
                                   RemoveDiacritics(m.TenMon).ToLower().Contains(keywordNormalized);

                bool matchDonGia = false;
                if (decimal.TryParse(keyword, out decimal searchPrice))
                {
                    matchDonGia = m.DonGia.ToString().Contains(searchPrice.ToString());
                }

                return matchTenMon || matchDonGia;
            }).ToList();

            dgvMonAn.DataSource = ketQuaLoc;
            DinhDangCotMonAn();
            dgvMonAn.ClearSelection();

            lblSoMonDaChon.Text = $"Tìm thấy: {ketQuaLoc.Count} món";
        }


        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void TaiMonAnTheoLoaiHienTai()
        {
            List<MonAn> dsMonAn = new List<MonAn>();

            if (cboLoaiMon.SelectedItem is LoaiMonAn loaiDaChon)
            {
                if (cboLoaiMon.SelectedIndex == 0)
                {
                    dsMonAn = _monAnBus.LayTatCa() ?? new List<MonAn>();
                }
                else
                {
                    dsMonAn = _monAnBus.LayTheoLoai(loaiDaChon.MaLoai) ?? new List<MonAn>();
                }

                _dsMonAnGocTheoLoai = dsMonAn;

                if (dsMonAn.Count > 0)
                {
                    dgvMonAn.DataSource = _dsMonAnGocTheoLoai;
                    DinhDangCotMonAn();
                }
                else
                {
                    dgvMonAn.DataSource = null;
                }

                dgvMonAn.ClearSelection();
            }
            else
            {
                dgvMonAn.DataSource = null;
            }
        }

        private void dgvMonAn_DataSourceChanged(object sender, EventArgs e)
        {
            DinhDangCotMonAn();
        }

        private void dgvMonAn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            DataGridViewRow row = dgvMonAn.Rows[e.RowIndex];
            MonAn monAn = row.DataBoundItem as MonAn;
            
            if (monAn != null)
            {
                ThemMonVaoHoaDon(monAn);
            }
        }

        private void ThemMonVaoHoaDon(MonAn monAn)
        {
            

            if (_banDangChon.HoaDonHienTai == null)
            {
                _banDangChon.HoaDonHienTai = new HoaDon()
                {
                    MaBan = _banDangChon.MaBan,
                    NgayLap = DateTime.Now,
                    DSChiTiet = new List<ChiTietHoaDon>()
                };
            }

            var monTonTai = _dsMonAnTrongHoaDon.FirstOrDefault(m => m.MaMon == monAn.MaMon);
            if (monTonTai != null)
            {
                monTonTai.SoLuong++;
            }
            else
            {
                _dsMonAnTrongHoaDon.Add(new MonAnHoaDon(monAn, 1));
            }

            _banDangChon.HoaDonHienTai.DSChiTiet = _dsMonAnTrongHoaDon.Select(m => new ChiTietHoaDon
            {
                MaMon = m.MaMon,
                SoLuong = m.SoLuong,
                DonGia = m.DonGia,
                ThanhTien = m.ThanhTien
            }).ToList();

            _banDangChon.TrangThai = 1;
            var btnBan = Controls.Find($"btnBan_{_banDangChon.MaBan}", true).FirstOrDefault() as Button;
            if (btnBan != null)
            {
                btnBan.BackColor = Color.LightCoral;
            }

            dgvHoaDon.Refresh();
            TinhToanHoaDon();
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvHoaDon.Columns == null || e.ColumnIndex < 0 || e.ColumnIndex >= dgvHoaDon.Columns.Count) return;
            string columnName = dgvHoaDon.Columns[e.ColumnIndex]?.Name;
            if (string.IsNullOrEmpty(columnName)) return;
            int dataIndex = e.RowIndex;
            if (dataIndex >= _dsMonAnTrongHoaDon.Count) return;
            MonAnHoaDon monAn = _dsMonAnTrongHoaDon[dataIndex];
            if (columnName == "btnTang")
            {
                monAn.SoLuong++;
            }
            else if (columnName == "btnGiam")
            {
                monAn.SoLuong--;
                if (monAn.SoLuong <= 0)
                {
                    _dsMonAnTrongHoaDon.Remove(monAn);
                }
            }
            else if (columnName == "btnXoa")
            {
                _dsMonAnTrongHoaDon.Remove(monAn);
            }
            if (_banDangChon != null && _banDangChon.HoaDonHienTai != null)
            {
                _banDangChon.HoaDonHienTai.DSChiTiet = _dsMonAnTrongHoaDon.Select(m => new ChiTietHoaDon
                {
                    MaMon = m.MaMon,
                    SoLuong = m.SoLuong,
                    DonGia = m.DonGia,
                    ThanhTien = m.ThanhTien
                }).ToList();
            }
            dgvHoaDon.Refresh();
            TinhToanHoaDon();
        }

        private void TinhToanHoaDon()
        {
            decimal tongTien = 0;
            foreach (var mon in _dsMonAnTrongHoaDon)
            {
                tongTien += mon.ThanhTien;
            }
            
            decimal giamGia = 0;
            if (!string.IsNullOrEmpty(txtGiamGia.Text))
            {
                decimal.TryParse(txtGiamGia.Text, out giamGia);
            }
            
            decimal tienGiam = tongTien * giamGia / 100;
            
            decimal thanhToan = tongTien - tienGiam;

            txtTongTien.Text = tongTien.ToString("N0");
            txtThanhToan.Text = thanhToan.ToString("N0");
            
            int soMon = _dsMonAnTrongHoaDon.Sum(m => m.SoLuong);
            lblSoMonDaChon.Text = $"Tổng: {soMon} món";
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            TinhToanHoaDon();
        }


        private void cboLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox cbo = sender as ComboBox;
                if (cbo.SelectedIndex == -1)
                {
                    dgvMonAn.DataSource = null;
                    return;
                }
                TaiMonAnTheoLoaiHienTai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải món ăn: " + ex.Message, "Lỗi");
            }
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_banDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thanh toán.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_dsMonAnTrongHoaDon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một món ăn.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal tongTien = 0;
            decimal.TryParse(txtTongTien.Text.Replace(",", ""), out tongTien);
            decimal thanhToan = 0;
            decimal.TryParse(txtThanhToan.Text.Replace(",", ""), out thanhToan);
            int giamGia = 0;
            int.TryParse(txtGiamGia.Text, out giamGia);
            DialogResult result = MessageBox.Show(
                $"Xác nhận thanh toán hóa đơn:\n" +
                $"- Số món: {_dsMonAnTrongHoaDon.Sum(m => m.SoLuong)}\n" +
                $"- Tổng tiền: {tongTien:N0} VNĐ\n" +
                $"- Giảm giá: {giamGia}%\n" +
                $"- Thanh toán: {thanhToan:N0} VNĐ",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                try
                {
                    HoaDon hoaDon = new HoaDon
                    {
                        MaBan = _banDangChon.MaBan,
                        MaNV = 1,
                        NgayLap = DateTime.Now,
                        TongTien = tongTien,
                        GiamGia = giamGia,
                        ThanhToan = thanhToan,
                        DSChiTiet = _dsMonAnTrongHoaDon.Select(m => new ChiTietHoaDon
                        {
                            MaMon = m.MaMon,
                            SoLuong = m.SoLuong,
                            DonGia = m.DonGia,
                            ThanhTien = m.ThanhTien
                        }).ToList()
                    };
                    if (_hoaDonBus.LuuHoaDon(hoaDon))
                    {
                        _banDangChon.HoaDonHienTai = null;
                        _banDangChon.TrangThai = 0;

                        _dsMonAnTrongHoaDon.Clear();
                        if (txtGiamGia != null) txtGiamGia.Text = "0";
                        TinhToanHoaDon();

                        var btnBan = Controls.Find($"btnBan_{_banDangChon.MaBan}", true).FirstOrDefault() as Button;
                        if (btnBan != null)
                        {
                            btnBan.BackColor = Color.LightGreen;
                            btnBan.FlatAppearance.BorderSize = 0;
                            if (_btnBanDaChon == btnBan) _btnBanDaChon = null;
                        }

                        if (dgvMonAn != null) dgvMonAn.Enabled = false;
                        if (cboLoaiMon != null) cboLoaiMon.Enabled = false;
                        if (txtTimKiem != null) txtTimKiem.Enabled = false;

                        MessageBox.Show("Thanh toán thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi lưu hóa đơn vào cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (_banDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi hủy.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_dsMonAnTrongHoaDon.Count == 0)
            {
                DialogResult resultt = MessageBox.Show("Hóa đơn đang trống!\nChắc chắn hủy bàn này không?", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (resultt == DialogResult.Yes) HuyBan();
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy hóa đơn này không?\nMọi món ăn đã chọn sẽ bị xóa.","Xác nhận hủy",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes) HuyBan();

        }

        public void HuyBan()
        {
            _banDangChon.HoaDonHienTai = null;
            _banDangChon.TrangThai = 0;

            _dsMonAnTrongHoaDon.Clear();
            if (txtGiamGia != null) txtGiamGia.Text = "0";
            TinhToanHoaDon();

            var btnBan = Controls.Find($"btnBan_{_banDangChon.MaBan}", true).FirstOrDefault() as Button;
            if (btnBan != null)
            {
                btnBan.BackColor = Color.LightGreen;
                btnBan.FlatAppearance.BorderSize = 0;
                if (_btnBanDaChon == btnBan) _btnBanDaChon = null;
            }

            if (dgvMonAn != null) dgvMonAn.Enabled = false;
            if (cboLoaiMon != null) cboLoaiMon.Enabled = false;
            if (txtTimKiem != null) txtTimKiem.Enabled = false;

            MessageBox.Show("Đã hủy hóa đơn!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvMonAn.DataSource = null;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiVaTaoGiaoDienBan();
            cboLoaiMon.SelectedIndex = -1;
            LoadLoaiMonAnVaoComboBox();
            txtTimKiem.Clear();
            
            _searchTimer.Stop();
            dgvMonAn.DataSource = null;
            if (cboLoaiMon != null) cboLoaiMon.Enabled = false;
            if (txtTimKiem != null) txtTimKiem.Enabled = false;
            int soMon = _dsMonAnTrongHoaDon.Sum(m => m.SoLuong);
            lblSoMonDaChon.Text = $"Tổng: {soMon} món";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
