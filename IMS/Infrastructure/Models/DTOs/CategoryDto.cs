namespace IMS.Models
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public int? ParentCategory { get; set; }      
        
        public string? Description { get; set;}

    }
}