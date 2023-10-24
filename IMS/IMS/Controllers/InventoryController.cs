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
        public async Task<IActionResult> Get(int page = 1, int limit = 10)
        {
            var inventory = await _InventoryRepository.GetInventoryAsync(page,limit);
            return Ok(inventory);
        }

        [HttpGet("{inventory_id}")]
        public async Task<IActionResult> Get(int inventoryId)
        {
            var inventory = await _InventoryRepository.GetInventoryByIdAsync(inventoryId);
            return Ok(inventory);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Inventory inventory)
        {
            await _InventoryRepository.CreateInventoryAsync(inventory);

            return Ok(inventory);
        }

        [HttpPut("{inventory_id}")]
        public async Task<IActionResult> Put(int inventoryId, Inventory inventoryDTO)
        {
            if (inventoryId != inventoryDTO.InventoryId)
            {
                return BadRequest();
            }

            var inventory = await _InventoryRepository.GetInventoryByIdAsync(inventoryId);
            if (inventory == null)
            {
                return NotFound();
            }

            await _InventoryRepository.UpdateInventoryAsync(inventory, inventoryDTO);

            return Ok();
        }

        [HttpDelete("{inventory_id}")]
        public async Task<IActionResult> DeleteOwner(int inventoryId)
        {

            var inventory = await _InventoryRepository.GetInventoryByIdAsync(inventoryId);
            if (inventory == null)
            {
                return NotFound();
            }

            await _InventoryRepository.DeleteInventoryAsync(inventoryId);

            return Ok();

        }

    }
}
