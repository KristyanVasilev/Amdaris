namespace BookShop.Application.Bags.Commands.DeleteBag
{
    using MediatR;

    public class DeleteBagCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
