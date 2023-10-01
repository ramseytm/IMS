using IMS.Infrastructure.Models;
using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int limit = int.MaxValue)
        {
            var category = await _categoryRepository.GetCategoriesAsync(page, limit);
            return Ok(category);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> Get(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            await _categoryRepository.CreateCategoryAsync(category);

            return Ok(category);
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> Put(int categoryId, Category categoryDto)
        {
            if (categoryId != categoryDto.CategoryId)
            {
                return BadRequest();
            }

            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryRepository.UpdateCategoryAsync(category, categoryDto);

            return Ok();
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteOwner(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryRepository.DeleteCategoryAsync(categoryId);

            return Ok();
        }
    }
}
