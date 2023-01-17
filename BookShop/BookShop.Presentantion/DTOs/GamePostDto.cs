namespace BookShop.Presentantion.DTOs
{
    using BookShop.Presentantion.Filters;
    using System.ComponentModel.DataAnnotations;

    public class GamePostDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Manufacturer { get; set; } = null!;

        [Range(0.5, int.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Genre { get; set; } = null!;

        [Required]
        [ValidateUrlsInArray(ErrorMessage = "Invalid url")]
        public string[] Images { get; set; } = null!;

        [Required]
        public string KeyWords { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
