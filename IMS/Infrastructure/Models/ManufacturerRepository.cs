using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.Models
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly IMSDbContext _imsDbContext;

        public ManufacturerRepository(IMSDbContext imsDbContext)
        {
            _imsDbContext = imsDbContext;
        }

        public IEnumerable<Manufacturer> AllManufacturers
        {
            get
            {
                return _imsDbContext.Manufacturer;
            }
        }

        public IEnumerable<Manufacturer> GetManufacturers(int page, int limit)
        {
            return _imsDbContext.Manufacturer
                .OrderBy(c => c.ManufacturerName)
                .Skip(page - 1)
                .Take(limit)
                .ToList();

        }

        public Manufacturer? GetManufacturerById(int id)
        {
            return _imsDbContext.Manufacturer.FirstOrDefault(c => c.ManufacturerId == id);

        }

        public void CreateManufacturer(Manufacturer manufacturer)
        {

            _imsDbContext.Manufacturer.Add(manufacturer);

            _imsDbContext.SaveChanges();

        }
        public void UpdateManufacturer(Manufacturer manufacturer, Manufacturer manufacturerDTO)
        {
            manufacturer.ManufacturerName = manufacturerDTO.ManufacturerName;
            manufacturer.Address = manufacturerDTO.Address;
            manufacturer.ContactPerson = manufacturerDTO.ContactPerson;
            manufacturer.Email = manufacturerDTO.Email;
            manufacturer.Phone = manufacturerDTO.Phone;

            _imsDbContext.SaveChanges();

        }

        public void DeleteManufacturer(int id)
        {
            _imsDbContext.Remove(id);

            _imsDbContext.SaveChanges();

        }
    }
}
