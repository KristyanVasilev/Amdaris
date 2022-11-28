namespace BookShop.Application.Games.Commands.DeleteGame
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class DeleteGameHandler : IRequestHandler<DeleteGameCommand, string>
    {
        private readonly IDeletableEntityRepository<Game> repository;

        public DeleteGameHandler(IDeletableEntityRepository<Game> repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var game = this.repository.AllAsNoTracking().FirstOrDefault(x => x.Id == request.Id);
            if (game == null)
            {
                throw new InvalidOperationException("Game cannot be null!");
            }

            this.repository.Delete(game);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult($"Game with id - {game.Id} deleted successfully!");
        }
    }
}
