namespace BookShop.Application.Publications.Commands.CreatePublication
{
    using BookShop.Data.Publications;
    using MediatR;

    public class CreatePublicationHandler : IRequestHandler<CreatePublicationCommand, int>
    {
        private readonly IProductRepository repository;

        public CreatePublicationHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public Task<int> Handle(CreatePublicationCommand command, CancellationToken cancellationToken)
        {
            var product = new Publication(command.Id, command.Price, command.Name, command.Author, command.Description, command.PageCount, command.Genre);
            this.repository.CreateProduct(product);

            return Task.FromResult(product.Id);
        }
    }
}
