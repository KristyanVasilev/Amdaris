namespace BookShop.Application.WritingUtensils.Commands.AddQuantity
{
    using MediatR;

    public class AddQuantityToUtensilCommand : IRequest<string>
    {
        public AddQuantityToUtensilCommand(int id, int quantity)
        {
            this.Id = id;
            this.Quantity = quantity;
        }

        public int Id { get; set; }

        public int Quantity { get; set; }
    }
}
