namespace BookShop.Application.Games.Commands.AddQuantity
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class AddQuantityToGameHandler : IRequestHandler<AddQuantityToGameCommand, string>
    {
        private readonly IDeletableEntityRepository<Game> repository;

        public AddQuantityToGameHandler(IDeletableEntityRepository<Game> repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(AddQuantityToGameCommand request, CancellationToken cancellationToken)
        {
            var game = this.repository
                         .AllAsNoTracking()
                         .FirstOrDefault(x => x.Id == request.Id)
                         ?? throw new GameNotFoundException("Game not found!");

            game.Quantity += request.Quantity;

            this.repository.Update(game);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult($"Game {game.Name} with id - {game.Id} added {request.Quantity} quantity successfully!");
        }
    }
}
