namespace BookShop.Application.Games.Queries.GetSingleGame
{
    using MediatR;

    public class GetGameByIdQuery : IRequest<GameDto>
    {
        public int Id { get; set; }

        public GetGameByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
