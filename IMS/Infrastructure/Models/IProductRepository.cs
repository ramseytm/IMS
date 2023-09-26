namespace IMS.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> GetProducts(int page, int limit);
        Product? GetProductById(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product, Product productDTO);
        void DeleteProduct(int id);
    }
}
