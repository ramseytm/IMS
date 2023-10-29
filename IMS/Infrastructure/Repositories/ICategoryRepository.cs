using IMS.Models;

namespace IMS.Infrastructure.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(int page, int limit);

        Task<Category?> GetCategoryByIdAsync(int id);

        Task CreateCategoryAsync(Category category);

        Task UpdateCategoryAsync(Category category, Category categoryDto);

        Task DeleteCategoryAsync(int id);
    }
}
