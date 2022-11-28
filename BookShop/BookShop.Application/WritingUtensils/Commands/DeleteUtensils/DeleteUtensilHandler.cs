namespace BookShop.Application.WritingUtensils.Commands.DeleteUtensils
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class DeleteUtensilHandler : IRequestHandler<DeleteUtensilCommand, string>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;

        public DeleteUtensilHandler(IDeletableEntityRepository<WritingUtensil> repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(DeleteUtensilCommand request, CancellationToken cancellationToken)
        {
            var utensil = this.repository.AllAsNoTracking().FirstOrDefault(x => x.Id == request.Id);
            if (utensil == null)
            {
                throw new InvalidOperationException("Utensil cannot be null!");
            }

            this.repository.Delete(utensil);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult($"Utensil with id - {utensil.Id} deleted successfully!");
        }
    }
}
