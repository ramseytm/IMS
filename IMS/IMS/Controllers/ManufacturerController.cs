using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerRepository _ManufacturerRepository;

        public ManufacturerController(IManufacturerRepository ManufacturerRepository)
        {
            _ManufacturerRepository = ManufacturerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int limit = 10)
        {
            var manufacturer = await _ManufacturerRepository.GetManufacturersAsync(page, limit);
            return Ok(manufacturer);
        }

        [HttpGet("{manufacturer_id}")]
        public async Task<IActionResult> Get(int manufacturerId)
        {
            var manufacturer = await _ManufacturerRepository.GetManufacturerByIdAsync(manufacturerId);
            return Ok(manufacturer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Manufacturer manufacturer)
        {
            await _ManufacturerRepository.CreateManufacturerAsync(manufacturer);

            return Ok(manufacturer);
        }

        [HttpPut("{manufacturer_id}")]
        public async Task<IActionResult> Put(int manufacturerId, Manufacturer manufacturerDTO)
        {
            if (manufacturerId != manufacturerDTO.ManufacturerId)
            {
                return BadRequest();
            }

            var manufacturer = await _ManufacturerRepository.GetManufacturerByIdAsync(manufacturerId);
            if (manufacturer == null)
            {
                return NotFound();
            }

            await _ManufacturerRepository.UpdateManufacturerAsync(manufacturer, manufacturerDTO);

            return Ok();
        }

        [HttpDelete("{manufacturer_id}")]
        public async Task<IActionResult> DeleteOwner(int manufacturerId)
        {

            var manufacturer = await _ManufacturerRepository.GetManufacturerByIdAsync(manufacturerId);
            if (manufacturer == null)
            {
                return NotFound();
            }

            await _ManufacturerRepository.DeleteManufacturerAsync(manufacturerId);

            return Ok();

        }

    }
}
