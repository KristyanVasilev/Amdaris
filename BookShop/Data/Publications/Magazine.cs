namespace Data.Publications
{
    public class Magazine : Publication
    {
        public Magazine(int id, decimal price, string name, string author, int pageCount, Genre genre)
            : base(id, price, name, author, pageCount)
        {
            this.Genre = genre;
        }

        public Genre Genre { get; private set; }
    }
}
