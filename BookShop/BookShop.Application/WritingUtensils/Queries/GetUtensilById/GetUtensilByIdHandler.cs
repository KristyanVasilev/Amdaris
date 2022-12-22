namespace BookShop.Application.WritingUtensils.Queries.GetUtensilById
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class GetUtensilByIdHandler : IRequestHandler<GetUtensilByIdQuery, WritingUtensilDto>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;
        private readonly IRepository<WritingUtensilsType> utensilRepository;

        public GetUtensilByIdHandler(
            IDeletableEntityRepository<WritingUtensil> repository,
            IRepository<WritingUtensilsType> utensilRepository)
        {
            this.repository = repository;
            this.utensilRepository = utensilRepository;
        }

        public Task<WritingUtensilDto> Handle(GetUtensilByIdQuery request, CancellationToken cancellationToken)
        {
            var utensil = this.repository
                              .AllAsNoTracking()
                              .FirstOrDefault(x => x.Id == request.Id)
                              ?? throw new WritingUtensilNotFoundException("Utensil not found!");

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

            return Task.FromResult(result);
        }
    }
}
