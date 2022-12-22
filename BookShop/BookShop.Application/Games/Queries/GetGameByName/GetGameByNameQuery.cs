namespace BookShop.Application.Games.Queries.GetGameByName
{
    using MediatR;

    public class GetGameByNameQuery : IRequest<GameDto>
    {
        public GetGameByNameQuery(string name)
        {
            this.Name = name;
        }

        public string? Name { get; set; }
    }
}
