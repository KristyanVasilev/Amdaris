namespace BookShop.Domain.Hobbies
{
    using BookShop.Domain.Hobbies.Enums;

    public class Game : Product
    {
        public string Manufacturer { get; set; } = null!;

        public string Description { get; set; } = null!;

        public GameType GameType { get; set; }
    }
}
