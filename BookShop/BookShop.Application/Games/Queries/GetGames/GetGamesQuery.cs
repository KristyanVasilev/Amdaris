namespace BookShop.Application.Games.Queries.GetGames
{
    using MediatR;

    public class GetGamesQuery : IRequest<IEnumerable<GameDto>>
    {
    }
}
