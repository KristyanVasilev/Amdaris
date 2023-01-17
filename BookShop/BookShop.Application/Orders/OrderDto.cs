namespace BookShop.Application.Orders
{
    using BookShop.Domain;

    public class OrderDto
    {
        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = null!;

        public decimal TotalPrice { get; set; }
    }
}
