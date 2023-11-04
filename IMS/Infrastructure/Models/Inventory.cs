namespace IMS.Models
{
    public class Inventory : AuditableEntity
    {
        public int InventoryId { get; set; }

        public Product? Product { get; set; }

        public Location? Location { get; set; }      
        
        public int Quantity { get; set;}

    }
}