namespace BookShop.Domain
{
    using BookShop.Domain.Models;

    public class Order : BaseDeletableModel<int>
    {
        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = null!;

        public decimal TotalPrice { get; set; }
    }
}
