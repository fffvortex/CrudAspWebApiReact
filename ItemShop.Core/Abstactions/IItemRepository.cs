using ItemShop.Core.Models;

namespace ItemShop.DataAccess.Repositories
{
    public interface IItemRepository
    {
        Task<Guid> Create(Item item);
        Task<Guid> Delete(Guid id);
        Task<List<Item>> Get();
        Task<Guid> Update(Guid id, string title, string description, decimal price);
    }
}