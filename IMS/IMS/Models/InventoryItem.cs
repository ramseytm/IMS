namespace IMS.Models
{
    public class InventoryItem
    {
        public int InventoryItemId { get; set; }
        public DateTime Date { get; set; }

        public int Quantity { get; set; }

        public string? Description { get; set; }
    }
}