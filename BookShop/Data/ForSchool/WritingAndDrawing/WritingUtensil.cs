namespace Data.ForSchool.WritingAndDrawing
{
    public abstract class WritingUtensil : Product
    {
        private string color;
        private string manufacturer;

        protected WritingUtensil(int id, decimal price, string name, string color, string manufacturer, WritingUtensilsType writingUtensilsType) 
            : base(id, price, name)
        {
            this.Color = color;
            this.Manufacturer = manufacturer;
            this.WritingUtensilsType = writingUtensilsType;
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

        /// <summary>
        /// Pen, Pencil, Marker, etc...
        /// </summary>
        public WritingUtensilsType WritingUtensilsType { get; set; }
    }
}
