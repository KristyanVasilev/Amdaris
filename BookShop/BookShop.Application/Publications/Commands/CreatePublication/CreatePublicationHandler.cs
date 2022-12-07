namespace BookShop.Application.Publications.Commands.CreatePublication
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class CreatePublicationHandler : IRequestHandler<CreatePublicationCommand, int>
    {
        private readonly IDeletableEntityRepository<Publication> repository;
        private readonly IRepository<Genre> genreRepository;

        public CreatePublicationHandler(
            IDeletableEntityRepository<Publication> repository,
            IRepository<Genre> genreRepository)
        {
            this.repository = repository;
            this.genreRepository = genreRepository;
        }

        public async Task<int> Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
        {
            var genre = genreRepository
                        .AllAsNoTracking()
                        .FirstOrDefault(x => x.Name == request.Genre)
                        ?? new Genre { Name = request.Genre, CreatedOn = DateTime.UtcNow };

            var publication = new Publication
            {
                Price = request.Price,
                Name = request.Name,
                Author = request.Author,
                PageCount = request.PageCount,
                Rating = request.Rating,
                Description = request.Description,
                CreatedOn = DateTime.UtcNow,
            };

            if (genre.Id == 0) publication.Genre = genre;
            else publication.GenreId = genre.Id;

            await this.repository.AddAsync(publication);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult(publication.Id);
        }
    }
}
