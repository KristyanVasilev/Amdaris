namespace BookShop.Domain
{
    using BookShop.Domain.Models;

    public class Order : BaseDeletableModel<int>
    {
        public Order()
        {
            this.ProductsIds = new HashSet<int>();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<int> ProductsIds { get; set; }

        public decimal Price { get; set; }

        public bool IsCompleted { get; set; }
    }
}
