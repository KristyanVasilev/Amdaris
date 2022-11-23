namespace BookShop.Domain.ForSchool.Notebooks
{
    using BookShop.Domain.ForSchool.Notebooks.Enums;

    public class Notebook : Product
    {
        public string Color { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public int PageCount { get; set; }

        public LineType LineType { get; set; }
    }
}
