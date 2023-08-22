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

        public IEnumerable<Product> AllProduct
        {
            get
            {
                return _imsDbContext.Product;
            }
        }

    }
}
