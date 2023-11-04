using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly IMSDbContext _imsDbContext;

        public ManufacturerRepository(IMSDbContext imsDbContext)
        {
            _imsDbContext = imsDbContext;
        }

        public async Task<IEnumerable<Manufacturer>> GetManufacturersAsync(int page, int limit)
        {
            return await _imsDbContext.Manufacturer
                .OrderBy(c => c.ManufacturerName)
                .Skip(page - 1)
                .Take(limit)
                .ToListAsync();

        }

        public async Task<Manufacturer?> GetManufacturerByIdAsync(int id)
        {
            return await _imsDbContext.Manufacturer.FirstOrDefaultAsync(c => c.ManufacturerId == id);

        }

        public async Task CreateManufacturerAsync(Manufacturer manufacturer)
        {

            _ = await _imsDbContext.Manufacturer.AddAsync(manufacturer);

            _ = await _imsDbContext.SaveChangesAsync();

        }
        public async Task UpdateManufacturerAsync(Manufacturer manufacturer, Manufacturer manufacturerDTO)
        {
            manufacturer.ManufacturerName = manufacturerDTO.ManufacturerName;
            manufacturer.Address = manufacturerDTO.Address;
            manufacturer.ContactPerson = manufacturerDTO.ContactPerson;
            manufacturer.Email = manufacturerDTO.Email;
            manufacturer.Phone = manufacturerDTO.Phone;

            _ = await _imsDbContext.SaveChangesAsync();

        }

        public async Task DeleteManufacturerAsync(int id)
        {
            var manufacturer = await _imsDbContext.Manufacturer.FirstOrDefaultAsync(c => c.ManufacturerId == id);
            if (manufacturer != null)
            {
                _imsDbContext.Manufacturer.Remove(manufacturer);
            }

            await _imsDbContext.SaveChangesAsync();

        }
    }
}
