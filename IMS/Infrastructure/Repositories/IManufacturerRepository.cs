using IMS.Models;

namespace IMS.Infrastructure.Repositories
{
    public interface IManufacturerRepository
    {
        Task<IEnumerable<Manufacturer>> GetManufacturersAsync(int page, int limit);
        Task<Manufacturer?> GetManufacturerByIdAsync(int id);
        Task CreateManufacturerAsync(Manufacturer manufacturer);
        Task UpdateManufacturerAsync(Manufacturer manufacturer, Manufacturer manufacturerDTO);
        Task DeleteManufacturerAsync(int id);
    }
}
