namespace BookShop.Domain.Publications
{
    using System.Text;

    public class Publication : Product
    {
        public string Author { get; set; } = null!;

        public int PageCount { get; set; }

        public double Rating { get; set; } = 0;

        public string Description { get; set; } = null!;

        public PublicationType PublicationType { get; set; }

        public Genre Genre { get; set; } = null!;

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"The publication is with {this.PageCount} pages and the author is {this.Author}.");
            return sb.ToString().TrimEnd();
        }
    }
}
