namespace BookShop.Application.WritingUtensils.Queries.GetUtensilsByType
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class GetUtensilsByTypeHandler : IRequestHandler<GetUtensilsByTypeQuery, IEnumerable<WritingUtensilDto>>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;
        private readonly IRepository<WritingUtensilsType> utensilRepository;

        public GetUtensilsByTypeHandler(
            IDeletableEntityRepository<WritingUtensil> repository,
            IRepository<WritingUtensilsType> utensilRepository)
        {
            this.repository = repository;
            this.utensilRepository = utensilRepository;
        }

        public async Task<IEnumerable<WritingUtensilDto>> Handle(GetUtensilsByTypeQuery request, CancellationToken cancellationToken)
        {
            var type = this.utensilRepository
                           .AllAsNoTracking()
                           .FirstOrDefault(t => t.Name == request.UtensilType)
                           ?? throw new WritingUtensilTypeNotFoundException("Utensil type not found!");

            var result =
                this.repository
                    .AllAsNoTracking()
                    .Where(x => x.WritingUtensilsTypeId == type.Id)
                    .Select(utensil => new WritingUtensilDto
                    {
                        Id = utensil.Id,
                        Name = utensil.Name,
                        Price = utensil.Price,
                        Color = utensil.Color,
                        Manufacturer = utensil.Manufacturer,
                        Images = utensil.Images,
                        WritingUtensilsType = utensil.WritingUtensilsType.Name,

                    }).OrderBy(x => x.Price);

            if (!result.Any())
            {
                throw new WritingUtensilNotFoundException("No Utensils found!");
            }

            return await Task.FromResult(result);
        }
    }
}
