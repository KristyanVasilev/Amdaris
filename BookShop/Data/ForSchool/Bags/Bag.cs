namespace Data.ForSchool.Bags
{
    public abstract class Bag
    {
        private string name;
        private decimal price;
        private string color;
        private string manufacturer;
        private int capacity;


        public Bag(string name, decimal price, string color, string manufacturer, int capacity, Type type)
        {
            this.Name = name;
            this.Price = price;
            this.Color = color;
            this.Manufacturer = manufacturer;
            this.Capacity = capacity;
            this.Type = type;
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

        public string Color
        {
            get { return color; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Color cannot be null or empty!");
                }
                color = value;
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Manufacturer cannot be null or empty!");
                }
                manufacturer = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity cannot be negative or equal to zero!");
                }
                capacity = value;
            }
        }

        public Type Type { get; private set; }
    }
}
