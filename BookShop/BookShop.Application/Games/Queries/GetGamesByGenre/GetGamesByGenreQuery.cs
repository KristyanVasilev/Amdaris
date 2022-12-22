namespace BookShop.Application.Games.Queries.GetGamesByGenre
{
    using MediatR;

    public class GetGamesByGenreQuery : IRequest<IEnumerable<GameDto>>
    {
        public GetGamesByGenreQuery(string genreName)
        {
            this.GenreName = genreName;
        }

        public string? GenreName { get; set; }
    }
}