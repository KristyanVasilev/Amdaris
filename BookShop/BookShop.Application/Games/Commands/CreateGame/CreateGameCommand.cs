namespace BookShop.Application.Games.Commands.CreateGame
{
    using BookShop.Application;
    using MediatR;

    public class CreateGameCommand : BaseProductDto, IRequest<int>
    {
        public string Manufacturer { get; set; } = null!;

        public string Description { get; set; } = null!;

        public GenreDto Genre { get; set; } = null!;
    }
}
