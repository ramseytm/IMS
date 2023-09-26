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

        public IEnumerable<Inventory> AllInventory
        {
            get
            {
                return _imsDbContext.Inventory;
            }
        }

        public IEnumerable<Inventory> GetInventory(int page, int limit)
        {
            return _imsDbContext.Inventory
                .OrderBy(c => c.Product.ProductName)
                .Skip(page - 1)
                .Take(limit)
                .ToList();

        }

        public Inventory? GetInventoryById(int id)
        {
            return _imsDbContext.Inventory.FirstOrDefault(c => c.InventoryId == id);

        }

        public void CreateInventory(Inventory inventory)
        {

            _imsDbContext.Inventory.Add(inventory);

            _imsDbContext.SaveChanges();

        }
        public void UpdateInventory(Inventory inventory, Inventory inventoryDTO)
        {
            inventory.Product = inventoryDTO.Product;
            inventory.Location = inventoryDTO.Location;
            inventory.Quantity = inventoryDTO.Quantity;

            _imsDbContext.SaveChanges();

        }

        public void DeleteInventory(int id)
        {
            _imsDbContext.Remove(id);

            _imsDbContext.SaveChanges();

        }

    }
}
