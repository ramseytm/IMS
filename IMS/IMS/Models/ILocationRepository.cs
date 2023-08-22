namespace IMS.Models
{
    public interface ILocationRepository
    {
        IEnumerable<Location> AllLocations { get; }
    }
}
