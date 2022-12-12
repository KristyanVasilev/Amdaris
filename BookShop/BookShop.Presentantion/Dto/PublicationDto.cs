namespace BookShop.Presentantion.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class PublicationDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Author { get; set; } = null!;

        [Range(0.5, int.MaxValue)]
        public decimal Price { get; set; }

        [Range(5, int.MaxValue)]
        public int PageCount { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Genre { get; set; } = null!;
    }
}
