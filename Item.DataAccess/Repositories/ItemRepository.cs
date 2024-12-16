using ItemShop.Core.Models;
using ItemShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItemShop.DataAccess.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemShopDbContext _context;

        public ItemRepository(ItemShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> Get()
        {
            var itemEntities = await _context.Items
                .AsNoTracking()
                .ToListAsync();

            var items = itemEntities
                .Select(i => Item.CreateItem(i.Id, i.Title, i.Description, i.Price).Item)
                .ToList();
            return items;
        }

        public async Task<Guid> Create(Item item)
        {
            var itemEntity = new ItemEntity
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                Price = item.Price
            };

            await _context.Items.AddAsync(itemEntity);
            await _context.SaveChangesAsync();

            return itemEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, decimal price)
        {
            await _context.Items.Where(i => i.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(i => i.Title, i => title)
                .SetProperty(i => i.Description, i => description)
                .SetProperty(i => i.Price, i => price));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Items
                .Where(i => i.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
