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
            var genre = new Genre("Triller");
            var isEnumParsed = Enum.TryParse(command.PublicationType, true, out PublicationType parsedEnumValue);
            Console.WriteLine(isEnumParsed ? parsedEnumValue : throw new InvalidOperationException("Invalid enum type! The type should be Book, Magazine, Comics, Dictionary, TextBook."));

            var product = new Publication
            {
                Id = command.Id,
                Price = command.Price,
                Name = command.Name,
                Author = command.Author,
                PageCount = command.PageCount,
                Rating = command.Rating,
                Description = command.Description,
                PublicationType = parsedEnumValue,
                Genre = genre,
            };

            this.repository.CreateProduct(product);

            return Task.FromResult(product.Id);
        }
    }
}
