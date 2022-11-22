namespace BookShop.Application.Games.Commands.CreateGame
{
    using BookShop.Domain.Hobbies;
    using BookShop.Domain.Hobbies.Enums;
    using MediatR;

    public class CreateGamehandler : IRequestHandler<CreateGameCommand, int>
    {
        private readonly IProductRepository repository;

        public CreateGamehandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public Task<int> Handle(CreateGameCommand command, CancellationToken cancellationToken)
        {
            var isEnumParsed = Enum.TryParse(command.GameType, true, out GameType parsedEnumValue);
            Console.WriteLine(isEnumParsed ? parsedEnumValue : throw new InvalidOperationException("Invalid enum type!"));

            var game = new Game
            {
                Id = command.Id,
                Price = command.Price,
                Name = command.Name,
                Description= command.Description,
                Manufacturer= command.Manufacturer,
                GameType = parsedEnumValue,
            };

            this.repository.CreateGame(game);

            return Task.FromResult(game.Id);
        }
    }
}
