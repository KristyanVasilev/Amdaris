namespace BookShop.Application
{
    public class BaseProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string KeyWords { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
