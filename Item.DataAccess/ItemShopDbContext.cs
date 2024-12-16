using ItemShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItemShop.DataAccess
{
    public class ItemShopDbContext : DbContext
    {
        public ItemShopDbContext(DbContextOptions<ItemShopDbContext> options) : base(options)
        {
        }

        public DbSet<ItemEntity> Items { get; set; }
    }
}
