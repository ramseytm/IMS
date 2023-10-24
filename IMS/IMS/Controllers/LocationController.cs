using AutoMapper;
using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _LocationRepository;

        private readonly IMapper _mapper;

        public LocationController(ILocationRepository LocationRepository, IMapper mapper)
        {
            _LocationRepository = LocationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int limit = 10)
        {
            var location = await _LocationRepository.GetLocationsAsync(page, limit);
            return Ok(_mapper.Map<IEnumerable<LocationDTO>>(location));
        }

        [HttpGet("{location_id}")]
        public async Task<IActionResult> Get(int locationId)
        {
            var location = await _LocationRepository.GetLocationByIdAsync(locationId);
            return Ok(_mapper.Map<LocationDTO>(location));
        }

        [HttpPost]
        public async Task<IActionResult> Post(LocationDTO locationDTO)
        {
            var location = _mapper.Map<Location>(locationDTO);

            await _LocationRepository.CreateLocationAsync(location);

            return Ok(_mapper.Map<LocationDTO>(location));
        }

        [HttpPut("{location_id}")]
        public async Task<IActionResult> Put(int locationId, LocationDTO locationDTO)
        {
            if (locationId != locationDTO.LocationId)
            {
                return BadRequest();
            }

            var location = await _LocationRepository.GetLocationByIdAsync(locationId);
            if (location == null)
            {
                return NotFound();
            }

            await _LocationRepository.UpdateLocationAsync(location, _mapper.Map<Location>(locationDTO));

            return Ok();
        }

        [HttpDelete("{location_id}")]
        public async Task<IActionResult> DeleteOwner(int locationId)
        {

            var location = await _LocationRepository.GetLocationByIdAsync(locationId);
            if (location == null)
            {
                return NotFound();
            }

            await _LocationRepository.DeleteLocationAsync(locationId);

            return Ok();


        }

    }
}
