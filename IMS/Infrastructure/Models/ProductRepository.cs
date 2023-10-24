using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMSDbContext _imsDbContext;

        public ProductRepository(IMSDbContext imsDbContext)
        {
            _imsDbContext = imsDbContext;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(int page, int limit)
        {
            return await _imsDbContext.Product
                .OrderBy(c => c.ProductName)
                .Skip(page - 1)
                .Take(limit)
                .ToListAsync();

        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _imsDbContext.Product.FirstOrDefaultAsync(c => c.ProductId == id);

        }

        public async Task CreateProductAsync(Product product)
        {

            _ = await _imsDbContext.Product.AddAsync(product);

            _ = await _imsDbContext.SaveChangesAsync();

        }
        public async Task UpdateProductAsync(Product product, Product productDTO)
        {
            product.ProductName = productDTO.ProductName;
            product.CategoryID = productDTO.CategoryID;
            product.ManufacturerID = productDTO.ManufacturerID;
            product.Description = productDTO.Description;
            product.UnitPrice = productDTO.UnitPrice;
            product.QuantityInStock = productDTO.QuantityInStock;
            product.MinimumQuantity = productDTO.MinimumQuantity;
            product.MaximumQuantity = productDTO.MaximumQuantity;
            product.UPC = productDTO.UPC;

            _ = await _imsDbContext.SaveChangesAsync();

        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _imsDbContext.Product.FirstOrDefaultAsync(c => c.ProductId == id);
            if (product != null)
            {
                _imsDbContext.Product.Remove(product);
            }

            await _imsDbContext.SaveChangesAsync();

        }

    }
}
