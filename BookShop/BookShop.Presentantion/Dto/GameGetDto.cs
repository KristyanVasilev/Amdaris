namespace BookShop.Presentantion.Dto
{
    public class GameGetDto
    {
        public string Name { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public string Genre { get; set; } = null!;
    }
}
