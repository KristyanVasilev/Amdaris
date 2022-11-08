namespace Data.User
{
    public class User
    {
		private int id;
		private string firstName;
		private string lastName;
		private string email;

        public User(int id, string firstName, string lastName, string email)
        {
            this.Id = id;
            this.firstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Products = new List<Product>();
            this.WatchList = new HashSet<Product>();
        }

		public int Id
		{
			get { return id; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id cannot be negative or equal to zero!");
                }
                id = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("FirstName cannot be null or empty!");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("LastName cannot be null or empty!");
                }
                lastName = value;
            }
        }

        public string Email
        {
            get { return email; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email cannot be null or empty!");
                }
                email = value;
            }
        }

        public ICollection<Product> Products { get; set; }

        public ICollection<Product> WatchList { get; set; }
    }
}
