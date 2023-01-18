namespace BookShop.Application.Publications.Queries.GetPublicationsByKeyWord
{
    using MediatR;

    public class GetPublicationsByKeyWordQuery : IRequest<IEnumerable<PublicationDto>>
    {
        public GetPublicationsByKeyWordQuery(string keyWord)
        {
            this.KeyWord = keyWord;
        }

        public string KeyWord { get; set; }
    }
}
