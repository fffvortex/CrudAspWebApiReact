using ItemShop.Core.Models;
using ItemShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItemShop.DataAccess.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<ItemEntity>
    {
        public void Configure(EntityTypeBuilder<ItemEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(Item.MAX_TITLE_LENGTH);

            builder.Property(b => b.Description).IsRequired();

            builder.Property(b => b.Price).IsRequired();
        }
    }
}
