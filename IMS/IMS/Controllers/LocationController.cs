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

    }
}
