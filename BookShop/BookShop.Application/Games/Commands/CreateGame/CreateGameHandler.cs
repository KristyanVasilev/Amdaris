namespace BookShop.Application.Games.Commands.CreateGame
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class CreateGamehandler : IRequestHandler<CreateGameCommand, int>
    {
        private readonly IDeletableEntityRepository<Game> repository;

        public CreateGamehandler(IDeletableEntityRepository<Game> repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre { Name = request.Genre.Name };

            var game = new Game
            {
                Id = request.Id,
                Price = request.Price,
                Name = request.Name,
                Description= request.Description,
                Manufacturer= request.Manufacturer,
                Genre = genre,
            };

            await this.repository.AddAsync(game);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult(game.Id);
        }
    }
}
