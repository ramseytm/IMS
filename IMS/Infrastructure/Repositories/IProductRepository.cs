using IMS.Models;

namespace IMS.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync(int page, int limit);
        Task<Product?> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product, Product productDTO);
        Task DeleteProductAsync(int id);
    }
}
