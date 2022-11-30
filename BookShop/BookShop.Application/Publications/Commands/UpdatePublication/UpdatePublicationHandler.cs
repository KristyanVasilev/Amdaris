namespace BookShop.Application.Publications.Commands.UpdatePublication
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class UpdatePublicationHandler : IRequestHandler<UpdatePublicationCommand, int>
    {
        private readonly IDeletableEntityRepository<Publication> repository;

        public UpdatePublicationHandler(IDeletableEntityRepository<Publication> repository)
        {
            this.repository = repository;
        }

        public async  Task<int> Handle(UpdatePublicationCommand request, CancellationToken cancellationToken)
        {

            var genre = new Genre { Name = request.Genre.Name };

            var publication = this.repository.AllAsNoTracking().FirstOrDefault(x => x.Id == request.Id);
            if (publication == null)
            {
                throw new InvalidOperationException("Publication cannot be null!");
            }

            publication.Price = request.Price;
            publication.Name = request.Name;
            publication.Author = request.Author;
            publication.PageCount = request.PageCount;
            publication.Rating = request.Rating;
            publication.Description = request.Description;
            publication.Genre = genre;
            
            this.repository.Update(publication);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult(publication.Id);
        }
    }
}
