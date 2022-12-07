namespace BookShop.Presentantion.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class UtensilDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Range(0.5, int.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 2)]
        public string Manufacturer { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string WritingUtensilsType { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Color { get; set; } = null!;
    }
}
