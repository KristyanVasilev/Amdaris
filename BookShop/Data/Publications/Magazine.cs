using System.Text;

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

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"Genre: {this.Genre.ToString()}.");
            return sb.ToString().TrimEnd();
        }
    }
}
