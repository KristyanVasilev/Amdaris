namespace Data.ForSchool.WritingAndDrawing
{
    public abstract class WritingUtensil
    {
		private string name;
        private decimal price;
        private string color;
        private string manufacturer;


        public WritingUtensil(string name, decimal price, string color, string manufacturer)
        {
            this.Name = name;
            this.Price = price;
            this.Color = color;
            this.Manufacturer = manufacturer;
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

	}
}
