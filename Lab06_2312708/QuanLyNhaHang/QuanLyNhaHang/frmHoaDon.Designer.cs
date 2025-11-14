namespace QuanLyNhaHang
{
    partial class frmHoaDon
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
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.btnTatCa = new System.Windows.Forms.Button();
            this.btnHienThiDS = new System.Windows.Forms.Button();
            this.rbTheoNam = new System.Windows.Forms.RadioButton();
            this.rbTheoThang = new System.Windows.Forms.RadioButton();
            this.rbTheoNgay = new System.Windows.Forms.RadioButton();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.cboNamThang = new System.Windows.Forms.ComboBox();
            this.cboNam = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 0);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(631, 641);
            this.dgvHoaDon.TabIndex = 0;
            // 
            // btnTatCa
            // 
            this.btnTatCa.Location = new System.Drawing.Point(655, 12);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(109, 36);
            this.btnTatCa.TabIndex = 10;
            this.btnTatCa.Text = "Tất cả";
            this.btnTatCa.UseVisualStyleBackColor = true;
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // btnHienThiDS
            // 
            this.btnHienThiDS.Location = new System.Drawing.Point(785, 245);
            this.btnHienThiDS.Name = "btnHienThiDS";
            this.btnHienThiDS.Size = new System.Drawing.Size(109, 45);
            this.btnHienThiDS.TabIndex = 11;
            this.btnHienThiDS.Text = "Hiển thị danh sách";
            this.btnHienThiDS.UseVisualStyleBackColor = true;
            this.btnHienThiDS.Click += new System.EventHandler(this.btnHienThiDS_Click);
            // 
            // rbTheoNam
            // 
            this.rbTheoNam.AutoSize = true;
            this.rbTheoNam.Location = new System.Drawing.Point(652, 200);
            this.rbTheoNam.Name = "rbTheoNam";
            this.rbTheoNam.Size = new System.Drawing.Size(76, 17);
            this.rbTheoNam.TabIndex = 4;
            this.rbTheoNam.Text = "Theo năm";
            this.rbTheoNam.UseVisualStyleBackColor = true;
            this.rbTheoNam.CheckedChanged += new System.EventHandler(this.rbTheoNam_CheckedChanged);
            // 
            // rbTheoThang
            // 
            this.rbTheoThang.AutoSize = true;
            this.rbTheoThang.Location = new System.Drawing.Point(652, 156);
            this.rbTheoThang.Name = "rbTheoThang";
            this.rbTheoThang.Size = new System.Drawing.Size(83, 17);
            this.rbTheoThang.TabIndex = 5;
            this.rbTheoThang.Text = "Theo tháng";
            this.rbTheoThang.UseVisualStyleBackColor = true;
            this.rbTheoThang.CheckedChanged += new System.EventHandler(this.rbTheoThang_CheckedChanged);
            // 
            // rbTheoNgay
            // 
            this.rbTheoNgay.AutoSize = true;
            this.rbTheoNgay.Checked = true;
            this.rbTheoNgay.Location = new System.Drawing.Point(652, 111);
            this.rbTheoNgay.Name = "rbTheoNgay";
            this.rbTheoNgay.Size = new System.Drawing.Size(79, 17);
            this.rbTheoNgay.TabIndex = 6;
            this.rbTheoNgay.TabStop = true;
            this.rbTheoNgay.Text = "Theo ngày";
            this.rbTheoNgay.UseVisualStyleBackColor = true;
            this.rbTheoNgay.CheckedChanged += new System.EventHandler(this.rbTheoNgay_CheckedChanged);
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(754, 111);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(247, 20);
            this.dtpNgay.TabIndex = 12;
            // 
            // cboThang
            // 
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(754, 153);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(140, 21);
            this.cboThang.TabIndex = 13;
            // 
            // cboNamThang
            // 
            this.cboNamThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamThang.FormattingEnabled = true;
            this.cboNamThang.Location = new System.Drawing.Point(900, 153);
            this.cboNamThang.Name = "cboNamThang";
            this.cboNamThang.Size = new System.Drawing.Size(101, 21);
            this.cboNamThang.TabIndex = 14;
            // 
            // cboNam
            // 
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(754, 197);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(101, 21);
            this.cboNam.TabIndex = 14;
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 641);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.cboNamThang);
            this.Controls.Add(this.cboThang);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.btnTatCa);
            this.Controls.Add(this.btnHienThiDS);
            this.Controls.Add(this.rbTheoNam);
            this.Controls.Add(this.rbTheoThang);
            this.Controls.Add(this.rbTheoNgay);
            this.Controls.Add(this.dgvHoaDon);
            this.Name = "frmHoaDon";
            this.Text = "Danh Sách Hóa Đơn";
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnTatCa;
        private System.Windows.Forms.Button btnHienThiDS;
        private System.Windows.Forms.RadioButton rbTheoNam;
        private System.Windows.Forms.RadioButton rbTheoThang;
        private System.Windows.Forms.RadioButton rbTheoNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.ComboBox cboNamThang;
        private System.Windows.Forms.ComboBox cboNam;
    }
}