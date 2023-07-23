namespace IMS.Models
{
    public interface IInventoryItemRepository
    {
        IEnumerable<InventoryItem> AllInventoryItems { get; }
        InventoryItem? GetInventoryItemById(int inventoryItemId);
    }
}
