namespace IMS.Models
{
    public interface ILocationRepository
    {
        IEnumerable<Location> AllLocations { get; }
        IEnumerable<Location> GetLocations(int page, int limit);
        Location? GetLocationById(int id);
        void CreateLocation(Location location);
        void UpdateLocation(Location location, Location locationDTO);
        void DeleteLocation(int id);
    }
}
