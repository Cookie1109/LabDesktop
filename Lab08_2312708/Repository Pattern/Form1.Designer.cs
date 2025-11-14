namespace Repository_Pattern
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbbCategory = new System.Windows.Forms.ComboBox();
            this.txtSearchByName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFoodCount = new System.Windows.Forms.Label();
            this.lblCategoryCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(776, 321);
            this.dataGridView1.TabIndex = 0;
            // 
            // cbbCategory
            // 
            this.cbbCategory.FormattingEnabled = true;
            this.cbbCategory.Location = new System.Drawing.Point(123, 29);
            this.cbbCategory.Name = "cbbCategory";
            this.cbbCategory.Size = new System.Drawing.Size(215, 21);
            this.cbbCategory.TabIndex = 1;
            this.cbbCategory.SelectedIndexChanged += new System.EventHandler(this.cbbCategory_SelectedIndexChanged);
            // 
            // txtSearchByName
            // 
            this.txtSearchByName.Location = new System.Drawing.Point(537, 30);
            this.txtSearchByName.Name = "txtSearchByName";
            this.txtSearchByName.Size = new System.Drawing.Size(251, 20);
            this.txtSearchByName.TabIndex = 2;
            this.txtSearchByName.TextChanged += new System.EventHandler(this.txtSearchByName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chọn nhóm món ăn :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tìm kiếm theo tên :";
            // 
            // lblFoodCount
            // 
            this.lblFoodCount.AutoSize = true;
            this.lblFoodCount.Location = new System.Drawing.Point(25, 413);
            this.lblFoodCount.Name = "lblFoodCount";
            this.lblFoodCount.Size = new System.Drawing.Size(96, 13);
            this.lblFoodCount.TabIndex = 4;
            this.lblFoodCount.Text = "Tổng số món ăn: 0";
            // 
            // lblCategoryCount
            // 
            this.lblCategoryCount.AutoSize = true;
            this.lblCategoryCount.Location = new System.Drawing.Point(218, 413);
            this.lblCategoryCount.Name = "lblCategoryCount";
            this.lblCategoryCount.Size = new System.Drawing.Size(108, 13);
            this.lblCategoryCount.TabIndex = 4;
            this.lblCategoryCount.Text = "Tổng số danh mục: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 448);
            this.Controls.Add(this.lblCategoryCount);
            this.Controls.Add(this.lblFoodCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearchByName);
            this.Controls.Add(this.cbbCategory);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbbCategory;
        private System.Windows.Forms.TextBox txtSearchByName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFoodCount;
        private System.Windows.Forms.Label lblCategoryCount;
    }
}

