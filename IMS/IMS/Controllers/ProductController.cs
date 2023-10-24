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
        public async Task<IActionResult> Get(int page = 1, int limit = 10)
        {
            var product = await _ProductRepository.GetProductsAsync(page, limit);
            return Ok(product);
        }

        [HttpGet("{product_id}")]
        public async Task<IActionResult> Get(int productId)
        {
            var product = await _ProductRepository.GetProductByIdAsync(productId);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            await _ProductRepository.CreateProductAsync(product);

            return Ok(product);
        }

        [HttpPut("{product_id}")]
        public async Task<IActionResult> Put(int productId, Product productDTO)
        {
            if (productId != productDTO.ProductId)
            {
                return BadRequest();
            }

            var product = await _ProductRepository.GetProductByIdAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            await _ProductRepository.UpdateProductAsync(product, productDTO);

            return Ok();
        }

        [HttpDelete("{product_id}")]
        public async Task<IActionResult> DeleteOwner(int productId)
        {

            var product = await _ProductRepository.GetProductByIdAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            await _ProductRepository.DeleteProductAsync(productId);

            return Ok();

        }

    }
}
