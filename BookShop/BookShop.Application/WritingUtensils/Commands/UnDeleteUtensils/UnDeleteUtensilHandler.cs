namespace BookShop.Application.WritingUtensils.Commands.UnDeleteUtensils
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class UnDeleteUtensilHandler : IRequestHandler<UnDeleteUtensilCommand, WritingUtensilDto>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;
        private readonly IRepository<WritingUtensilsType> utensilRepository;

        public UnDeleteUtensilHandler(
            IDeletableEntityRepository<WritingUtensil> repository,
            IRepository<WritingUtensilsType> utensilRepository)
        {
            this.repository = repository;
            this.utensilRepository = utensilRepository;
        }

        public async Task<WritingUtensilDto> Handle(UnDeleteUtensilCommand request, CancellationToken cancellationToken)
        {
            var utensil = this.repository
                              .AllAsNoTrackingWithDeleted()
                              .Where(x => x.IsDeleted == true)
                              .FirstOrDefault(x => x.Name == request.Name)
                              ?? throw new WritingUtensilNotFoundException("Utensil not found!");

            this.repository.Undelete(utensil);
            await this.repository.SaveChangesAsync();

            var type = this.utensilRepository
                           .AllAsNoTracking()
                           .FirstOrDefault(t => t.Id == utensil.WritingUtensilsTypeId);

            var result = new WritingUtensilDto
            {
                Id = utensil.Id,
                Name = utensil.Name,
                Price = utensil.Price,
                Color = utensil.Color,
                Manufacturer = utensil.Manufacturer,
                Images = utensil.Images,
                WritingUtensilsType = type?.Name ?? "No type",
            };

            return await Task.FromResult(result);
        }
    }
}
