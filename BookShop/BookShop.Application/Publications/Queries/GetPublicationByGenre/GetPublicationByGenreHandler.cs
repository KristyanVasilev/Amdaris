namespace BookShop.Application.Publications.Queries.GetPublicationByGenre
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class GetPublicationByGenreHandler : IRequestHandler<GetPublicationByGenreQuery, IEnumerable<PublicationDto>>
    {
        private readonly IDeletableEntityRepository<Publication> repository;
        private readonly IRepository<Genre> genreRepository;

        public GetPublicationByGenreHandler(
            IDeletableEntityRepository<Publication> repository,
            IRepository<Genre> genreRepository)
        {
            this.repository = repository;
            this.genreRepository = genreRepository;
        }

        public async Task<IEnumerable<PublicationDto>> Handle(GetPublicationByGenreQuery request, CancellationToken cancellationToken)
        {
            var genre = this.genreRepository
                            .AllAsNoTracking()
                            .FirstOrDefault(g => g.Name == request.GenreName)
                            ?? throw new GenreNotFoundException("Genre not found!");

            var result =
                this.repository
                    .AllAsNoTracking()
                    .Where(x => x.GenreId == genre.Id)
                    .Select(publication => new PublicationDto
                    {
                        Id = publication.Id,
                        Name = publication.Name,
                        Price = publication.Price,
                        Author = publication.Author,
                        PageCount = publication.PageCount,
                        Rating = publication.Rating,
                        Description = publication.Description,
                        Images = publication.Images,
                        Genre = publication.Genre.Name,

                    }).OrderBy(x => x.Price);

            if (!result.Any())
            {
                throw new PublicationNotFoundException("No Publications found!");
            }

            return await Task.FromResult(result);
        }
    }
}
