namespace Data.Publications
{
    public class Dictionary : Publication
    {
        public Dictionary(int id, decimal price, string name, string author, int pageCount)
            : base(id, price, name, author, pageCount)
        {
        }
    }
}
