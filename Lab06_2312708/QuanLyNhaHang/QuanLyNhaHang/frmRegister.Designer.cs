namespace QuanLyNhaHang
{
    partial class frmRegister
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(210, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(99, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Đăng ký";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(70, 70);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Họ và Tên :";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(70, 194);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(61, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Tài khoản :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(70, 220);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(58, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Mật khẩu :";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(70, 247);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(106, 13);
            this.lblConfirmPassword.TabIndex = 4;
            this.lblConfirmPassword.Text = "Xác nhận mật khẩu :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(190, 67);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(280, 20);
            this.txtName.TabIndex = 5;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(190, 191);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(280, 20);
            this.txtUsername.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(190, 217);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(280, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(190, 244);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(280, 20);
            this.txtConfirmPassword.TabIndex = 8;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(220, 310);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(90, 30);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(70, 95);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(53, 13);
            this.lblGioiTinh.TabIndex = 10;
            this.lblGioiTinh.Text = "Giới tính :";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGioiTinh.Location = new System.Drawing.Point(190, 92);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(280, 21);
            this.cboGioiTinh.TabIndex = 11;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(70, 120);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(76, 13);
            this.lblSDT.TabIndex = 12;
            this.lblSDT.Text = "Số điện thoại :";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(190, 117);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(280, 20);
            this.txtSDT.TabIndex = 13;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(70, 145);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(53, 13);
            this.lblRole.TabIndex = 14;
            this.lblRole.Text = "Chức vụ :";
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(190, 142);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(280, 21);
            this.cboRole.TabIndex = 15;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 370);
            this.Controls.Add(this.cboRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký";
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
    }
}