namespace IMS.Models
{
    public class InventoryDto
    {
        public int InventoryId { get; set; }

        public Product? Product { get; set; }

        public Location? Location { get; set; }      
        
        public int Quantity { get; set;}

    }
}