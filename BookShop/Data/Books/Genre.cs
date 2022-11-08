namespace Data.Books
{
    public class Genre
    {
        private string name;

        public Genre(string name)
        {
            Books = new List<Book>();
            Name = name;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }
                name = value;
            }
        }

        public IEnumerable<Book> Books { get; set; }

        //TODO: Implement some methods?
    }
}
