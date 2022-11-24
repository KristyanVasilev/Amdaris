namespace BookShop.Application.Games.Queries.GetGames
{
    using BookShop.Application.Contracts;
    using MediatR;

    public class GetGamesHandler : IRequestHandler<GetGamesQuery, IEnumerable<GameDto>>
    {
        private readonly IGameRepository repository;

        public GetGamesHandler(IGameRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<GameDto>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
        {
            var result = this.repository.GetGames().Select(game => new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Price = game.Price,
                Description = game.Description,
                Manufacturer = game.Manufacturer,
                GameType = game.GameType.ToString(),
            });

            return Task.FromResult(result);
        }
    }
}
