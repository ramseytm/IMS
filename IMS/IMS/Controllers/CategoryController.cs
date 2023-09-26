using IMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryController(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allCategory = _CategoryRepository.AllCategories;
            return Ok(allCategory);
        }

        [HttpGet]
        public IActionResult Get(int page = 1, int limit = 10)
        {
            var category = _CategoryRepository.GetCategories(page,limit);
            return Ok(category);
        }

        [HttpGet("{category_id}")]
        public IActionResult Get(int categoryId)
        {
            var category = _CategoryRepository.GetCategoryById(categoryId);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            _CategoryRepository.CreateCategory(category);

            return Ok(category);
        }

        [HttpPut("{category_id}")]
        public async Task<IActionResult> Put(int categoryId, Category categoryDTO)
        {
            if (categoryId != categoryDTO.CategoryId)
            {
                return BadRequest();
            }

            var category = _CategoryRepository.GetCategoryById(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            _CategoryRepository.UpdateCategory(category, categoryDTO);

            return Ok();
        }

        [HttpDelete("{category_id}")]
        public IActionResult DeleteOwner(int categoryId)
        {
            
            var category = _CategoryRepository.GetCategoryById(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            _CategoryRepository.DeleteCategory(categoryId);

            return Ok();
            
           
        }
    }
}
