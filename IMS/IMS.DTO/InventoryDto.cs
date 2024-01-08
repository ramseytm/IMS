namespace IMS.DTO
{
    public class InventoryDto
    {
        public int InventoryId { get; set; }

        public ProductDto? Product { get; set; }

        public LocationDto? Location { get; set; }

        public int Quantity { get; set; }

    }
}