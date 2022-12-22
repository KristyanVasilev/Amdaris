namespace BookShop.Application.Publications.Queries.GetPublicationByName
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class GetPublicationByNameHandler : IRequestHandler<GetPublicationByNameQuery, PublicationDto>
    {
        private readonly IDeletableEntityRepository<Publication> repository;
        private readonly IRepository<Genre> genreRepository;

        public GetPublicationByNameHandler(
            IDeletableEntityRepository<Publication> repository,
            IRepository<Genre> genreRepository)
        {
            this.repository = repository;
            this.genreRepository = genreRepository;
        }

        public async Task<PublicationDto> Handle(GetPublicationByNameQuery request, CancellationToken cancellationToken)
        {
            var publication = this.repository
                               .AllAsNoTracking()
                               .FirstOrDefault(x => x.Name == request.Name)
                               ?? throw new PublicationNotFoundException("Publication not found!");

            var genre = this.genreRepository.AllAsNoTracking().FirstOrDefault(g => g.Id == publication.GenreId);

            var result = new PublicationDto
            {
                Id = publication.Id,
                Name = publication.Name,
                Price = publication.Price,
                Author = publication.Author,
                PageCount = publication.PageCount,
                Rating = publication.Rating,
                Description = publication.Description,
                Images = publication.Images,
                Genre = genre?.Name ?? "No genre",
            };

            return await Task.FromResult(result);
        }
    }
}
