namespace BookShop.Application.Publications.Queries.GetPublication
{
    using MediatR;

    public class GetPublicationsQuery : IRequest<IEnumerable<PublicationDto>>
    {
    }
}
