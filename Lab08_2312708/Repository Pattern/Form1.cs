using Repository_Pattern.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repository_Pattern
{
    public partial class Form1 : Form
    {
        private readonly Database1Entities1 db_context;
        public Form1()
        {
            InitializeComponent();
            db_context = new Database1Entities1();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IFoodRepository foodRepo = new FoodRepository(db_context);
            ICategoryRepository categoryRepo = new CategoryRepository(db_context);

            int totalFood = foodRepo.Count();
            int totalCategory = categoryRepo.Count();

            lblFoodCount.Text = "Tổng số món ăn: " + totalFood.ToString();
            lblCategoryCount.Text = "Tổng số danh mục: " + totalCategory.ToString();

            var categories = db_context.Categories
                                .Select(c => new { c.ID, c.Name })
                                .ToList();

            categories.Insert(0, new { ID = 0, Name = "Tất cả" });

            cbbCategory.DataSource = categories;
            cbbCategory.DisplayMember = "Name";
            cbbCategory.ValueMember = "ID";

            LoadData();
        }

        private void LoadData()
        {
            IFoodRepository foodRepo = new FoodRepository(db_context);
            var result = foodRepo.GetAllWithCategory();

            dataGridView1.DataSource = result;
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            IFoodRepository foodRepo = new FoodRepository(db_context);
            object result;
            int selectedIndex = cbbCategory.SelectedIndex;
            if (selectedIndex == 0)
            {
                result = foodRepo.GetAllWithCategory();
            }
            else
            {
                int categoryID = Convert.ToInt32(cbbCategory.SelectedValue);
                result = foodRepo.GetByCategory(categoryID);
            }
            dataGridView1.DataSource = result;
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            string name = txtSearchByName.Text;
            IFoodRepository foodRepo = new FoodRepository(db_context);
            var result = foodRepo.GetByName(name);
            dataGridView1.DataSource = result;
        }
    }
}
