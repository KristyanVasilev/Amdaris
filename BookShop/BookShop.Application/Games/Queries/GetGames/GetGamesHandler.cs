namespace BookShop.Application.Games.Queries.GetGames
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class GetGamesHandler : IRequestHandler<GetGamesQuery, IEnumerable<GameDto>>
    {
        private readonly IDeletableEntityRepository<Game> repository;

        public GetGamesHandler(IDeletableEntityRepository<Game> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<GameDto>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
        {
            var result = this.repository.AllAsNoTracking().Select(game => new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Price = game.Price,
                Description = game.Description,
                Manufacturer = game.Manufacturer,
                Genre = game.Genre.Name,
                Images = game.Images,
            });

            if (!result.Any())
            {
                throw new InvalidOperationException();
            }

            return await Task.FromResult(result);
        }
    }
}
