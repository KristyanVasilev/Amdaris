namespace BookShop.Application.Games.Queries.GetGameById
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class GetGameByIdHandler : IRequestHandler<GetGameByIdQuery, GameDto>
    {
        private readonly IDeletableEntityRepository<Game> repository;
        private readonly IRepository<Genre> genreRepository;

        public GetGameByIdHandler(
            IDeletableEntityRepository<Game> repository,
            IRepository<Genre> genreRepository)
        {
            this.repository = repository;
            this.genreRepository = genreRepository;
        }

        public async Task<GameDto> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            var game = this.repository
                           .AllAsNoTracking()
                           .FirstOrDefault(x => x.Id == request.Id)
                           ?? throw new GameNotFoundException("Game not found!");

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
