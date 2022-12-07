namespace BookShop.Application.Games.Commands.UpdateGame
{
    using MediatR;

    public class UpdateGameCommand : BaseProductDto, IRequest<int>
    {
        public string Manufacturer { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Genre { get; set; } = null!;
    }
}
