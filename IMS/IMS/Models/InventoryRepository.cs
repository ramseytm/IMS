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

    }
}
