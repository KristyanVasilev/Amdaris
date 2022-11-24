namespace BookShop.Application.WritingUtensils.Commands.DeleteUtensils
{
    using BookShop.Application.Contracts;
    using MediatR;

    public class DeleteUtensilHandler : IRequestHandler<DeleteUtensilCommand, string>
    {
        private readonly IWritingUtensilsRepository repository;

        public DeleteUtensilHandler(IWritingUtensilsRepository repository)
        {
            this.repository = repository;
        }

        public Task<string> Handle(DeleteUtensilCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.repository.DeleteUtensil(request.Id));
        }
    }
}
