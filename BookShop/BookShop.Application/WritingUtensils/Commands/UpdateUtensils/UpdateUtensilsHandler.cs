namespace BookShop.Application.WritingUtensils.Commands.UpdateUtensils
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class UpdateUtensilsHandler : IRequestHandler<UpdateUtensilsCommand, int>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;

        public UpdateUtensilsHandler(IDeletableEntityRepository<WritingUtensil> repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(UpdateUtensilsCommand request, CancellationToken cancellationToken)
        {
            var type = new WritingUtensilsType { Name = request.WritingUtensilsType };

            var utensil = this.repository.AllAsNoTracking().FirstOrDefault(x => x.Id == request.Id);
            if (utensil == null)
            {
                throw new InvalidOperationException("Publication cannot be null!");
            }

            utensil.Price = request.Price;
            utensil.Name = request.Name;
            utensil.Manufacturer = request.Manufacturer;
            utensil.Color = request.Color;
            utensil.WritingUtensilsType = type;
            utensil.ModifiedOn = DateTime.UtcNow;

            this.repository.Update(utensil);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult(utensil.Id);
        }
    }
}
