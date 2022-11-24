namespace BookShop.Application.Publications.Queries.GetPublication
{
    using BookShop.Application.Contracts;
    using BookShop.Application.Publications;
    using MediatR;

    public class GetPublicationsHandler : IRequestHandler<GetPublicationsQuery, IEnumerable<PublicationDto>>
    {
        private readonly IPublicationRepository repository;

        public GetPublicationsHandler(IPublicationRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<PublicationDto>> Handle(GetPublicationsQuery request, CancellationToken cancellationToken)
        {
            var result = this.repository.GetPublications().Select(publication => new PublicationDto
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
