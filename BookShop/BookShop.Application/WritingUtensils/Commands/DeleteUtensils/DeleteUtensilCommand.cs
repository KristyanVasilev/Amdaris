namespace BookShop.Application.WritingUtensils.Commands.DeleteUtensils
{
    using MediatR;

    public class DeleteUtensilCommand : IRequest<string>
    {
        public DeleteUtensilCommand(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
