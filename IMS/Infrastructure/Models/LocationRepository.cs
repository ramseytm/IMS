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

        public async Task<IEnumerable<Location>> GetLocationsAsync(int page, int limit)
        {
            return await _imsDbContext.Location
                .OrderBy(c => c.LocationName)
                .Skip(page - 1)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Location?> GetLocationByIdAsync(int id)
        {
            return await _imsDbContext.Location.FirstOrDefaultAsync(c => c.LocationId == id);

        }

        public async Task CreateLocationAsync(Location location)
        {

            _ = await _imsDbContext.Location.AddAsync(location);

            _ = await _imsDbContext.SaveChangesAsync();

        }
        public async Task UpdateLocationAsync(Location location, Location locationDTO)
        {
            location.LocationName = locationDTO.LocationName;
            location.ParentLocation = locationDTO.ParentLocation;
            location.Description = locationDTO.Description;
            location.MaxCapacity = locationDTO.MaxCapacity;
            location.CurrentOccupancy = locationDTO.CurrentOccupancy;

            _ = await _imsDbContext.SaveChangesAsync();

        }

        public async Task DeleteLocationAsync(int id)
        {
            var category = await _imsDbContext.Location.FirstOrDefaultAsync(c => c.LocationId == id);
            if (category != null)
            {
                _imsDbContext.Location.Remove(category);
            }

            await _imsDbContext.SaveChangesAsync();

        }

    }
}
