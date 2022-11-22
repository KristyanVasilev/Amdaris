namespace BookShop.Application.Games.Commands.CreateGame
{
    using MediatR;

    public class CreateGameCommand : BaseProductModel, IRequest<int>
    {
        public string Manufacturer { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string GameType { get; set; } = null!;
    }
}
