using System.IO.Pipelines;

namespace IMS.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
        IEnumerable<Category> GetCategories(int page, int limit);
        Category? GetCategoryById(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category, Category categoryDTO);
        void DeleteCategory(int id);

    }
}
