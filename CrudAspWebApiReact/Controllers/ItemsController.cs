using CrudAspWebApiReact.Contracts;
using ItemShop.Application.Services;
using ItemShop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudAspWebApiReact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemResponse>>> GetItems()
        {
            var items = await _itemService.GetAllItems();

            var response = items.Select(x => new ItemResponse(x.Id, x.Title, x.Description, x.Price, x.CreatedAt));

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateItem([FromBody] ItemRequest itemRequest)
        {
            var (item ,error) = Item
                .CreateItem(Guid.NewGuid(),
                itemRequest.Title, 
                itemRequest.Description,
                itemRequest.Price);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var itemId = await _itemService.CreateItem(item);
            return Ok(itemId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateItem(Guid id, [FromBody] ItemRequest request)
        {
            var itemId = await _itemService
                .UpdateItem(id,request.Title, request.Description, request.Price);

            return Ok(itemId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteItem(Guid id)
        {
            return Ok(await _itemService.DeleteItem(id));
        }
    }
}
