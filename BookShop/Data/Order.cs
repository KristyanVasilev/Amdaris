namespace Data
{
    public class Order
    {
        private int id;

        public Order(int id, int userId)
        {
            this.Id = id;
            this.UserId = userId;
            this.Products = new List<Product>();
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

        public int UserId {get; private set; }

        public ICollection<Product> Products { get; set; }

        public bool IsCompleted { get; private set; }
    }
}
