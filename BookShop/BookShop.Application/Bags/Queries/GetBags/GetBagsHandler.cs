namespace BookShop.Application.Bags.Queries.GetBags
{
    using BookShop.Application.Contracts;
    using MediatR;

    public class GetBagsHandler : IRequestHandler<GetBagsQuery, IEnumerable<BagDto>>
    {
        private readonly IBagRepository repository;

        public GetBagsHandler(IBagRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<BagDto>> Handle(GetBagsQuery request, CancellationToken cancellationToken)
        {
            var result = this.repository.GetBags().Select(bag => new BagDto
            {
                Id = bag.Id,
                Name = bag.Name,
                Price = bag.Price,
                Capacity = bag.Capacity,
                Color = bag.Color,
                Manufacturer = bag.Manufacturer,
                BagType = bag.BagType.Name,
                Gender = bag.Gender.ToString(),
            });

            return Task.FromResult(result);
        }
    }
}
