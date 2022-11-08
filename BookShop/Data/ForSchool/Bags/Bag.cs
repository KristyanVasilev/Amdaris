namespace Data.ForSchool.Bags
{
    public abstract class Bag : Product
    {
        private string name;
        private string color;
        private string manufacturer;
        private int capacity;

        protected Bag(int id, decimal price, string name, string color, string manufacturer, int capacity, Type type)
            : base(id, price)
        {
            this.Name = name;
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
