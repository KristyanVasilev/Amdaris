namespace BookShop.Data.ApplicationUser
{
    public class ApplicationUser
    {
		private int id;
		private string firstName;
		private string lastName;
		private string email;
        private decimal balance;

        public ApplicationUser(int id, string firstName, string lastName, string email, decimal balance)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Balance = balance;
            this.Orders = new List<Order>();
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

        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("balance cannot be negative!");
                }
                balance = value;
            }
        }


        public ICollection<Order> Orders { get; set; }

        public ICollection<Product> WatchList { get; set; }
    }
}
