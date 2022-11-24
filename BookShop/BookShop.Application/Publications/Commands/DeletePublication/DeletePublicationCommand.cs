namespace BookShop.Application.Publications.Commands.DeletePublication
{
    using MediatR;

    public class DeletePublicationCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
