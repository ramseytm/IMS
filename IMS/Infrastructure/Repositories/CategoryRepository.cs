using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMSDbContext _imsDbContext;

        public CategoryRepository(IMSDbContext imsDbContext)
        {
            _imsDbContext = imsDbContext;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(int page, int limit)
        {
            return await _imsDbContext.Category
                .OrderBy(c => c.CategoryName)
                .Skip(page - 1)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _imsDbContext.Category.FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task CreateCategoryAsync(Category category)
        {
            _ = await _imsDbContext.Category.AddAsync(category);

            _ = await _imsDbContext.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category, Category categoryDto)
        {
            category.CategoryName = categoryDto.CategoryName;
            category.ParentCategory = categoryDto.ParentCategory;
            category.Description = categoryDto.Description;

            _ = await _imsDbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _imsDbContext.Category.FirstOrDefaultAsync(c => c.CategoryId == id);
            if (category != null)
            {
                _imsDbContext.Category.Remove(category);
            }

            await _imsDbContext.SaveChangesAsync();
        }
    }
}
