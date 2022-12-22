namespace BookShop.Application.Games.Queries.GetGamesByGenre
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class GetGamesByGenreHandler : IRequestHandler<GetGamesByGenreQuery, IEnumerable<GameDto>>
    {
        private readonly IDeletableEntityRepository<Game> repository;
        private readonly IRepository<Genre> genreRepository;

        public GetGamesByGenreHandler(
            IDeletableEntityRepository<Game> repository,
            IRepository<Genre> genreRepository)
        {
            this.repository = repository;
            this.genreRepository = genreRepository;
        }

        public async Task<IEnumerable<GameDto>> Handle(GetGamesByGenreQuery request, CancellationToken cancellationToken)
        {
            var genre = this.genreRepository
                            .AllAsNoTracking()
                            .FirstOrDefault(g => g.Name == request.GenreName)
                            ?? throw new GenreNotFoundException("Genre not found!");

            var result = this.repository.AllAsNoTracking().Where(x => x.GenreId == genre.Id).Select(game => new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Price = game.Price,
                Description = game.Description,
                Manufacturer = game.Manufacturer,
                Genre = game.Genre.Name,
                Images = game.Images,

            }).OrderBy(x => x.Price);

            if (!result.Any())
            {
                throw new GameNotFoundException("No games found!");
            }

            return await Task.FromResult(result);
        }
    }
}
