using AutoMapper;
using IMS.Infrastructure.Repositories;
using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int limit = 10)
        {
            var product = await _productRepository.GetProductsAsync(page, limit);
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(product));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            await _productRepository.CreateProductAsync(product);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> Put(int productId, ProductDto productDTO)
        {
            if (productId != productDTO.ProductId)
            {
                return BadRequest();
            }

            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.UpdateProductAsync(product, _mapper.Map<Product>(productDTO));

            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteOwner(int productId)
        {

            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            await _productRepository.DeleteProductAsync(productId);

            return Ok();

        }

    }
}
