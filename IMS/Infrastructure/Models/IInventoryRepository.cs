namespace IMS.Models
{
    public interface IInventoryRepository
    {
        IEnumerable<Inventory> AllInventory { get; }
        IEnumerable<Inventory> GetInventory(int page, int limit);
        Inventory? GetInventoryById(int id);
        void CreateInventory(Inventory inventory);
        void UpdateInventory(Inventory inventory, Inventory inventoryDTO);
        void DeleteInventory(int id);
    }
}
