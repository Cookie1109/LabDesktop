using Repository_Pattern.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Pattern.DAL
{
    public interface IFoodRepository
    {
        Food GetById(int FoodID);
        void Insert(Food food);
        void Update(Food food);
        void Delete(int FoodID);
        void Save();
        int Count();

        IEnumerable<Food> GetAll();
        IEnumerable<object> GetAllWithCategory();
        IEnumerable<object> GetByCategory(int categoryID);
        IEnumerable<Food> GetByName(string name);
    }
}