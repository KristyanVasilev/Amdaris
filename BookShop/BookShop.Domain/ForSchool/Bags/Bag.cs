namespace BookShop.Domain.ForSchool.Bags
{
    using BookShop.Domain.ForSchool.Bags.Enums;

    public class Bag : Product
    {
        public string Color { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public int Capacity { get; set; }

        public BagType BagType { get; set; } = null!;

        public Gender Gender { get; set; }
    }
}
