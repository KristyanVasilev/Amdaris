namespace BookShop.Application.WritingUtensils.Commands.DeleteUtensils
{
    using MediatR;

    public class DeleteUtensilCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
