namespace BookShop.Application.Games
{
    public class GameDto : BaseProductDto
    {
        public string Manufacturer { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string GameType { get; set; } = null!;
    }
}
