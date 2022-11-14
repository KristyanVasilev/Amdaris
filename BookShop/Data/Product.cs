namespace BookShop.Data
{
    using System.Text;

    public abstract class Product
    {
        private int id;
        private decimal price;
        private string name;

        public Product(int id, decimal price, string name)
        {
            this.Id = id;
            this.Price = price;
            this.Name = name;
        }

        protected Product(int id, decimal price)
        {
            this.id = id;
            this.price = price;
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Product {this.Name} has Id - {this.id} and cost {this.Price}$.");
            return sb.ToString();
        }
    }
}
