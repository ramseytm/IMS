using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Models
{
    public class Product: AuditableEntity
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerID { get; set;}

        public string? Description { get; set; }

        public decimal UnitPrice { get; set;}

        public int QuantityInStock { get; set; }

        public int MinimumQuantity { get; set; }

        public int MaximumQuantity { get; set; }

        public string? UPC { get; set;}

    }
}