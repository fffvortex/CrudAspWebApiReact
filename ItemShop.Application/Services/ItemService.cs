using ItemShop.Core.Models;
using ItemShop.DataAccess.Repositories;

namespace ItemShop.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _itemRepository.Get();
        }

        public async Task<Guid> CreateItem(Item item)
        {
            return await _itemRepository.Create(item);
        }

        public async Task<Guid> UpdateItem(Guid id, string title, string description, decimal price)
        {
            return await _itemRepository.Update(id, title, description, price);
        }

        public async Task<Guid> DeleteItem(Guid id)
        {
            return await _itemRepository.Delete(id);
        }
    }
}
