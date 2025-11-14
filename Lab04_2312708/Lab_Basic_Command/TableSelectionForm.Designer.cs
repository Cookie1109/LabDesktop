namespace Lab_Basic_Command
{
    partial class TableSelectionForm
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
            this.lvTables = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvTables
            // 
            this.lvTables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chName,
            this.chStatus,
            this.chNotes});
            this.lvTables.FullRowSelect = true;
            this.lvTables.GridLines = true;
            this.lvTables.HideSelection = false;
            this.lvTables.Location = new System.Drawing.Point(9, 11);
            this.lvTables.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvTables.MultiSelect = false;
            this.lvTables.Name = "lvTables";
            this.lvTables.Size = new System.Drawing.Size(571, 336);
            this.lvTables.TabIndex = 0;
            this.lvTables.UseCompatibleStateImageBehavior = false;
            this.lvTables.View = System.Windows.Forms.View.Details;
            this.lvTables.Click += new System.EventHandler(this.lvTables_Click);
            this.lvTables.DoubleClick += new System.EventHandler(this.lvTables_DoubleClick);
            // 
            // chID
            // 
            this.chID.Text = "Mã bàn";
            this.chID.Width = 80;
            // 
            // chName
            // 
            this.chName.Text = "Tên bàn";
            this.chName.Width = 200;
            // 
            // chStatus
            // 
            this.chStatus.Text = "Trạng thái";
            this.chStatus.Width = 150;
            // 
            // chNotes
            // 
            this.chNotes.Text = "Ghi chú";
            this.chNotes.Width = 300;
            // 
            // btnSelect
            // 
            this.btnSelect.Enabled = false;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(414, 358);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(82, 32);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Chọn";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(501, 358);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TableSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 401);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lvTables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TableSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn bàn";
            this.Load += new System.EventHandler(this.TableSelectionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvTables;
        private System.Windows.Forms.ColumnHeader chID;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ColumnHeader chNotes;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
    }
}
