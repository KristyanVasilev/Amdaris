namespace BookShop.Application.Bags.Commands.CreateBag
{
    using BookShop.Domain.ForSchool.Bags;
    using BookShop.Domain.ForSchool.Bags.Enums;
    using MediatR;

    public class CreateBagHandler : IRequestHandler<CreateBagCommand, int>
    {
        private readonly IProductRepository repository;

        public CreateBagHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public Task<int> Handle(CreateBagCommand command, CancellationToken cancellationToken)
        {
            var bagType = new BagType
            {
                Name = command.BagType.Name,
            };
            var isEnumParsed = Enum.TryParse(command.Gender, true, out Gender parsedEnumValue);
            Console.WriteLine(isEnumParsed ? parsedEnumValue : throw new InvalidOperationException("Invalid enum type!"));

            var bag = new Bag
            {
                Id = command.Id,
                Price = command.Price,
                Name = command.Name,
                Capacity= command.Capacity,
                Color = command.Color,
                Manufacturer = command.Manufacturer,
                Gender = parsedEnumValue,
                BagType = bagType,
            };

            this.repository.CreateBag(bag);

            return Task.FromResult(bag.Id);
        }
    }
}
