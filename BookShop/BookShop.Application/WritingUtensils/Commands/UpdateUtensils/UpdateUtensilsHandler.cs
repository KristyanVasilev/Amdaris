namespace BookShop.Application.WritingUtensils.Commands.UpdateUtensils
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class UpdateUtensilsHandler : IRequestHandler<UpdateUtensilsCommand, int>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;
        private readonly IRepository<WritingUtensilsType> utensilRepository;

        public UpdateUtensilsHandler(
            IDeletableEntityRepository<WritingUtensil> repository,
            IRepository<WritingUtensilsType> utensilRepository)
        {
            this.repository = repository;
            this.utensilRepository = utensilRepository;
        }

        public async Task<int> Handle(UpdateUtensilsCommand request, CancellationToken cancellationToken)
        {
            var type = this.utensilRepository
                           .AllAsNoTracking()
                           .FirstOrDefault(x => x.Name == request.WritingUtensilsType)
                           ?? new WritingUtensilsType { Name = request.WritingUtensilsType, CreatedOn = DateTime.UtcNow };

            var utensil = this.repository
                              .AllAsNoTracking()
                              .FirstOrDefault(x => x.Id == request.Id)
                              ?? throw new WritingUtensilNotFoundException("Utensil not found!");

            utensil.Price = request.Price;
            utensil.Name = request.Name;
            utensil.Manufacturer = request.Manufacturer;
            utensil.Color = request.Color;
            utensil.KeyWords = request.KeyWords;
            utensil.Quantity = request.Quantity;
            utensil.Images = request.Images;
            utensil.ModifiedOn = DateTime.UtcNow;

            if (type.Id == 0) utensil.WritingUtensilsType = type;
            else utensil.WritingUtensilsTypeId = type.Id;

            this.repository.Update(utensil);
            await this.repository.SaveChangesAsync();

            return await Task.FromResult(utensil.Id);
        }
    }
}
