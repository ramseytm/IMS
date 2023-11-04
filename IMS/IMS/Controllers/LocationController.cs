using AutoMapper;
using IMS.Infrastructure.Repositories;
using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        private readonly IMapper _mapper;

        public LocationController(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int limit = 10)
        {
            var location = await _locationRepository.GetLocationsAsync(page, limit);
            return Ok(_mapper.Map<IEnumerable<LocationDto>>(location));
        }

        [HttpGet("{locationId}")]
        public async Task<IActionResult> Get(int locationId)
        {
            var location = await _locationRepository.GetLocationByIdAsync(locationId);
            return Ok(_mapper.Map<LocationDto>(location));
        }

        [HttpPost]
        public async Task<IActionResult> Post(LocationDto locationDto)
        {
            var location = _mapper.Map<Location>(locationDto);

            await _locationRepository.CreateLocationAsync(location);

            return Ok(_mapper.Map<LocationDto>(location));
        }

        [HttpPut("{locationId}")]
        public async Task<IActionResult> Put(int locationId, LocationDto locationDto)
        {
            if (locationId != locationDto.LocationId)
            {
                return BadRequest();
            }

            var location = await _locationRepository.GetLocationByIdAsync(locationId);
            if (location == null)
            {
                return NotFound();
            }

            await _locationRepository.UpdateLocationAsync(location, _mapper.Map<Location>(locationDto));

            return Ok();
        }

        [HttpDelete("{locationId}")]
        public async Task<IActionResult> DeleteOwner(int locationId)
        {

            var location = await _locationRepository.GetLocationByIdAsync(locationId);
            if (location == null)
            {
                return NotFound();
            }

            await _locationRepository.DeleteLocationAsync(locationId);

            return Ok();


        }

    }
}
