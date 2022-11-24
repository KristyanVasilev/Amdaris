namespace BookShop.Application.Bags.Queries.GetSingleBag
{
    using MediatR;

    public class GetSingleBagQuery : IRequest<BagDto>
    {
        public int Id { get; set; }

        public GetSingleBagQuery(int id)
        {
            this.Id = id;
        }
    }
}
