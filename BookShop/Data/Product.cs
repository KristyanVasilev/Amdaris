namespace Data
{
    public abstract class Product
    {
        private decimal price;
        private int id;

        public Product(int id, decimal price)
        {
            this.Id = id;
            this.Price = price;
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
    }
}
