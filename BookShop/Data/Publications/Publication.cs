namespace BookShop.Data.Publications
{
    using System.Text;

    public abstract class Publication : Product
    {
        private string author;
        private int pageCount;

        protected Publication(int id, decimal price, string name, string author, int pageCount)
            : base(id, price, name)
        {
            this.Author = author;
            this.PageCount = pageCount;
        }

        public string Author
        {
            get { return author; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Author cannot be null or empty!");
                }
                author = value;
            }
        }

        public int PageCount
        {
            get { return pageCount; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Page count cannot be negative or equal to zero!");
                }
                pageCount = value;
            }
        }

        public decimal Rating { get; private set; } = 0;

        public string Description { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"The publication is with {this.PageCount} pages and the author is {this.Author}.");
            return sb.ToString().TrimEnd();
        }
    }
}
