namespace IMS.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProduct { get; }
    }
}
