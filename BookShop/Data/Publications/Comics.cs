namespace BookShop.Data.Publications
{
    using System.Text;

    public class Comics : Publication
    {
        public Comics(int id, decimal price, string name, string author, int pageCount, Genre genre)
           : base(id, price, name, author, pageCount)
        {
            this.Genre = genre;
        }

        public Genre Genre { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"Genre: {this.Genre.Name}.");
            return sb.ToString().TrimEnd();
        }
    }
}
