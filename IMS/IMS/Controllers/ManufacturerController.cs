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
        public IActionResult GetAll()
        {
            var allManufacturer = _ManufacturerRepository.AllManufacturers;
            return Ok(allManufacturer);
        }

        [HttpGet]
        public IActionResult Get(int page = 1, int limit = 10)
        {
            var manufacturer = _ManufacturerRepository.GetManufacturers(page, limit);
            return Ok(manufacturer);
        }

        [HttpGet("{manufacturer_id}")]
        public IActionResult Get(int manufacturerId)
        {
            var manufacturer = _ManufacturerRepository.GetManufacturerById(manufacturerId);
            return Ok(manufacturer);
        }

        [HttpPost]
        public IActionResult Post(Manufacturer manufacturer)
        {
            _ManufacturerRepository.CreateManufacturer(manufacturer);

            return Ok(manufacturer);
        }

        [HttpPut("{manufacturer_id}")]
        public async Task<IActionResult> Put(int manufacturerId, Manufacturer manufacturerDTO)
        {
            if (manufacturerId != manufacturerDTO.ManufacturerId)
            {
                return BadRequest();
            }

            var manufacturer = _ManufacturerRepository.GetManufacturerById(manufacturerId);
            if (manufacturer == null)
            {
                return NotFound();
            }

            _ManufacturerRepository.UpdateManufacturer(manufacturer, manufacturerDTO);

            return Ok();
        }

        [HttpDelete("{manufacturer_id}")]
        public IActionResult DeleteOwner(int manufacturerId)
        {

            var manufacturer = _ManufacturerRepository.GetManufacturerById(manufacturerId);
            if (manufacturer == null)
            {
                return NotFound();
            }

            _ManufacturerRepository.DeleteManufacturer(manufacturerId);

            return Ok();

        }

    }
}
