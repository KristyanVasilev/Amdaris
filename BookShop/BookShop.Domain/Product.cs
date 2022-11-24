namespace BookShop.Domain
{
    public abstract class Product
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; } = null!;
    }
}
