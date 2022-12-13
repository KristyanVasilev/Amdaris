namespace BookShop.Application.WritingUtensils.Queries.GetSingleUtensil
{
    using BookShop.Application.Repositories;
    using BookShop.Domain;
    using MediatR;

    public class GetSingleUtensilHandler : IRequestHandler<GetSingleUtensilQuery, WritingUtensilDto>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;
        private readonly IRepository<WritingUtensilsType> utensilRepository;

        public GetSingleUtensilHandler(
            IDeletableEntityRepository<WritingUtensil> repository,
            IRepository<WritingUtensilsType> utensilRepository)
        {
            this.repository = repository;
            this.utensilRepository = utensilRepository;
        }

        public Task<WritingUtensilDto> Handle(GetSingleUtensilQuery request, CancellationToken cancellationToken)
        {
            var utensil = this.repository
                              .AllAsNoTracking()
                              .FirstOrDefault(x => x.Id == request.Id)
                              ?? throw new InvalidOperationException("Utensil cannot be null!");

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
                WritingUtensilsType = type?.Name ?? "No type",
            };

            return Task.FromResult(result);
        }
    }
}
