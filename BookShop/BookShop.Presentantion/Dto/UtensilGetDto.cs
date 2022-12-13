namespace BookShop.Presentantion.Dto
{
    public class UtensilGetDto
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Manufacturer { get; set; } = null!;

        public string WritingUtensilsType { get; set; } = null!;

        public string Color { get; set; } = null!;
    }
}
