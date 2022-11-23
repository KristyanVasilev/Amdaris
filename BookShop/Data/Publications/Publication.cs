namespace BookShop.Domain.Publications
{
    public class Publication : Product
    {
        public string Author { get; set; } = null!;

        public int PageCount { get; set; }

        public double Rating { get; set; } = 0;

        public string Description { get; set; } = null!;

        public PublicationType PublicationType { get; set; }

        public Genre Genre { get; set; } = null!;
    }
}
