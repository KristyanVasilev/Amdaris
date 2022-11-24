namespace BookShop.Application.Games.Queries.GetSingleGame
{
    using BookShop.Application.Contracts;
    using MediatR;

    public class GetSingleGameHandler : IRequestHandler<GetSingleGameQuery, GameDto>
    {
        private readonly IGameRepository repository;

        public GetSingleGameHandler(IGameRepository repository)
        {
            this.repository = repository;
        }

        public Task<GameDto> Handle(GetSingleGameQuery request, CancellationToken cancellationToken)
        {
            var game = this.repository.GetSingleGame(request.Id);

            var result = new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Price = game.Price,
                Description = game.Description,
                Manufacturer = game.Manufacturer,
                GameType = game.GameType.ToString(),
            };

            return Task.FromResult(result);
        }
    }
}
