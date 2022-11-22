namespace BookShop.Application.Publications.Queries.GetPublication
{
    using BookShop.Application.Publications.Queries.GetProducts;
    using MediatR;

    public class GetPublicationQuery : IRequest<IEnumerable<PublicationViewModel>>
    {
    }
}
