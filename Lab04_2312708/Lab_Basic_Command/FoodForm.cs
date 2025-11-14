using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Basic_Command
{
    public partial class FoodForm : Form
    {
        private const string CONNECTION_STRING = @"server=.; database=Lab04Desktop; integrated security=true;";

        private int _categoryId;
        private DataTable _dtFood;
        private SqlDataAdapter _adapter;

        public FoodForm()
        {
            InitializeComponent();
            LoadCategories();
            LoadAllFood();
            ClearForm();
            DisableButtons();
        }

        public void LoadFood(int categoryID)
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = @"
                SELECT * FROM Food
                WHERE FoodCategoryID = @id;
            ";

            sqlCommand.Parameters.AddWithValue("@id", categoryID);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable("Food");
            sqlDataAdapter.Fill(dataTable);

            dgvFood.DataSource = dataTable;

            sqlCommand.CommandText = @"
                SELECT Name FROM Category
                WHERE ID = @id;
            ";

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@id", categoryID);

            string categoryName = sqlCommand.ExecuteScalar().ToString();
            this.Text = $"Danh sách các món ăn thuộc nhóm: {categoryName}";

            sqlConnection.Close();
        }

        private void LoadAllFood()
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandText = "SELECT * FROM Food;";

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable("Food");
            sqlDataAdapter.Fill(dataTable);

            dgvFood.DataSource = dataTable;

            this.Text = "Danh sách tất cả món ăn";

            sqlConnection.Close();
        }
        private void LoadCategories()
        {
            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            
            sqlCommand.CommandText = "SELECT ID, Name FROM Category";
            
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            cboFoodCategoryID.DataSource = dt;
            cboFoodCategoryID.DisplayMember = "Name";
            cboFoodCategoryID.ValueMember = "ID";
            
            sqlConnection.Close();
        }
        private void dgvFood_Click(object sender, EventArgs e)
        {
            if (dgvFood.CurrentRow != null && dgvFood.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvFood.CurrentRow;
                
                txtID.Text = row.Cells["ID"].Value?.ToString() ?? "";
                txtName.Text = row.Cells["FoodName"].Value?.ToString() ?? "";
                txtUnit.Text = row.Cells["Unit"].Value?.ToString() ?? "";
            
                cboFoodCategoryID.SelectedValue = Convert.ToInt32(row.Cells["FoodCategoryID"].Value);
                
                txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? "";
                txtNotes.Text = row.Cells["Notes"].Value?.ToString() ?? "";
                
                EnableButtons();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn!");
                return;
            }

            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                sqlCommand.CommandText = @"
                    INSERT INTO Food(Name, Unit, FoodCategoryID, Price, Notes)
                    VALUES (@name, @unit, @catId, @price, @notes);
                ";
            }
            else
            {
                sqlCommand.CommandText = @"
                    UPDATE Food
                    SET Name = @name,
                        Unit = @unit,
                        FoodCategoryID = @catId,
                        Price = @price,
                        Notes = @notes
                    WHERE ID = @id;
                ";
                sqlCommand.Parameters.AddWithValue("@id", int.Parse(txtID.Text));
            }

            sqlCommand.Parameters.AddWithValue("@name", txtName.Text);
            sqlCommand.Parameters.AddWithValue("@unit", txtUnit.Text);
            sqlCommand.Parameters.AddWithValue("@catId", cboFoodCategoryID.SelectedValue);

            double price = double.Parse(txtPrice.Text);
            sqlCommand.Parameters.AddWithValue("@price", price);
            
            sqlCommand.Parameters.AddWithValue("@notes", txtNotes.Text);

            sqlConnection.Open();
            int result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (result > 0)
            {
                MessageBox.Show("Lưu thông tin món ăn thành công!");
                
                LoadAllFood();
                
                ClearForm();
                DisableButtons();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa!");
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa món ăn '{txtName.Text}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult == DialogResult.Yes)
            {
                SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "DELETE FROM Food WHERE ID = @id";
                sqlCommand.Parameters.AddWithValue("@id", int.Parse(txtID.Text));

                sqlConnection.Open();
                int result = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (result > 0)
                {
                    MessageBox.Show("Xóa món ăn thành công!");
                    
                    LoadAllFood();
                    
                    ClearForm();
                    DisableButtons();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại!");
                }
            }
        }
        private void ClearForm()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtUnit.Text = "";
            txtPrice.Text = "";
            txtNotes.Text = "";
            
            if (cboFoodCategoryID.Items.Count > 0)
            {
                cboFoodCategoryID.SelectedIndex = 0;
            }
        }
        private void DisableButtons()
        {
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
        }

        private void EnableButtons()
        {
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
        }
    }
}
