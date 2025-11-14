namespace QuanLyNhaHang
{
    partial class frmLoaiMon
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
            this.dgvDSLoai = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaNhom = new System.Windows.Forms.TextBox();
            this.txtTenNhom = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.cmsXoaLoai = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaLoạiMónĂnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDanhSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSLoai)).BeginInit();
            this.cmsXoaLoai.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDSLoai
            // 
            this.dgvDSLoai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSLoai.ColumnHeadersHeight = 29;
            this.dgvDSLoai.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvDSLoai.Location = new System.Drawing.Point(0, 0);
            this.dgvDSLoai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDSLoai.Name = "dgvDSLoai";
            this.dgvDSLoai.ReadOnly = true;
            this.dgvDSLoai.RowHeadersVisible = false;
            this.dgvDSLoai.RowHeadersWidth = 51;
            this.dgvDSLoai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSLoai.Size = new System.Drawing.Size(823, 789);
            this.dgvDSLoai.TabIndex = 0;
            this.dgvDSLoai.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSLoai_CellClick);
            this.dgvDSLoai.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSLoai_CellDoubleClick);
            this.dgvDSLoai.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDSLoai_DataError);
            this.dgvDSLoai.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDSLoai_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(857, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã nhóm :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(857, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên nhóm :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(857, 233);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Loại :";
            // 
            // txtMaNhom
            // 
            this.txtMaNhom.Location = new System.Drawing.Point(992, 119);
            this.txtMaNhom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaNhom.Name = "txtMaNhom";
            this.txtMaNhom.ReadOnly = true;
            this.txtMaNhom.Size = new System.Drawing.Size(341, 22);
            this.txtMaNhom.TabIndex = 2;
            // 
            // txtTenNhom
            // 
            this.txtTenNhom.Location = new System.Drawing.Point(992, 175);
            this.txtTenNhom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenNhom.Name = "txtTenNhom";
            this.txtTenNhom.Size = new System.Drawing.Size(341, 22);
            this.txtTenNhom.TabIndex = 2;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(919, 320);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(145, 28);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(1152, 320);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(145, 28);
            this.btnCapNhat.TabIndex = 3;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // cboLoai
            // 
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Items.AddRange(new object[] {
            "Đồ ăn",
            "Đồ uống"});
            this.cboLoai.Location = new System.Drawing.Point(992, 229);
            this.cboLoai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(341, 24);
            this.cboLoai.TabIndex = 4;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(841, 14);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 26);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // cmsXoaLoai
            // 
            this.cmsXoaLoai.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsXoaLoai.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaLoạiMónĂnToolStripMenuItem,
            this.xemDanhSáchToolStripMenuItem});
            this.cmsXoaLoai.Name = "cmsXoaLoai";
            this.cmsXoaLoai.Size = new System.Drawing.Size(188, 52);
            // 
            // xóaLoạiMónĂnToolStripMenuItem
            // 
            this.xóaLoạiMónĂnToolStripMenuItem.Name = "xóaLoạiMónĂnToolStripMenuItem";
            this.xóaLoạiMónĂnToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.xóaLoạiMónĂnToolStripMenuItem.Text = "Xóa loại món ăn";
            this.xóaLoạiMónĂnToolStripMenuItem.Click += new System.EventHandler(this.xóaLoạiMónĂnToolStripMenuItem_Click);
            // 
            // xemDanhSáchToolStripMenuItem
            // 
            this.xemDanhSáchToolStripMenuItem.Name = "xemDanhSáchToolStripMenuItem";
            this.xemDanhSáchToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.xemDanhSáchToolStripMenuItem.Text = "Xem danh sách";
            this.xemDanhSáchToolStripMenuItem.Click += new System.EventHandler(this.xemDanhSáchToolStripMenuItem_Click);
            // 
            // frmLoaiMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 789);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.cboLoai);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtTenNhom);
            this.Controls.Add(this.txtMaNhom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDSLoai);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmLoaiMon";
            this.Text = "LoaiMonAn";
            this.Load += new System.EventHandler(this.frmLoaiMon_Load);
            this.Shown += new System.EventHandler(this.frmLoaiMon_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSLoai)).EndInit();
            this.cmsXoaLoai.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSLoai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaNhom;
        private System.Windows.Forms.TextBox txtTenNhom;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.ContextMenuStrip cmsXoaLoai;
        private System.Windows.Forms.ToolStripMenuItem xóaLoạiMónĂnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemDanhSáchToolStripMenuItem;
    }
}