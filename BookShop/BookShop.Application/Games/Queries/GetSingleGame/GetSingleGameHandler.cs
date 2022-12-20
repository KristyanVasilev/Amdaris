namespace BookShop.Application.Games.Queries.GetSingleGame
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class GetSingleGameHandler : IRequestHandler<GetSingleGameQuery, GameDto>
    {
        private readonly IDeletableEntityRepository<Game> repository;
        private readonly IRepository<Genre> genreRepository;

        public GetSingleGameHandler(
            IDeletableEntityRepository<Game> repository,
            IRepository<Genre> genreRepository)
        {
            this.repository = repository;
            this.genreRepository = genreRepository;
        }

        public async Task<GameDto> Handle(GetSingleGameQuery request, CancellationToken cancellationToken)
        {
            var game = this.repository
                           .AllAsNoTracking()
                           .FirstOrDefault(x => x.Id == request.Id)
                           ?? throw new InvalidOperationException("Game not found!");

            var genre = this.genreRepository.AllAsNoTracking().FirstOrDefault(g => g.Id == game.GenreId);

            var result = new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Price = game.Price,
                Description = game.Description,
                Manufacturer = game.Manufacturer,
                Images = game.Images,
                Genre = genre?.Name ?? "No genre",
            };

            return await Task.FromResult(result);
        }
    }
}
