namespace BookShop.Application.Games.Queries.GetSingleGame
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class GetSingleGameHandler : IRequestHandler<GetSingleGameQuery, GameDto>
    {
        private readonly IDeletableEntityRepository<Game> repository;

        public GetSingleGameHandler(IDeletableEntityRepository<Game> repository)
        {
            this.repository = repository;
        }

        public async Task<GameDto> Handle(GetSingleGameQuery request, CancellationToken cancellationToken)
        {
            var game = this.repository.AllAsNoTracking().FirstOrDefault(x => x.Id == request.Id);

            var result = new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Price = game.Price,
                Description = game.Description,
                Manufacturer = game.Manufacturer,
                GameType = game.Genre.Name,
            };

            return await Task.FromResult(result);
        }
    }
}
