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

    }
}
