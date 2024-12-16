namespace ItemShop.DataAccess.Entities
{
    public class ItemEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; } = decimal.Zero;

        public DateTime CreatedAt { get; set; }
    }
}
