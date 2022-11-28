namespace BookShop.Application.Publications.Commands.DeletePublication
{
    using BookShop.Application.Repositories;
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
            var publication = this.repository.AllAsNoTracking().FirstOrDefault(x => x.Id == request.Id);
            if (publication == null)
            {
                throw new InvalidOperationException("Publication cannot be null!");
            }

            this.repository.Delete(publication);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult($"Publication with id - {publication.Id} deleted successfully!");           
        }
    }
}
