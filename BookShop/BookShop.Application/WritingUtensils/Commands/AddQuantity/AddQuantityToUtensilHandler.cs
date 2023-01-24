namespace BookShop.Application.WritingUtensils.Commands.AddQuantity
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class AddQuantityToUtensilHandler : IRequestHandler<AddQuantityToUtensilCommand, string>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;

        public AddQuantityToUtensilHandler(IDeletableEntityRepository<WritingUtensil> repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(AddQuantityToUtensilCommand request, CancellationToken cancellationToken)
        {
            var utensil = this.repository
                               .AllAsNoTracking()
                               .FirstOrDefault(x => x.Id == request.Id)
                               ?? throw new WritingUtensilNotFoundException("Utensil not found!");

            utensil.Quantity += request.Quantity;

            this.repository.Delete(utensil);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult($"Utensil {utensil.Name} with id - {utensil.Id} added {request.Quantity} quantity successfully!");
        }
    }
}
