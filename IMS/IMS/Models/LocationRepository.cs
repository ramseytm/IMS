using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.Models
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IMSDbContext _imsDbContext;

        public LocationRepository(IMSDbContext imsDbContext)
        {
            _imsDbContext = imsDbContext;
        }

        public IEnumerable<Location> AllLocations
        {
            get
            {
                return _imsDbContext.Location;
            }
        }

    }
}
