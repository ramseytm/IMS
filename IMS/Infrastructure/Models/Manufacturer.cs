namespace IMS.Models
{
    public class Manufacturer : AuditableEntity
    {
        public int ManufacturerId { get; set; }

        public string? ManufacturerName { get; set; }

        public string? Address { get; set; }      

        public string? ContactPerson { get; set; }

        public string? Email {get; set; }

        public string? Phone { get; set;}

    }
}