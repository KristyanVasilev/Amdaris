namespace BookShop.Application.Bags.Commands.CreateBag
{
    using MediatR;

    public class CreateBagCommand : BaseProductDto, IRequest<int>
    {
        public string Color { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public int Capacity { get; set; }

        public BagTypeDto BagType { get; set; } = null!;

        public string Gender { get; set; } = null!;
    }
}
