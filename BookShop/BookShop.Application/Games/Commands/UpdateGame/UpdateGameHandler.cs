namespace BookShop.Application.Games.Commands.UpdateGame
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class UpdateGameHandler : IRequestHandler<UpdateGameCommand, int>
    {
        private readonly IDeletableEntityRepository<Game> repository;
        private readonly IRepository<Genre> genreRepository;

        public UpdateGameHandler(
            IDeletableEntityRepository<Game> repository,
            IRepository<Genre> genreRepository)
        {
            this.repository = repository;
            this.genreRepository = genreRepository;
        }

        public async Task<int> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var genre = this.genreRepository
                             .AllAsNoTracking()
                             .FirstOrDefault(x => x.Name == request.Genre)
                             ?? new Genre { Name = request.Genre, CreatedOn = DateTime.UtcNow };

            var game = this.repository
                           .AllAsNoTracking()
                           .FirstOrDefault(x => x.Id == request.Id)
                           ?? throw new InvalidOperationException("Game not found!");

            game.Price = request.Price;
            game.Name = request.Name;
            game.Description = request.Description;
            game.Images = request.Images;
            game.ModifiedOn = DateTime.UtcNow;

            if (genre.Id == 0) game.Genre = genre;
            else game.GenreId = genre.Id;

            this.repository.Update(game);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult(game.Id);
        }
    }
}
