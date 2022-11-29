namespace BookShop.Application.Publications.Queries.GetPublication
{
    using BookShop.Application.Publications;
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class GetPublicationsHandler : IRequestHandler<GetPublicationsQuery, IEnumerable<PublicationDto>>
    {
        private readonly IDeletableEntityRepository<Publication> repository;

        public GetPublicationsHandler(IDeletableEntityRepository<Publication> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<PublicationDto>> Handle(GetPublicationsQuery request, CancellationToken cancellationToken)
        {
            var result = this.repository.AllAsNoTracking().Select(publication => new PublicationDto
            {
                Id = publication.Id,
                Name = publication.Name,
                Price = publication.Price,
                Author = publication.Author,
                PageCount = publication.PageCount,
                Rating = publication.Rating,
                Description = publication.Description,
                Genre = publication.Genre.Name,
            });

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return await Task.FromResult(result);
        }
    }
}
