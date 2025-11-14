using Repository_Pattern.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Pattern.DAL
{
    public interface ICategoryRepository
    {
        // Lấy tất cả danh mục
        IEnumerable<Category> GetAll();

        // Đếm tổng số danh mục (cho bài tập)
        int Count();
    }
}