using Repository_Pattern.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Pattern.DAL
{
    public class FoodRepository : IFoodRepository, IDisposable
    {
        private readonly Database1Entities1 _context;
        public FoodRepository()
        {
            _context = new Database1Entities1();
        }

        public FoodRepository(Database1Entities1 context)
        {
            _context = context;
        }

        public IEnumerable<Food> GetAll()
        {
            return _context.Foods.ToList();
        }

        public Food GetById(int FoodID)
        {
            return _context.Foods.Find(FoodID);
        }

        public void Insert(Food food)
        {
            _context.Foods.Add(food);
        }

        public void Update(Food food)
        {
            _context.Entry(food).State = EntityState.Modified;
        }

        public void Delete(int FoodID)
        {
            Food food = _context.Foods.Find(FoodID);
            if (food != null)
            {
                _context.Foods.Remove(food);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public int Count()
        {
            return _context.Foods.Count();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<object> GetAllWithCategory()
        {
            return _context.Foods.Select(f => new
            {
                f.ID,
                f.Name,
                f.Unit,
                CategoryID = f.Category.ID,
                CategoryName = f.Category.Name,
                f.Price,
                f.Notes
            }).ToList();
        }

        public IEnumerable<object> GetByCategory(int categoryID)
        {
            return _context.Foods
                .Where(f => f.CategoryID == categoryID)
                .Select(f => new
                {
                    f.ID,
                    f.Name,
                    f.Unit,
                    CategoryID = f.Category.ID,
                    CategoryName = f.Category.Name,
                    f.Price,
                    f.Notes
                }).ToList();
        }

        public IEnumerable<Food> GetByName(string name)
        {
            return _context.Foods
                .Where(f => f.Name.Contains(name))
                .ToList();
        }
    }
}