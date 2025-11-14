namespace QuanLyNhaHang
{
    partial class frmRole
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
            this.dataGridViewRoles = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRoles
            // 
            this.dataGridViewRoles.AllowUserToAddRows = false;
            this.dataGridViewRoles.AllowUserToDeleteRows = false;
            this.dataGridViewRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRoles.Location = new System.Drawing.Point(12, 80);
            this.dataGridViewRoles.Name = "dataGridViewRoles";
            this.dataGridViewRoles.ReadOnly = true;
            this.dataGridViewRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRoles.Size = new System.Drawing.Size(460, 300);
            this.dataGridViewRoles.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 40);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(397, 40);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(176, 45);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(200, 20);
            this.txtRoleName.TabIndex = 3;
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Location = new System.Drawing.Point(105, 48);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(65, 13);
            this.lblRoleName.TabIndex = 4;
            this.lblRoleName.Text = "Tên vai trò :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(150, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 20);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Quản lý Chức vụ/Vai trò";
            // 
            // frmRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 392);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRoleName);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dataGridViewRoles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Vai trò";
            this.Load += new System.EventHandler(this.frmRole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRoles;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.Label lblTitle;
    }
}