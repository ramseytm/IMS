using IMS.Models;
using Microsoft.AspNetCore.Mvc;

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
            var allCategory = _CategoryRepository.AllCategory;
            return Ok(allCategory);
        }

    }
}
