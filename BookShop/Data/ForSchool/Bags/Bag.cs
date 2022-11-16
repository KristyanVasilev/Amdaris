namespace BookShop.Data.ForSchool.Bags
{
    using BookShop.Data.ForSchool.Bags.Enums;
    using System.Text;

    public class Bag : Product
    {
        public string Color { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public int Capacity { get; set; }

        public BagType BagType { get; set; } = null!;

        public Gender Gender { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine($"Color: {this.Color}.");
            sb.AppendLine($"Manufacturer: {this.Manufacturer}.");
            sb.AppendLine($"This bag is for {this.Gender.ToString()}");
            return sb.ToString().TrimEnd();
        }
    }
}
