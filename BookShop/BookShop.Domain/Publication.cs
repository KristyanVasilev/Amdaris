namespace BookShop.Domain
{
    using BookShop.Domain.Models;

    public class Publication : BaseDeletableModel<int>
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Author { get; set; } = null!;

        public int PageCount { get; set; }

        public double Rating { get; set; } = 0;

        public string Description { get; set; } = null!;

        public string[] Images { get; set; } = null!;

        public int GenreId { get; set; }

        public Genre Genre { get; set; } = null!;
    }
}
