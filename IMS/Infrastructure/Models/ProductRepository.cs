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

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _imsDbContext.Product;
            }
        }

        public IEnumerable<Product> GetProducts(int page, int limit)
        {
            return _imsDbContext.Product
                .OrderBy(c => c.ProductName)
                .Skip(page - 1)
                .Take(limit)
                .ToList();

        }

        public Product? GetProductById(int id)
        {
            return _imsDbContext.Product.FirstOrDefault(c => c.ProductId == id);

        }

        public void CreateProduct(Product product)
        {

            _imsDbContext.Product.Add(product);

            _imsDbContext.SaveChanges();

        }
        public void UpdateProduct(Product product, Product productDTO)
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

            _imsDbContext.SaveChanges();

        }

        public void DeleteProduct(int id)
        {
            _imsDbContext.Remove(id);

            _imsDbContext.SaveChanges();

        }

    }
}
