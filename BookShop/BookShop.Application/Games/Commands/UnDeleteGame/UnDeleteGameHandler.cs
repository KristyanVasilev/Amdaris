namespace BookShop.Application.Games.Commands.UnDeleteGame
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class UnDeleteGameHandler : IRequestHandler<UnDeleteGameCommand, GameDto>
    {
        private readonly IDeletableEntityRepository<Game> repository;
        private readonly IRepository<Genre> genreRepository;

        public UnDeleteGameHandler(
            IDeletableEntityRepository<Game> repository,
            IRepository<Genre> genreRepository)
        {
            this.repository = repository;
            this.genreRepository = genreRepository;
        }

        public async Task<GameDto> Handle(UnDeleteGameCommand request, CancellationToken cancellationToken)
        {
            var game = this.repository
                           .AllAsNoTrackingWithDeleted()
                           .Where(x => x.IsDeleted == true)
                           .FirstOrDefault(x => x.Name == request.Name)
                           ?? throw new GameNotFoundException("Game not found!");

            this.repository.Undelete(game);
            await this.repository.SaveChangesAsync();

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
