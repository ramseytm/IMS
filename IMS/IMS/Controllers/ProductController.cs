using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _ProductRepository;

        public ProductController(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var allProduct = _ProductRepository.AllProduct;
            return Ok(allProduct);
        }

    }
}
