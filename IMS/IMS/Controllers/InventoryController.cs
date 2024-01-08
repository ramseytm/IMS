using AutoMapper;
using IMS.DTO;
using IMS.Infrastructure.Repositories;
using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;

        private readonly IMapper _mapper;

        public InventoryController(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int limit = 10)
        {
            var inventory = await _inventoryRepository.GetInventoryAsync(page,limit);
            return Ok(_mapper.Map<IEnumerable<InventoryDto>>(inventory));
        }

        [HttpGet("{inventoryId}")]
        public async Task<IActionResult> Get(int inventoryId)
        {
            var inventory = await _inventoryRepository.GetInventoryByIdAsync(inventoryId);
            return Ok(_mapper.Map<InventoryDto>(inventory));
        }

        [HttpPost]
        public async Task<IActionResult> Post(InventoryDto inventoryDto)
        {
            var inventory = _mapper.Map<Inventory>(inventoryDto);

            await _inventoryRepository.CreateInventoryAsync(inventory);

            return Ok(_mapper.Map<InventoryDto>(inventory));
        }

        [HttpPut("{inventoryId}")]
        public async Task<IActionResult> Put(int inventoryId, InventoryDto inventoryDto)
        {
            if (inventoryId != inventoryDto.InventoryId)
            {
                return BadRequest();
            }

            var inventory = await _inventoryRepository.GetInventoryByIdAsync(inventoryId);
            if (inventory == null)
            {
                return NotFound();
            }

            await _inventoryRepository.UpdateInventoryAsync(inventory, _mapper.Map<Inventory>(inventoryDto));

            return Ok();
        }

        [HttpDelete("{inventoryId}")]
        public async Task<IActionResult> DeleteOwner(int inventoryId)
        {

            var inventory = await _inventoryRepository.GetInventoryByIdAsync(inventoryId);
            if (inventory == null)
            {
                return NotFound();
            }

            await _inventoryRepository.DeleteInventoryAsync(inventoryId);

            return Ok();

        }

    }
}
