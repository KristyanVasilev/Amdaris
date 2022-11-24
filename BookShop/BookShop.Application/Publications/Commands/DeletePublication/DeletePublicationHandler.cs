namespace BookShop.Application.Publications.Commands.DeletePublication
{
    using BookShop.Application.Contracts;
    using MediatR;

    public class DeletePublicationHandler : IRequestHandler<DeletePublicationCommand, string>
    {
        private readonly IPublicationRepository repository;

        public DeletePublicationHandler(IPublicationRepository repository)
        {
            this.repository = repository;
        }

        public Task<string> Handle(DeletePublicationCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.repository.DeletePublication(request.Id));           
        }
    }
}
