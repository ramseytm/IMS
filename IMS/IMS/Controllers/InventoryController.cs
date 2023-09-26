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
            var allInventory = _InventoryRepository.GetInventory;
            return Ok(allInventory);
        }

        [HttpGet]
        public IActionResult Get(int page = 1, int limit = 10)
        {
            var inventory = _InventoryRepository.GetInventory(page,limit);
            return Ok(inventory);
        }

        [HttpGet("{inventory_id}")]
        public IActionResult Get(int inventoryId)
        {
            var inventory = _InventoryRepository.GetInventoryById(inventoryId);
            return Ok(inventory);
        }

        [HttpPost]
        public IActionResult Post(Inventory inventory)
        {
            _InventoryRepository.CreateInventory(inventory);

            return Ok(inventory);
        }

        [HttpPut("{inventory_id}")]
        public async Task<IActionResult> Put(int inventoryId, Inventory inventoryDTO)
        {
            if (inventoryId != inventoryDTO.InventoryId)
            {
                return BadRequest();
            }

            var inventory = _InventoryRepository.GetInventoryById(inventoryId);
            if (inventory == null)
            {
                return NotFound();
            }

            _InventoryRepository.UpdateInventory(inventory, inventoryDTO);

            return Ok();
        }

        [HttpDelete("{inventory_id}")]
        public IActionResult DeleteOwner(int inventoryId)
        {
            
            var inventory = _InventoryRepository.GetInventoryById(inventoryId);
            if (inventory == null)
            {
                return NotFound();
            }

            _InventoryRepository.DeleteInventory(inventoryId);

            return Ok();
                       
        }

    }
}
