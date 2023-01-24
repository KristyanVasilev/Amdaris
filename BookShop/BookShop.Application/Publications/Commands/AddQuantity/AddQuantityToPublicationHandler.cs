namespace BookShop.Application.Publications.Commands.AddQuantity
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class AddQuantityToPublicationHandler : IRequestHandler<AddQuantityToPublicationCommand, string>
    {
        private readonly IDeletableEntityRepository<Publication> repository;

        public AddQuantityToPublicationHandler(IDeletableEntityRepository<Publication> repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(AddQuantityToPublicationCommand request, CancellationToken cancellationToken)
        {
            var publication = this.repository
                                   .AllAsNoTracking()
                                   .FirstOrDefault(x => x.Id == request.Id)
                                   ?? throw new PublicationNotFoundException("Publication not found!");

            publication.Quantity += request.Quantity;

            this.repository.Update(publication);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult($"Game {publication.Name} with id - {publication.Id} added {request.Quantity} quantity successfully!");
        }
    }
}
