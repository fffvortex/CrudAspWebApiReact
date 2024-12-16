using ItemShop.Core.Models;

namespace ItemShop.Application.Services
{
    public interface IItemService
    {
        Task<Guid> CreateItem(Item item);
        Task<Guid> DeleteItem(Guid id);
        Task<List<Item>> GetAllItems();
        Task<Guid> UpdateItem(Guid id, string title, string description, decimal price);
    }
}