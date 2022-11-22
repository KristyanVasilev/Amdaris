namespace BookShop.Domain
{
    using System.Text;

    public abstract class Product
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; } = null!;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Product {this.Name} has Id - {this.Id} and cost {this.Price}$.");
            return sb.ToString();
        }
    }
}
