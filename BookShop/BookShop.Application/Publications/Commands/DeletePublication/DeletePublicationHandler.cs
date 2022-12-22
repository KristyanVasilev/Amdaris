namespace BookShop.Application.Publications.Commands.DeletePublication
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class DeletePublicationHandler : IRequestHandler<DeletePublicationCommand, string>
    {
        private readonly IDeletableEntityRepository<Publication> repository;

        public DeletePublicationHandler(IDeletableEntityRepository<Publication> repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(DeletePublicationCommand request, CancellationToken cancellationToken)
        {
            var publication = this.repository
                                  .AllAsNoTracking()
                                  .FirstOrDefault(x => x.Id == request.Id)
                                  ?? throw new PublicationNotFoundException("Publication not found!");

            this.repository.Delete(publication);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult($"Publication {publication.Name} with id - {publication.Id} deleted successfully!");
        }
    }
}
