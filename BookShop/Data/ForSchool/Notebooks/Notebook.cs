using Data.ForSchool.Notebooks.Enums;

namespace Data.ForSchool.Notebooks
{
    public class NoteBook : Product
    {
        private string color;
        private string manufacturer;
        private int pageCount;

        public NoteBook(int id, decimal price, string color, string manufacturer, int pageCount, LineType lineType)
            : base(id, price)
        {
            this.Color = color;
            this.Manufacturer = manufacturer;
            this.PageCount = pageCount;
            this.LineType = lineType;
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
