namespace Data.ForSchool.WritingAndDrawing
{
    public abstract class Writing
    {
		private string name;
        private string color;
        private string manufacturer;

        public Writing(string name, string color, string manufacturer)
        {
            this.Name = name;
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
