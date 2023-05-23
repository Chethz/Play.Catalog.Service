using Microsoft.AspNetCore.Mvc;
using Play.Catalog.service.Dtos;
using Play.Catalog.service.Entities;
using Play.Common.Repositories;

namespace Play.Catalog.service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<Item> itemsRepository;

        public ItemsController(IRepository<Item> itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAsync()
        {
            var items = (await itemsRepository.GetAllAsync()).Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
        {
            var item = (await itemsRepository.GetAsync(id));

            return item == null ? NotFound() : item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostAsync(CreateItemDto createItemDto)
        {
            var item = new Item { 
                Name = createItemDto.Name,
                Description = createItemDto.Description,    
                Price = createItemDto.Price,
                CreatedDate = DateTimeOffset.Now
            };

            await itemsRepository.CreateAsync(item);

            return CreatedAtAction("GetByIdAsync", new { id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateItemDto updateItemDto) { 
            var existingItem = await itemsRepository.GetAsync(id);

            if(existingItem == null) {
                return NotFound();
            }

            existingItem.Name = updateItemDto.Name;
            existingItem.Description = updateItemDto.Description;
            existingItem.Price = updateItemDto.Price;

            await itemsRepository.UpdateAsync(existingItem);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await itemsRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await itemsRepository.RemoveAsync(item.Id);

            return NoContent();
        }
    }
}
