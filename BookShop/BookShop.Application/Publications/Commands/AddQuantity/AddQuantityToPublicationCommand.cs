namespace BookShop.Application.Publications.Commands.AddQuantity
{
    using MediatR;

    public class AddQuantityToPublicationCommand : IRequest<string>
    {
        public AddQuantityToPublicationCommand(int id, int quantity)
        {
            this.Id = id;
            this.Quantity = quantity;
        }

        public int Id { get; set; }

        public int Quantity { get; set; }
    }
}
