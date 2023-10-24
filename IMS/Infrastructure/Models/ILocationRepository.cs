namespace IMS.Models
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetLocationsAsync(int page, int limit);
        Task<Location?> GetLocationByIdAsync(int id);
        Task CreateLocationAsync(Location location);
        Task UpdateLocationAsync(Location location, Location locationDTO);
        Task DeleteLocationAsync(int id);
    }
}
