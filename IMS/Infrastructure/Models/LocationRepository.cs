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

        public IEnumerable<Location> GetLocations(int page, int limit)
        {
            return _imsDbContext.Location
                .OrderBy(c => c.LocationName)
                .Skip(page - 1)
                .Take(limit)
                .ToList();
        }

        public Location? GetLocationById(int id)
        {
            return _imsDbContext.Location.FirstOrDefault(c => c.LocationId == id);

        }

        public void CreateLocation(Location location)
        {

            _imsDbContext.Location.Add(location);

            _imsDbContext.SaveChanges();

        }
        public void UpdateLocation(Location location, Location locationDTO)
        {
            location.LocationName = locationDTO.LocationName;
            location.ParentLocation = locationDTO.ParentLocation;
            location.Description = locationDTO.Description;
            location.MaxCapacity = locationDTO.MaxCapacity;
            location.CurrentOccupancy = locationDTO.CurrentOccupancy;

            _imsDbContext.SaveChanges();

        }

        public void DeleteLocation(int id)
        {
            _imsDbContext.Remove(id);

            _imsDbContext.SaveChanges();

        }

    }
}
