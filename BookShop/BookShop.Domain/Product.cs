namespace BookShop.Domain
{
    using BookShop.Domain.Models;

    public class Product : BaseDeletableModel<int>
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; } = null!;
    }
}
