using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _InventoryRepository;

        public InventoryController(IInventoryRepository InventoryRepository)
        {
            _InventoryRepository = InventoryRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var allInventory = _InventoryRepository.AllInventory;
            return Ok(allInventory);
        }

    }
}
