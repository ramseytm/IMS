using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _LocationRepository;

        public LocationController(ILocationRepository LocationRepository)
        {
            _LocationRepository = LocationRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var allLocation = _LocationRepository.AllLocations;
            return Ok(allLocation);
        }

        [HttpGet]
        public IActionResult Get(int page = 1, int limit = 10)
        {
            var location = _LocationRepository.GetLocations(page, limit);
            return Ok(location);
        }

        [HttpGet("{location_id}")]
        public IActionResult Get(int locationId)
        {
            var location = _LocationRepository.GetLocationById(locationId);
            return Ok(location);
        }

        [HttpPost]
        public IActionResult Post(Location location)
        {
            _LocationRepository.CreateLocation(location);

            return Ok(location);
        }

        [HttpPut("{location_id}")]
        public async Task<IActionResult> Put(int locationId, Location locationDTO)
        {
            if (locationId != locationDTO.LocationId)
            {
                return BadRequest();
            }

            var location = _LocationRepository.GetLocationById(locationId);
            if (location == null)
            {
                return NotFound();
            }

            _LocationRepository.UpdateLocation(location, locationDTO);

            return Ok();
        }

        [HttpDelete("{location_id}")]
        public IActionResult DeleteOwner(int locationId)
        {

            var location = _LocationRepository.GetLocationById(locationId);
            if (location == null)
            {
                return NotFound();
            }

            _LocationRepository.DeleteLocation(locationId);

            return Ok();


        }

    }
}
