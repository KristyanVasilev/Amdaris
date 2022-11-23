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

        public Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var isEnumParsed = Enum.TryParse(request.GameType, true, out GameType parsedEnumValue);
            Console.WriteLine(isEnumParsed ? parsedEnumValue : throw new InvalidOperationException("Invalid enum type!"));

            var game = new Game
            {
                Id = request.Id,
                Price = request.Price,
                Name = request.Name,
                Description= request.Description,
                Manufacturer= request.Manufacturer,
                GameType = parsedEnumValue,
            };

            this.repository.CreateProduct(game);

            return Task.FromResult(game.Id);
        }
    }
}
