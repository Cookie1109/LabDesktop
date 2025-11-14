namespace QuanLyNhaHang
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tcTang = new System.Windows.Forms.TabControl();
            this.btnDSLoaiMon = new System.Windows.Forms.Button();
            this.btnDSBill = new System.Windows.Forms.Button();
            this.btnDSNhanVien = new System.Windows.Forms.Button();
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblThanhToan = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtThanhToan = new System.Windows.Forms.TextBox();
            this.txtGiamGia = new System.Windows.Forms.MaskedTextBox();
            this.cboLoaiMon = new System.Windows.Forms.ComboBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThemTang = new System.Windows.Forms.Button();
            this.cmsXoaBan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaBànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsXoaTang = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaTầngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnXoaTang = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblSoMonDaChon = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.cmsXoaBan.SuspendLayout();
            this.cmsXoaTang.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcTang
            // 
            this.tcTang.Location = new System.Drawing.Point(188, 3);
            this.tcTang.Name = "tcTang";
            this.tcTang.SelectedIndex = 0;
            this.tcTang.Size = new System.Drawing.Size(382, 635);
            this.tcTang.TabIndex = 0;
            // 
            // btnDSLoaiMon
            // 
            this.btnDSLoaiMon.Location = new System.Drawing.Point(0, 122);
            this.btnDSLoaiMon.Name = "btnDSLoaiMon";
            this.btnDSLoaiMon.Size = new System.Drawing.Size(188, 33);
            this.btnDSLoaiMon.TabIndex = 1;
            this.btnDSLoaiMon.Text = "Danh sách Loại món";
            this.btnDSLoaiMon.UseVisualStyleBackColor = true;
            this.btnDSLoaiMon.Click += new System.EventHandler(this.btnDSLoaiMon_Click);
            // 
            // btnDSBill
            // 
            this.btnDSBill.Location = new System.Drawing.Point(1, 161);
            this.btnDSBill.Name = "btnDSBill";
            this.btnDSBill.Size = new System.Drawing.Size(188, 33);
            this.btnDSBill.TabIndex = 1;
            this.btnDSBill.Text = "Danh sách Hóa đơn";
            this.btnDSBill.UseVisualStyleBackColor = true;
            this.btnDSBill.Click += new System.EventHandler(this.btnDSBill_Click);
            // 
            // btnDSNhanVien
            // 
            this.btnDSNhanVien.Location = new System.Drawing.Point(1, 200);
            this.btnDSNhanVien.Name = "btnDSNhanVien";
            this.btnDSNhanVien.Size = new System.Drawing.Size(188, 33);
            this.btnDSNhanVien.TabIndex = 1;
            this.btnDSNhanVien.Text = "Danh sách Nhân viên";
            this.btnDSNhanVien.UseVisualStyleBackColor = true;
            this.btnDSNhanVien.Click += new System.EventHandler(this.btnDSNhanVien_Click);
            // 
            // dgvMonAn
            // 
            this.dgvMonAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonAn.Location = new System.Drawing.Point(576, 54);
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.ReadOnly = true;
            this.dgvMonAn.RowHeadersVisible = false;
            this.dgvMonAn.RowHeadersWidth = 51;
            this.dgvMonAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonAn.Size = new System.Drawing.Size(447, 203);
            this.dgvMonAn.TabIndex = 2;
            this.dgvMonAn.DataSourceChanged += new System.EventHandler(this.dgvMonAn_DataSourceChanged);
            this.dgvMonAn.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMonAn_CellDoubleClick);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(576, 283);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(447, 153);
            this.dgvHoaDon.TabIndex = 13;
            this.dgvHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellContentClick);
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Location = new System.Drawing.Point(637, 497);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(54, 13);
            this.lblGiamGia.TabIndex = 3;
            this.lblGiamGia.Text = "Giảm giá :";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(637, 464);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(58, 13);
            this.lblTongTien.TabIndex = 3;
            this.lblTongTien.Text = "Tổng tiền :";
            // 
            // lblThanhToan
            // 
            this.lblThanhToan.AutoSize = true;
            this.lblThanhToan.Location = new System.Drawing.Point(637, 532);
            this.lblThanhToan.Name = "lblThanhToan";
            this.lblThanhToan.Size = new System.Drawing.Size(68, 13);
            this.lblThanhToan.TabIndex = 3;
            this.lblThanhToan.Text = "Thanh toán :";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(785, 461);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(189, 20);
            this.txtTongTien.TabIndex = 4;
            this.txtTongTien.Text = "0";
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtThanhToan
            // 
            this.txtThanhToan.Location = new System.Drawing.Point(785, 529);
            this.txtThanhToan.Name = "txtThanhToan";
            this.txtThanhToan.ReadOnly = true;
            this.txtThanhToan.Size = new System.Drawing.Size(189, 20);
            this.txtThanhToan.TabIndex = 4;
            this.txtThanhToan.Text = "0";
            this.txtThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Location = new System.Drawing.Point(785, 494);
            this.txtGiamGia.Mask = "00";
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(189, 20);
            this.txtGiamGia.TabIndex = 5;
            this.txtGiamGia.Text = "0";
            this.txtGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGiamGia.TextChanged += new System.EventHandler(this.txtGiamGia_TextChanged);
            // 
            // cboLoaiMon
            // 
            this.cboLoaiMon.FormattingEnabled = true;
            this.cboLoaiMon.Location = new System.Drawing.Point(577, 25);
            this.cboLoaiMon.Name = "cboLoaiMon";
            this.cboLoaiMon.Size = new System.Drawing.Size(159, 21);
            this.cboLoaiMon.TabIndex = 6;
            this.cboLoaiMon.SelectedIndexChanged += new System.EventHandler(this.cboLoaiMon_SelectedIndexChanged);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(686, 606);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(100, 23);
            this.btnThanhToan.TabIndex = 7;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(842, 606);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 23);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThemTang
            // 
            this.btnThemTang.Location = new System.Drawing.Point(166, 3);
            this.btnThemTang.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemTang.Name = "btnThemTang";
            this.btnThemTang.Size = new System.Drawing.Size(23, 24);
            this.btnThemTang.TabIndex = 8;
            this.btnThemTang.Text = "+";
            this.btnThemTang.UseVisualStyleBackColor = true;
            this.btnThemTang.Click += new System.EventHandler(this.btnThemTang_Click);
            // 
            // cmsXoaBan
            // 
            this.cmsXoaBan.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsXoaBan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaBànToolStripMenuItem});
            this.cmsXoaBan.Name = "cmsXoaBan";
            this.cmsXoaBan.Size = new System.Drawing.Size(118, 26);
            // 
            // xóaBànToolStripMenuItem
            // 
            this.xóaBànToolStripMenuItem.Name = "xóaBànToolStripMenuItem";
            this.xóaBànToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.xóaBànToolStripMenuItem.Text = "Xóa bàn";
            this.xóaBànToolStripMenuItem.Click += new System.EventHandler(this.xóaBànToolStripMenuItem_Click);
            // 
            // cmsXoaTang
            // 
            this.cmsXoaTang.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsXoaTang.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaTầngToolStripMenuItem});
            this.cmsXoaTang.Name = "cmsXoaTang";
            this.cmsXoaTang.Size = new System.Drawing.Size(122, 26);
            // 
            // xóaTầngToolStripMenuItem
            // 
            this.xóaTầngToolStripMenuItem.Name = "xóaTầngToolStripMenuItem";
            this.xóaTầngToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.xóaTầngToolStripMenuItem.Text = "Xóa tầng";
            // 
            // btnXoaTang
            // 
            this.btnXoaTang.Location = new System.Drawing.Point(141, 3);
            this.btnXoaTang.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaTang.Name = "btnXoaTang";
            this.btnXoaTang.Size = new System.Drawing.Size(23, 24);
            this.btnXoaTang.TabIndex = 8;
            this.btnXoaTang.Text = "-";
            this.btnXoaTang.UseVisualStyleBackColor = true;
            this.btnXoaTang.Click += new System.EventHandler(this.btnXoaTang_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(733, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "HÓA ĐƠN ĐẶT BÀN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(835, 25);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(188, 20);
            this.txtTimKiem.TabIndex = 10;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblSoMonDaChon
            // 
            this.lblSoMonDaChon.AutoSize = true;
            this.lblSoMonDaChon.Location = new System.Drawing.Point(638, 564);
            this.lblSoMonDaChon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoMonDaChon.Name = "lblSoMonDaChon";
            this.lblSoMonDaChon.Size = new System.Drawing.Size(35, 13);
            this.lblSoMonDaChon.TabIndex = 11;
            this.lblSoMonDaChon.Text = "label2";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(10, 3);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(61, 24);
            this.btnLamMoi.TabIndex = 12;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(720, 260);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "CHI TIẾT HÓA ĐƠN (Giỏ)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(777, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tìm kiếm :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 641);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.lblSoMonDaChon);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXoaTang);
            this.Controls.Add(this.btnThemTang);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.cboLoaiMon);
            this.Controls.Add(this.txtGiamGia);
            this.Controls.Add(this.txtThanhToan);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.lblThanhToan);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblGiamGia);
            this.Controls.Add(this.dgvMonAn);
            this.Controls.Add(this.btnDSNhanVien);
            this.Controls.Add(this.btnDSBill);
            this.Controls.Add(this.btnDSLoaiMon);
            this.Controls.Add(this.tcTang);
            this.Name = "MainForm";
            this.Text = "Quản Lý Nhà Hàng";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.cmsXoaBan.ResumeLayout(false);
            this.cmsXoaTang.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcTang;
        private System.Windows.Forms.Button btnDSLoaiMon;
        private System.Windows.Forms.Button btnDSBill;
        private System.Windows.Forms.Button btnDSNhanVien;
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblThanhToan;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtThanhToan;
        private System.Windows.Forms.MaskedTextBox txtGiamGia;
        private System.Windows.Forms.ComboBox cboLoaiMon;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThemTang;
        private System.Windows.Forms.ContextMenuStrip cmsXoaBan;
        private System.Windows.Forms.ToolStripMenuItem xóaBànToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsXoaTang;
        private System.Windows.Forms.ToolStripMenuItem xóaTầngToolStripMenuItem;
        private System.Windows.Forms.Button btnXoaTang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblSoMonDaChon;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label label3;
    }
}

