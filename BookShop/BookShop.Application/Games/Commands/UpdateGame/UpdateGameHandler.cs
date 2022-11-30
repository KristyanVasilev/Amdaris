namespace BookShop.Application.Games.Commands.UpdateGame
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class UpdateGameHandler : IRequestHandler<UpdateGameCommand, int>
    {
        private readonly IDeletableEntityRepository<Game> repository;

        public UpdateGameHandler(IDeletableEntityRepository<Game> repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre { Name = request.Genre.Name };

            var game = this.repository.AllAsNoTracking().FirstOrDefault(x => x.Id == request.Id);
            if (game == null)
            {
                throw new InvalidOperationException("Game cannot be null!");
            }

            game.Price = request.Price;
            game.Name = request.Name;
            game.Description = request.Description;
            game.Genre = genre;

            this.repository.Update(game);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult(game.Id);
        }
    }
}
