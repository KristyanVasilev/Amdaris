namespace BookShop.Application.Bags
{
    public class BagDto : BaseProductDto
    {
        public string Color { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public int Capacity { get; set; }

        public string BagType { get; set; } = null!;

        public string Gender { get; set; } = null!;
    }
}
