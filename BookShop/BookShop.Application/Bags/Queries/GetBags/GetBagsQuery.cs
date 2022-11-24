namespace BookShop.Application.Bags.Queries.GetBags
{
    using MediatR;

    public class GetBagsQuery : IRequest<IEnumerable<BagDto>>
    {
    }
}
