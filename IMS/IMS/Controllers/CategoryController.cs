using AutoMapper;
using IMS.Infrastructure.Repositories;
using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int limit = int.MaxValue)
        {
            var category = await _categoryRepository.GetCategoriesAsync(page, limit);
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(category));
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> Get(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            await _categoryRepository.CreateCategoryAsync(category);

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> Put(int categoryId, CategoryDto categoryDto)
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

            await _categoryRepository.UpdateCategoryAsync(category, _mapper.Map<Category>(categoryDto));

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
