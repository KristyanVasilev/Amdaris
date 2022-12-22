namespace BookShop.Application.WritingUtensils.Queries.GetUtensils
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class GetUtensilsHandler : IRequestHandler<GetUtensilsQuery, IEnumerable<WritingUtensilDto>>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;

        public GetUtensilsHandler(IDeletableEntityRepository<WritingUtensil> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<WritingUtensilDto>> Handle(GetUtensilsQuery request, CancellationToken cancellationToken)
        {
            var result = this.repository.AllAsNoTracking().Select(utensil => new WritingUtensilDto
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
