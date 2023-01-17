namespace BookShop.Presentantion.DTOs
{
    using BookShop.Domain;
    using System.ComponentModel.DataAnnotations;

    public class OrderPostDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Email { get; set; } = null!;

        [Required]
        public ICollection<ProductPostDto> Products { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public decimal TotalPrice { get; set; }
    }
}
