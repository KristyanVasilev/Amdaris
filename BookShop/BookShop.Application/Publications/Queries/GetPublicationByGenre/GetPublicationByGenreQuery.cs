namespace BookShop.Application.Publications.Queries.GetPublicationByGenre
{
    using MediatR;

    public class GetPublicationByGenreQuery : IRequest<IEnumerable<PublicationDto>>
    {
        public GetPublicationByGenreQuery(string genreName)
        {
            this.GenreName = genreName;
        }

        public string GenreName { get; set; }
    }
}
