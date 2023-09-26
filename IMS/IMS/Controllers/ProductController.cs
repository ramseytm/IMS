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
            var allProduct = _ProductRepository.AllProducts;
            return Ok(allProduct);
        }
        [HttpGet]
        public IActionResult Get(int page = 1, int limit = 10)
        {
            var product = _ProductRepository.GetProducts(page, limit);
            return Ok(product);
        }

        [HttpGet("{product_id}")]
        public IActionResult Get(int productId)
        {
            var product = _ProductRepository.GetProductById(productId);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            _ProductRepository.CreateProduct(product);

            return Ok(product);
        }

        [HttpPut("{product_id}")]
        public async Task<IActionResult> Put(int productId, Product productDTO)
        {
            if (productId != productDTO.ProductId)
            {
                return BadRequest();
            }

            var product = _ProductRepository.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }

            _ProductRepository.UpdateProduct(product, productDTO);

            return Ok();
        }

        [HttpDelete("{product_id}")]
        public IActionResult DeleteOwner(int productId)
        {

            var product = _ProductRepository.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }

            _ProductRepository.DeleteProduct(productId);

            return Ok();

        }

    }
}
