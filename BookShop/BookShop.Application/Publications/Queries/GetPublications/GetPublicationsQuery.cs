namespace BookShop.Application.Publications.Queries.GetPublication
{
    using BookShop.Application.Publications.Queries;
    using MediatR;

    public class GetPublicationsQuery : IRequest<IEnumerable<PublicationViewModel>>
    {
    }
}
