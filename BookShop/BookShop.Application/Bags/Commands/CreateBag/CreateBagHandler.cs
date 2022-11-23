namespace BookShop.Application.Bags.Commands.CreateBag
{
    using BookShop.Domain.ForSchool.Bags;
    using BookShop.Domain.ForSchool.Bags.Enums;
    using MediatR;

    public class CreateBagHandler : IRequestHandler<CreateBagCommand, int>
    {
        private readonly IBagRepository repository;

        public CreateBagHandler(IBagRepository repository)
        {
            this.repository = repository;
        }

        public Task<int> Handle(CreateBagCommand request, CancellationToken cancellationToken)
        {
            var bagType = new BagType
            {
                Name = request.BagType.Name,
            };
            var isEnumParsed = Enum.TryParse(request.Gender, true, out Gender parsedEnumValue);
            Console.WriteLine(isEnumParsed ? parsedEnumValue : throw new InvalidOperationException("Invalid enum type!"));

            var bag = new Bag
            {
                Id = request.Id,
                Price = request.Price,
                Name = request.Name,
                Capacity= request.Capacity,
                Color = request.Color,
                Manufacturer = request.Manufacturer,
                Gender = parsedEnumValue,
                BagType = bagType,
            };

            this.repository.CreateBag(bag);

            return Task.FromResult(bag.Id);
        }
    }
}
