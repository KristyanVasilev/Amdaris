namespace BookShop.Application.Publications.Queries.GetProducts
{
    public class PublicationViewModel : BaseProductModel
    {
        public string Author { get; set; } = null!;

        public int PageCount { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; } = null!;

        public string PublicationType { get; set; } = null!;

        public string Genre { get; set; } = null!;
    }
}
