namespace BookShop.Application.Games.Queries.GetSingleGame
{
    using MediatR;

    public class GetSingleGameQuery : IRequest<GameDto>
    {
        public int Id { get; set; }

        public GetSingleGameQuery(int id)
        {
            this.Id = id;
        }
    }
}
