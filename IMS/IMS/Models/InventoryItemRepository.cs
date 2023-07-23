using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.Models
{
    public class InventoryItemRepository : IInventoryItemRepository
    {
        private readonly IMSDbContext _imsDbContext;

        public InventoryItemRepository(IMSDbContext imsDbContext)
        {
            _imsDbContext = imsDbContext;
        }

        public IEnumerable<InventoryItem> AllInventoryItems
        {
            get
            {
                return _imsDbContext.InventoryItems;
            }
        }

        public InventoryItem? GetInventoryItemById(int inventoryItemId)
        {
            return _imsDbContext.InventoryItems.FirstOrDefault(p => p.InventoryItemId == inventoryItemId);
        }

        public IEnumerable<InventoryItem> SearchInventoryItems(string searchQuery)
        {
            return _imsDbContext.InventoryItems.Where(p => p.Description.Contains(searchQuery));
        }
    }
}
