namespace ItemShop.Core.Models
{
    public class Item
    {
        public const int MAX_TITLE_LENGTH = 250;
        private Item(Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            CreatedAt = DateTime.UtcNow;
        }
        public Guid Id { get; }

        public string Title { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        public decimal Price { get; } = decimal.Zero;

        public DateTime CreatedAt { get; }

        public static (Item Item, string Error) CreateItem(Guid id, string title, string description, decimal price)
        {
            var error = string.Empty;
            if (string.IsNullOrWhiteSpace(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = "Title cannot be empty or longer than 250 symbols";
            }

            var item = new Item(id, title, description, price);

            return (item, error);
        }
    }
}
