namespace Data.Books
{
    public class Genre
    {
        private string name;

        public Genre(string name)
        {
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

        //TODO: Implement some methods?
    }
}
