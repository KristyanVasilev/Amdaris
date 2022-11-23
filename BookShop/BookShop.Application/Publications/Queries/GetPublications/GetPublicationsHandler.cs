namespace BookShop.Application.Publications.Queries.GetPublication
{
    using BookShop.Application.Publications.Queries;
    using MediatR;

    public class GetPublicationsHandler : IRequestHandler<GetPublicationsQuery, IEnumerable<PublicationViewModel>>
    {
        private readonly IPublicationRepository repository;

        public GetPublicationsHandler(IPublicationRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<PublicationViewModel>> Handle(GetPublicationsQuery request, CancellationToken cancellationToken)
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
