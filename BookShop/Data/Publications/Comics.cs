namespace Data.Publications
{
    public class Comics : Publication
    {
        public Comics(string title, decimal price, string author, int pageCount, Genre genre)
            : base(title, price, author, pageCount)
        {
            this.Genre = genre;
        }

        public Genre Genre { get; private set; }
    }
}
