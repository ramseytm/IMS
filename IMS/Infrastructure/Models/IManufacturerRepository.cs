namespace IMS.Models
{
    public interface IManufacturerRepository
    {
        IEnumerable<Manufacturer> AllManufacturers { get; }
        IEnumerable<Manufacturer> GetManufacturers(int page, int limit);
        Manufacturer? GetManufacturerById(int id);
        void CreateManufacturer(Manufacturer manufacturer);
        void UpdateManufacturer(Manufacturer manufacturer, Manufacturer manufacturerDTO);
        void DeleteManufacturer(int id);
    }
}
