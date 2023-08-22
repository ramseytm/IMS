namespace IMS.Models
{
    public interface IManufacturerRepository
    {
        IEnumerable<Manufacturer> AllManufacturers { get; }
    }
}
