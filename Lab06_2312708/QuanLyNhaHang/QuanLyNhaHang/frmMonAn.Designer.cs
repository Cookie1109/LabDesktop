namespace QuanLyNhaHang
{
    partial class frmMonAn
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
            this.dgvDSMonAn = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.txtMaMon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.MaskedTextBox();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.cmsXoaMonAn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaMónĂnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSMonAn)).BeginInit();
            this.cmsXoaMonAn.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDSMonAn
            // 
            this.dgvDSMonAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSMonAn.ColumnHeadersHeight = 29;
            this.dgvDSMonAn.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvDSMonAn.Location = new System.Drawing.Point(0, 0);
            this.dgvDSMonAn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDSMonAn.Name = "dgvDSMonAn";
            this.dgvDSMonAn.ReadOnly = true;
            this.dgvDSMonAn.RowHeadersVisible = false;
            this.dgvDSMonAn.RowHeadersWidth = 51;
            this.dgvDSMonAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSMonAn.Size = new System.Drawing.Size(860, 789);
            this.dgvDSMonAn.TabIndex = 0;
            this.dgvDSMonAn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSMonAn_CellClick);
            this.dgvDSMonAn.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDSMonAn_DataError);
            this.dgvDSMonAn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDSMonAn_MouseDown);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(867, 12);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 26);
            this.btnLamMoi.TabIndex = 14;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(1177, 434);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(145, 28);
            this.btnCapNhat.TabIndex = 11;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(944, 434);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(145, 28);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(1017, 174);
            this.txtTenMon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(341, 22);
            this.txtTenMon.TabIndex = 9;
            // 
            // txtMaMon
            // 
            this.txtMaMon.Location = new System.Drawing.Point(1017, 118);
            this.txtMaMon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.ReadOnly = true;
            this.txtMaMon.Size = new System.Drawing.Size(341, 22);
            this.txtMaMon.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(883, 347);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ghi chú :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(883, 177);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên món :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(883, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mã món :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(883, 235);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Đơn giá :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(883, 292);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Đơn vị tính :";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(1017, 343);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(341, 22);
            this.txtGhiChu.TabIndex = 9;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(1017, 231);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDonGia.Mask = "00000000";
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(341, 22);
            this.txtDonGia.TabIndex = 15;
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(1017, 288);
            this.txtDonVi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Size = new System.Drawing.Size(341, 22);
            this.txtDonVi.TabIndex = 9;
            // 
            // cmsXoaMonAn
            // 
            this.cmsXoaMonAn.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsXoaMonAn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaMónĂnToolStripMenuItem});
            this.cmsXoaMonAn.Name = "cmsXoaMonAn";
            this.cmsXoaMonAn.Size = new System.Drawing.Size(159, 28);
            // 
            // xóaMónĂnToolStripMenuItem
            // 
            this.xóaMónĂnToolStripMenuItem.Name = "xóaMónĂnToolStripMenuItem";
            this.xóaMónĂnToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.xóaMónĂnToolStripMenuItem.Text = "Xóa món ăn";
            this.xóaMónĂnToolStripMenuItem.Click += new System.EventHandler(this.xóaMónĂnToolStripMenuItem_Click);
            // 
            // frmMonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 789);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtDonVi);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtTenMon);
            this.Controls.Add(this.txtMaMon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDSMonAn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMonAn";
            this.Text = "MonAn";
            this.Load += new System.EventHandler(this.frmMonAn_Load);
            this.Shown += new System.EventHandler(this.frmMonAn_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSMonAn)).EndInit();
            this.cmsXoaMonAn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSMonAn;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.TextBox txtMaMon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.MaskedTextBox txtDonGia;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.ContextMenuStrip cmsXoaMonAn;
        private System.Windows.Forms.ToolStripMenuItem xóaMónĂnToolStripMenuItem;
    }
}