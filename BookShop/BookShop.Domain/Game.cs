namespace BookShop.Domain
{
    using BookShop.Domain.Models;

    public class Game : BaseDeletableModel<int>
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Manufacturer { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string[] Images { get; set; } = null!;

        public int GenreId { get; set; }

        public Genre Genre { get; set; } = null!;
    }
}
