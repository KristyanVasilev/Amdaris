namespace BookShop.Domain.ForSchool.WritingAndDrawing
{
    public class WritingUtensil : Product
    {

        public string Color { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        /// <summary>
        /// Pen, Pencil, Marker, etc...
        /// </summary>
        public WritingUtensilsType WritingUtensilsType { get; set; }
    }
}
