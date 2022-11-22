namespace BookShop.Domain.ForSchool.WritingAndDrawing
{
    using System.Text;

    public abstract class WritingUtensil : Product
    {

        public string Color { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        /// <summary>
        /// Pen, Pencil, Marker, etc...
        /// </summary>
        public WritingUtensilsType WritingUtensilsType { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"Color: {this.Color}.");
            sb.AppendLine($"Manufacturer: {this.Manufacturer}.");
            sb.AppendLine($"WritingUtensilsType: {this.WritingUtensilsType.ToString()}.");
            return sb.ToString().TrimEnd();
        }
    }
}
