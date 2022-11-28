namespace BookShop.Application.Publications.Queries.GetSinglePublication
{
    using BookShop.Application.Publications;
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class GetSinglePublicationHandler : IRequestHandler<GetSinglePublicationQuery, PublicationDto>
    {

        private readonly IDeletableEntityRepository<Publication> repository;

        public GetSinglePublicationHandler(IDeletableEntityRepository<Publication> repository)
        {
            this.repository = repository;
        }

        public async Task<PublicationDto> Handle(GetSinglePublicationQuery request, CancellationToken cancellationToken)
        {
            var publication = this.repository.AllAsNoTracking().FirstOrDefault(x => x.Id == request.Id);

            var result = new PublicationDto
            {
                Id = publication.Id,
                Name = publication.Name,
                Price = publication.Price,
                Author = publication.Author,
                PageCount = publication.PageCount,
                Rating = publication.Rating,
                Description = publication.Description,
                Genre = publication.Genre.Name,
            };

            return await Task.FromResult(result);
        }
    }
}
