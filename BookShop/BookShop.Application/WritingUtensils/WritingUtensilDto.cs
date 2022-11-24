namespace BookShop.Application.WritingUtensils
{
    public class WritingUtensilDto : BaseProductDto
    {
        public string Color { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public string WritingUtensilsType { get; set; } = null!;
    }
}
