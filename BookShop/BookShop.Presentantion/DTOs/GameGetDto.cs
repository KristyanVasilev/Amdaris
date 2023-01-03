namespace BookShop.Presentantion.DTOs
{
    public class GameGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string[] Images { get; set; } = null!;
    }
}
