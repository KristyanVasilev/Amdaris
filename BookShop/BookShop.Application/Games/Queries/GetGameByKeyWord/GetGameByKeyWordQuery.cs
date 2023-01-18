namespace BookShop.Application.Games.Queries.GetGameByKeyWord
{
    using MediatR;

    public class GetGameByKeyWordQuery : IRequest<IEnumerable<GameDto>>
    {
        public GetGameByKeyWordQuery(string keyWord)
        {
            this.KeyWord = keyWord;
        }

        public string KeyWord { get; set; }
    }
}
