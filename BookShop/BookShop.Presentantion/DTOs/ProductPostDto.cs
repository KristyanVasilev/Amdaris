namespace BookShop.Presentantion.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class ProductPostDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
