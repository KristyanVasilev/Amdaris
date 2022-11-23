namespace BookShop.Application.Publications.Commands.CreatePublication
{
    using BookShop.Domain.Publications;
    using MediatR;

    public class CreatePublicationHandler : IRequestHandler<CreatePublicationCommand, int>
    {
        private readonly IProductRepository repository;

        public CreatePublicationHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public Task<int> Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre(request.Genre.ToString());
            var isEnumParsed = Enum.TryParse(request.PublicationType, true, out PublicationType parsedEnumValue);
            Console.WriteLine(isEnumParsed ? parsedEnumValue : throw new InvalidOperationException("Invalid enum type! The type should be Book, Magazine, Comics, Dictionary, TextBook."));

            var publication = new Publication
            {
                Id = request.Id,
                Price = request.Price,
                Name = request.Name,
                Author = request.Author,
                PageCount = request.PageCount,
                Rating = request.Rating,
                Description = request.Description,
                PublicationType = parsedEnumValue,
                Genre = genre,
            };

            this.repository.CreateProduct(publication);

            return Task.FromResult(publication.Id);
        }
    }
}
