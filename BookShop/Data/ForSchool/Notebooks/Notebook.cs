namespace BookShop.Domain.ForSchool.Notebooks
{
    using BookShop.Domain.ForSchool.Notebooks.Enums;
    using System.Text;
    public class NoteBook : Product
    {
        public string Color { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public int PageCount { get; set; }

        public LineType LineType { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"The notebook is with {this.PageCount} pages and the manufacturer is {this.Manufacturer}.");
            sb.AppendLine($"The color is {this.Color} and the line type is {this.LineType.ToString()}");
            return sb.ToString().TrimEnd();
        }
    }
}
