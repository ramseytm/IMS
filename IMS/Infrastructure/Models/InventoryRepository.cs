using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.Models
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IMSDbContext _imsDbContext;

        public InventoryRepository(IMSDbContext imsDbContext)
        {
            _imsDbContext = imsDbContext;
        }

        public async Task<IEnumerable<Inventory>> GetInventoryAsync(int page, int limit)
        {
            return await _imsDbContext.Inventory
                .OrderBy(c => c.Product.ProductName)
                .Skip(page - 1)
                .Take(limit)
                .ToListAsync();

        }

        public async Task<Inventory?> GetInventoryByIdAsync(int id)
        {
            return await _imsDbContext.Inventory.FirstOrDefaultAsync(c => c.InventoryId == id);

        }

        public async Task CreateInventoryAsync(Inventory inventory)        
        {
            _ = await _imsDbContext.Inventory.AddAsync(inventory);

            _ = await _imsDbContext.SaveChangesAsync();

        }
        public async Task UpdateInventoryAsync(Inventory inventory, Inventory inventoryDTO)
        {
            inventory.Product = inventoryDTO.Product;
            inventory.Location = inventoryDTO.Location;
            inventory.Quantity = inventoryDTO.Quantity;

            _ = await _imsDbContext.SaveChangesAsync();

        }

        public async Task DeleteInventoryAsync(int id)       
        {

            var inventory = await _imsDbContext.Inventory.FirstOrDefaultAsync(c => c.InventoryId == id);
            if (inventory != null)
            {
                _imsDbContext.Inventory.Remove(inventory);
            }

            await _imsDbContext.SaveChangesAsync();
        }

    }
}
