namespace BookShop.Application.Games.Commands.CreateGame
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class CreateGameHandler : IRequestHandler<CreateGameCommand, int>
    {
        private readonly IDeletableEntityRepository<Game> repository;
        private readonly IRepository<Genre> genreRepository;

        public CreateGameHandler(
            IDeletableEntityRepository<Game> repository,
             IRepository<Genre> genreRepository)
        {
            this.repository = repository;
            this.genreRepository = genreRepository;
        }

        public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var genre = this.genreRepository
                            .AllAsNoTracking()
                            .FirstOrDefault(x => x.Name == request.Genre)
                            ?? new Genre { Name = request.Genre, CreatedOn = DateTime.UtcNow };

            var game = new Game
            {
                Price = request.Price,
                Name = request.Name,
                Description = request.Description,
                Manufacturer = request.Manufacturer,
                Images = request.Images,
                CreatedOn = DateTime.UtcNow,
            };

            if (genre.Id == 0) game.Genre = genre;           
            else game.GenreId = genre.Id;

            await this.repository.AddAsync(game);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult(game.Id);
        }
    }
}
