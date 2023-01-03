namespace BookShop.Presentantion.DTOs
{
    public class UtensilGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Manufacturer { get; set; } = null!;

        public string WritingUtensilsType { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string[] Images { get; set; } = null!;
    }
}
