namespace BookShop.Application.Bags.Commands.DeleteBag
{
    using BookShop.Application.Contracts;
    using MediatR;

    public class DeleteBagHandler : IRequestHandler<DeleteBagCommand, string>
    {
        private readonly IBagRepository repository;

        public DeleteBagHandler(IBagRepository repository)
        {
            this.repository = repository;
        }

        public Task<string> Handle(DeleteBagCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(repository.DeleteBag(request.Id));
        }
    }
}
