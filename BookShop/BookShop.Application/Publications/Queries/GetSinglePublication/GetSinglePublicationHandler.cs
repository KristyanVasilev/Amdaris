namespace BookShop.Application.Publications.Queries.GetSinglePublication
{
    using MediatR;

    public class GetSinglePublicationHandler : IRequestHandler<GetSinglePublicationQuery, PublicationViewModel>
    {

        private readonly IProductRepository repository;

        public GetSinglePublicationHandler(IProductRepository repository)
        {
            this.repository = repository;
        }

        public Task<PublicationViewModel> Handle(GetSinglePublicationQuery request, CancellationToken cancellationToken)
        {
            var publication = this.repository.GetSinglePublication(request.Id);

            var result = new PublicationViewModel
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
            };

            return Task.FromResult(result);
        }
    }
}
