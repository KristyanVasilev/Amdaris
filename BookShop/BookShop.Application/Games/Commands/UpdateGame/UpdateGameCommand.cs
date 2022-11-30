namespace BookShop.Application.Games.Commands.UpdateGame
{
    using MediatR;

    public class UpdateGameCommand : BaseProductDto, IRequest<int>
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; } = null!;

        public string Description { get; set; } = null!;

        public GenreDto Genre { get; set; } = null!;
    }
}
