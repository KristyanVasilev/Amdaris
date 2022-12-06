namespace BookShop.Application.Publications.Commands.DeletePublication
{
    using MediatR;

    public class DeletePublicationCommand : IRequest<string>
    {
        public DeletePublicationCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
