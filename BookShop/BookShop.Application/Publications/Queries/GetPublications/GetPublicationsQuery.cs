namespace BookShop.Application.Publications.Queries.GetPublication
{
    using BookShop.Application.Publications;
    using MediatR;

    public class GetPublicationsQuery : IRequest<IEnumerable<PublicationViewModel>>
    {
    }
}
