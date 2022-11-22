namespace BookShop.Application.Publications.Queries.GetPublication
{
    using BookShop.Application.Publications.Queries.GetProducts;
    using MediatR;
    public class GetPublicationHandler : IRequestHandler<GetPublicationQuery, IEnumerable<PublicationViewModel>>
    {
        private readonly IProductRepository repository;

        public GetPublicationHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<PublicationViewModel>> Handle(GetPublicationQuery request, CancellationToken cancellationToken)
        {
            var result = this.repository.GetPublications().Select(publication => new PublicationViewModel
            {
                Id = publication.Id,
                Name = publication.Name,
                Price = publication.Price,
                Author = publication.Author,
                PageCount = publication.PageCount,
                Rating = publication.Rating,
                Description = publication.Description,
                PublicationType = publication.PublicationType.ToString(),
                Genre = publication.Genre.Name,
            });

            return Task.FromResult(result);
        }
    }
}
