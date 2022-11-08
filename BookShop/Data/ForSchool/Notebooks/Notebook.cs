using Data.ForSchool.Notebooks.Enums;

namespace Data.ForSchool.Notebooks
{
    public class NoteBook
    {
        private decimal price;
        private string color;
        private string manufacturer;
        private int pageCount;

        public NoteBook(decimal price, string color, string manufacturer, int pageCount, LineType lineType)
        {
            this.Price = price;
            this.Color = color;
            this.Manufacturer = manufacturer;
            this.PageCount = pageCount;
            this.LineType = lineType;
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

        public int PageCount
        {
            get { return pageCount; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Page count cannot be negative or equal to zero!");
                }
                price = value;
            }
        }

        public LineType LineType { get; private set; }
    }
}
