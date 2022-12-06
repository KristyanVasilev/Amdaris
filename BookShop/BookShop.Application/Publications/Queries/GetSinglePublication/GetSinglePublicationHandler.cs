namespace BookShop.Application.Publications.Queries.GetSinglePublication
{
    using BookShop.Application.Publications;
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class GetSinglePublicationHandler : IRequestHandler<GetSinglePublicationQuery, PublicationDto>
    {

        private readonly IDeletableEntityRepository<Publication> repository;
        private readonly IRepository<Genre> genreRepository;

        public GetSinglePublicationHandler(
            IDeletableEntityRepository<Publication> repository, 
            IRepository<Genre> genreRepository)
        {
            this.repository = repository;
            this.genreRepository = genreRepository;
        }

        public async Task<PublicationDto> Handle(GetSinglePublicationQuery request, CancellationToken cancellationToken)
        {
            var publication = this.repository
                                  .AllAsNoTracking()
                                  .FirstOrDefault(x => x.Id == request.Id)
                                  ?? throw new InvalidOperationException("Publication not found!");

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
                Genre = genre.Name ?? "No genre",
            };

            return await Task.FromResult(result);
        }
    }
}
