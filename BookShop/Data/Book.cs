namespace Data
{
    public class Book
    {
        private string title;
        private decimal price;
        private string author;
        private int pageCount;

        public Book(string title, decimal price, string author, int pageCount, Genre genre)
        {
            this.Title = title;
            this.Price = price;
            this.Author = author;
            this.PageCount = pageCount;
            this.Genre = genre;
        }

        public string Title
        {
            get { return title; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be null or empty!");
                }
                title = value; 
            }
        }

        public decimal Price
        {
            get { return price; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be negative or equal to zero!");
                }
                price = value;
            }
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

        public Genre Genre { get; private set; }
    }
}
