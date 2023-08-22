using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.Models
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly IMSDbContext _imsDbContext;

        public ManufacturerRepository(IMSDbContext imsDbContext)
        {
            _imsDbContext = imsDbContext;
        }

        public IEnumerable<Manufacturer> AllManufacturers
        {
            get
            {
                return _imsDbContext.Manufacturer;
            }
        }

    }
}
