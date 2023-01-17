namespace BookShop.Domain
{
    using BookShop.Domain.Models;

    public class WritingUtensil : BaseDeletableModel<int>
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Color { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public string[] Images { get; set; } = null!;

        public string KeyWords { get; set; } = null!;

        public int Quantity { get; set; }

        public int WritingUtensilsTypeId { get; set; }

        public WritingUtensilsType WritingUtensilsType { get; set; } = null!;
    }
}
