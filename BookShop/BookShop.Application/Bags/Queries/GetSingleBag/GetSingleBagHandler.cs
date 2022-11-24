namespace BookShop.Application.Bags.Queries.GetSingleBag
{
    using BookShop.Application.Contracts;
    using MediatR;

    public class GetSingleBagHandler : IRequestHandler<GetSingleBagQuery, BagDto>
    {
        private readonly IBagRepository repository;

        public GetSingleBagHandler(IBagRepository repository)
        {
            this.repository = repository;
        }

        public Task<BagDto> Handle(GetSingleBagQuery request, CancellationToken cancellationToken)
        {
            var bag = this.repository.GetSingleBag(request.Id);

            var result = new BagDto
            {
                Id = bag.Id,
                Name = bag.Name,
                Price = bag.Price,
                Capacity= bag.Capacity,
                Color= bag.Color,
                Manufacturer = bag.Manufacturer,
                BagType = bag.BagType.Name,
                Gender = bag.Gender.ToString(),
            };

            return Task.FromResult(result);
        }
    }
}
