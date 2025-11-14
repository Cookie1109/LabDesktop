using Repository_Pattern.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Pattern.DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Database1Entities1 _context;

        public CategoryRepository()
        {
            _context = new Database1Entities1();
        }

        public CategoryRepository(Database1Entities1 context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public int Count()
        {
            return _context.Categories.Count();
        }
    }
}