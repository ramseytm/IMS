using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemController : ControllerBase
    {
        private readonly IInventoryItemRepository _inventoryItemRepository;

        public InventoryItemController(IInventoryItemRepository inventoryItemRepository)
        {
            _inventoryItemRepository = inventoryItemRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var allInventoryItems = _inventoryItemRepository.AllInventoryItems;
            return Ok(allInventoryItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_inventoryItemRepository.AllInventoryItems.Any(p => p.InventoryItemId == id))
                return NotFound();
            return Ok(_inventoryItemRepository.AllInventoryItems.Where(p => p.InventoryItemId == id));
        }
    }
}
