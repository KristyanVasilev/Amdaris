namespace BookShop.Data.ApplicationUser
{
    using System.Text;

    public class ApplicationUser
    {
        private int id;
        private string firstName;
        private string lastName;
        private string email;

        public ApplicationUser(int id, string firstName, string lastName, string email)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"User: {this.FirstName} {this.LastName} with Id - {this.Id}");
            sb.AppendLine($"Email: {this.Email}");

            return sb.ToString();
        }
    }
}
