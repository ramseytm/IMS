using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMSDbContext _imsDbContext;

        public CategoryRepository(IMSDbContext imsDbContext)
        {
            _imsDbContext = imsDbContext;
        }

        public IEnumerable<Category> AllCategories
        {
            get
            {
                return _imsDbContext.Category;
            }
        }

    }
}
