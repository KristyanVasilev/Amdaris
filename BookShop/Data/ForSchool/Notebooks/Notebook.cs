using Data.ForSchool.Notebooks.Enums;
using System.Text;

namespace Data.ForSchool.Notebooks
{
    public class NoteBook : Product
    {
        private string color;
        private string manufacturer;
        private int pageCount;

        public NoteBook(int id, decimal price, string name, string color, string manufacturer, int pageCount, LineType lineType)
            : base(id, price, name)
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
                pageCount = value;
            }
        }

        public LineType LineType { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"The notebook is with {this.PageCount} pages and the manufacturer is {this.Manufacturer}.");
            sb.AppendLine($"The color is {this.Color} and the line type is {this.LineType.ToString()}");
            return sb.ToString().TrimEnd();
        }
    }
}
