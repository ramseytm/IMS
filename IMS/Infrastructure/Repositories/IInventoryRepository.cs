using IMS.Models;

namespace IMS.Infrastructure.Repositories
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetInventoryAsync(int page, int limit);
        Task<Inventory?> GetInventoryByIdAsync(int id);
        Task CreateInventoryAsync(Inventory inventory);
        Task UpdateInventoryAsync(Inventory inventory, Inventory inventoryDTO);
        Task DeleteInventoryAsync(int id);
    }
}
