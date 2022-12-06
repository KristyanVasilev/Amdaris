namespace BookShop.Application.Publications.Commands.UpdatePublication
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class UpdatePublicationHandler : IRequestHandler<UpdatePublicationCommand, int>
    {
        private readonly IDeletableEntityRepository<Publication> repository;
        private readonly IRepository<Genre> genreRepository;

        public UpdatePublicationHandler(
            IDeletableEntityRepository<Publication> repository,
            IRepository<Genre> genreRepository)
        {
            this.repository = repository;
            this.genreRepository = genreRepository;
        }

        public async  Task<int> Handle(UpdatePublicationCommand request, CancellationToken cancellationToken)
        {
            var genre = genreRepository
                       .AllAsNoTracking()
                       .FirstOrDefault(x => x.Name == request.Name)
                       ?? new Genre { Name = request.Genre };

            var publication = this.repository
                                  .AllAsNoTracking()
                                  .FirstOrDefault(x => x.Id == request.Id)
                                  ?? throw new InvalidOperationException("Publication not found!");


            publication.Price = request.Price;
            publication.Name = request.Name;
            publication.Author = request.Author;
            publication.PageCount = request.PageCount;
            publication.Rating = request.Rating;
            publication.Description = request.Description;
            publication.Genre = genre;
            publication.ModifiedOn = DateTime.UtcNow;

            this.repository.Update(publication);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult(publication.Id);
        }
    }
}
