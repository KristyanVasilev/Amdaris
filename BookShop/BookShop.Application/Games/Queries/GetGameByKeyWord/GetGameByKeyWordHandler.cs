namespace BookShop.Application.Games.Queries.GetGameByKeyWord
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class GetGameByKeyWordHandler : IRequestHandler<GetGameByKeyWordQuery, IEnumerable<GameDto>>
    {
        private readonly IDeletableEntityRepository<Game> repository;

        public GetGameByKeyWordHandler(IDeletableEntityRepository<Game> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<GameDto>> Handle(GetGameByKeyWordQuery request, CancellationToken cancellationToken)
        {
            var result = this.repository.AllAsNoTracking().Where(k => k.KeyWords.Contains(request.KeyWord)).Select(game => new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Price = game.Price,
                Description = game.Description,
                Manufacturer = game.Manufacturer,
                Genre = game.Genre.Name,
                Images = game.Images,
                Quantity = game.Quantity,
                KeyWords = game.KeyWords,

            }).OrderBy(x => x.Price);

            if (!result.Any())
            {
                throw new GameNotFoundException("No games found!");
            }

            return await Task.FromResult(result);
        }
    }
}
