namespace BookShop.Application.WritingUtensils.Queries.GetUtensilsByColor
{
    using BookShop.Application.Repositories;
    using BookShop.Application.SeedWork.Exceptions;
    using BookShop.Domain;
    using MediatR;

    public class GetUtensilsByColorHandler : IRequestHandler<GetUtensilsByColorQuery, IEnumerable<WritingUtensilDto>>
    {
        private readonly IDeletableEntityRepository<WritingUtensil> repository;

        public GetUtensilsByColorHandler(IDeletableEntityRepository<WritingUtensil> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<WritingUtensilDto>> Handle(GetUtensilsByColorQuery request, CancellationToken cancellationToken)
        {
            var result =
                this.repository
                    .AllAsNoTracking()
                    .Where(x => x.Color == request.Color)
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
