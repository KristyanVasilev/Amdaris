namespace Data
{
    public class Genre
    {
        private string name;

        public Genre(string name)
        {
            this.Books = new List<Book>();
            this.Name = name;
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
    }
}
