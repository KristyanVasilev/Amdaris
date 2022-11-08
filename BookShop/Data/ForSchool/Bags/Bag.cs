using Data.ForSchool.Bags.Enums;

namespace Data.ForSchool.Bags
{
    public abstract class Bag : Product
    {
        private string color;
        private string manufacturer;
        private int capacity;

        protected Bag(int id, decimal price, string name, string color, string manufacturer, int capacity, Gender gender)
            : base(id, price, name)
        {
            this.Color = color;
            this.Manufacturer = manufacturer;
            this.Capacity = capacity;
            this.Gender = gender;
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

        public Gender Gender { get; private set; }
    }
}
