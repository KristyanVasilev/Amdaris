namespace BookShop.Domain
{
    using BookShop.Domain.Models;

    public class Order : BaseDeletableModel<int>
    {

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public decimal Price { get; set; }

        public bool IsCompleted { get; set; }
    }
}
