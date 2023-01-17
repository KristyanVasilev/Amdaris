namespace BookShop.Presentantion.DTOs
{
    public class PublicationGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Author { get; set; } = null!;

        public decimal Price { get; set; }

        public int PageCount { get; set; }

        public string Description { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string[] Images { get; set; } = null!;

        public string KeyWords { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
