namespace BookShop.Application.Publications.Queries.GetPublicationByAuthor
{
    using MediatR;

    public class GetPublicationByAuthorQuery : IRequest<IEnumerable<PublicationDto>>
    {
        public GetPublicationByAuthorQuery(string authorName)
        {
            this.AuthorName = authorName;
        }

        public string AuthorName { get; set; }
    }
}
