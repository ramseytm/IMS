namespace IMS.Models
{
    public class Location: AuditableEntity
    {
        public int LocationId { get; set; }

        public string? LocationName { get; set; }

        public int? ParentLocation { get; set; }      
        
        public string? Description { get; set;}

        public int MaxCapacity { get; set; }

        public int CurrentOccupancy { get; set; }

    }
}