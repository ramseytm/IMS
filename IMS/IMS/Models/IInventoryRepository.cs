namespace IMS.Models
{
    public interface IInventoryRepository
    {
        IEnumerable<Inventory> AllInventory { get; }
    }
}
