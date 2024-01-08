using AutoMapper;
using IMS.DTO;
using IMS.Infrastructure.Repositories;
using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        private readonly IMapper _mapper;

        public ManufacturerController(IManufacturerRepository manufacturerRepository, IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int limit = 10)
        {
            var manufacturer = await _manufacturerRepository.GetManufacturersAsync(page, limit);
            return Ok(_mapper.Map<IEnumerable<ManufacturerDto>>(manufacturer));
        }

        [HttpGet("{manufacturerId}")]
        public async Task<IActionResult> Get(int manufacturerId)
        {
            var manufacturer = await _manufacturerRepository.GetManufacturerByIdAsync(manufacturerId);
            return Ok(_mapper.Map<ManufacturerDto>(manufacturer));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ManufacturerDto manufacturerDto)
        {
            var manufacturer = _mapper.Map<Manufacturer>(manufacturerDto);

            await _manufacturerRepository.CreateManufacturerAsync(manufacturer);

            return Ok(_mapper.Map<ManufacturerDto>(manufacturer));
        }

        [HttpPut("{manufacturerId}")]
        public async Task<IActionResult> Put(int manufacturerId, Manufacturer manufacturerDTO)
        {
            if (manufacturerId != manufacturerDTO.ManufacturerId)
            {
                return BadRequest();
            }

            var manufacturer = await _manufacturerRepository.GetManufacturerByIdAsync(manufacturerId);
            if (manufacturer == null)
            {
                return NotFound();
            }

            await _manufacturerRepository.UpdateManufacturerAsync(manufacturer, _mapper.Map<Manufacturer>(manufacturerDTO));

            return Ok();
        }

        [HttpDelete("{manufacturerId}")]
        public async Task<IActionResult> DeleteOwner(int manufacturerId)
        {

            var manufacturer = await _manufacturerRepository.GetManufacturerByIdAsync(manufacturerId);
            if (manufacturer == null)
            {
                return NotFound();
            }

            await _manufacturerRepository.DeleteManufacturerAsync(manufacturerId);

            return Ok();

        }

    }
}
