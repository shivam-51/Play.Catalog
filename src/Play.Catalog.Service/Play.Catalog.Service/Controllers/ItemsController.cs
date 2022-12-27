using System;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Repositories;

namespace Play.Catalog.Service.Controllers
{  
	[ApiController]
	[Route("items")]
	public class ItemsController : ControllerBase
	{
		private readonly ItemsRepository itemsRepository = new();

		//public ItemsController(IItemsRepository itemsRepository)
		//{
		//	this.itemsRepository = itemsRepository;
		//}

		// Get all
		[HttpGet]
		public async Task<IEnumerable<ItemDto>> GetAsync()
		{
			var items = (await itemsRepository.GetAllAsync()).Select(item => item.AsDto());
			return items;
		}

		// Get id
		[HttpGet("{id}")]
		public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
		{
			var item = await itemsRepository.GetAsync(id);

			if (item == null)
				return NotFound();
			return item.AsDto();
		}

		// Post
		[HttpPost]
		public async Task<ActionResult<ItemDto>> PostAsync(CreateItemDto createItemDto)
		{
			var item = new Item {
				Id = Guid.NewGuid(),
				Name = createItemDto.Name,
				Description = createItemDto.Description,
				Price = createItemDto.Price,
				CreatedTime= DateTimeOffset.UtcNow
				};
			//items.Add(item);
			await itemsRepository.CreateAsync(item);
			return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
		}

		// Update id
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(Guid id, UpdateItemDto updateItemDto)
		{
			var existingItem = await itemsRepository.GetAsync(id);
			if (existingItem == null)
				return NotFound();

			existingItem.Name = updateItemDto.Name;
			existingItem.Description = updateItemDto.Description;
			existingItem.Price = updateItemDto.Price;

			await itemsRepository.UpdateAsync(existingItem);

			return NoContent();
		}

		// Delete
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			var item = await itemsRepository.GetAsync(id);

			if (item == null)
				return NotFound();

			await itemsRepository.RemoveAsync(item.Id);

			return NoContent();
		}
	}
}