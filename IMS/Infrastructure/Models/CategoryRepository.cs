using IMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

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

        public IEnumerable<Category> GetCategories(int page, int limit)
        {
            return _imsDbContext.Category
                .OrderBy(c => c.CategoryName)
                .Skip(page - 1)
                .Take(limit)
                .ToList();

        }

        public Category? GetCategoryById(int id)
        {
            return _imsDbContext.Category.FirstOrDefault(c => c.CategoryId == id);

        }

        public void CreateCategory(Category category)
        {

            _imsDbContext.Category.Add(category);

            _imsDbContext.SaveChanges();

        }
        public void UpdateCategory(Category category, Category categoryDTO)
        {
            category.CategoryName = categoryDTO.CategoryName;
            category.ParentCategory = categoryDTO.ParentCategory;
            category.Description = categoryDTO.Description;

            _imsDbContext.SaveChanges();

        }

        public void DeleteCategory(int id)
        {
            _imsDbContext.Remove(id);

            _imsDbContext.SaveChanges();

        }

    }
}
