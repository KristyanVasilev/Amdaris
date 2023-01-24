namespace BookShop.Application.Games.Commands.AddQuantity
{
    using MediatR;

    public class AddQuantityToGameCommand : IRequest<string>
    {
        public AddQuantityToGameCommand(int id, int quantity)
        {
            this.Id = id;
            this.Quantity = quantity;
        }

        public int Id { get; set; }

        public int Quantity { get; set; }
    }
}
